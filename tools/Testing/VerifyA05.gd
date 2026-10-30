# A05 / T05: ensaio automatizado na física real da engine, com entrada simulada.
# Fixtures posicionam corpos e interrompem patrulha em testes de alcance isolados.
# Não é teste gráfico humano nem benchmark. Não faz parte das cenas exportadas.
extends SceneTree

var checks: Array[Dictionary] = []
var changed_count := 0
var depleted_count := 0

func _initialize() -> void:
    call_deferred("run_checks")

func check(value: bool, description: String) -> void:
    checks.append({"passed": value, "description": description})
    print(("PASS: " if value else "FAIL: ") + description)

func ticks(count: int) -> void:
    for index in count:
        await physics_frame
        await process_frame

func tap(action: String, frames := 1) -> void:
    Input.action_press(action)
    await ticks(frames)
    Input.action_release(action)
    await ticks(1)

func on_changed(_previous: int, _current: int, _maximum: int) -> void:
    changed_count += 1

func on_depleted() -> void:
    depleted_count += 1

func isolate_enemy(room: Node) -> Node:
    var enemy = room.get_node("Enemy")
    enemy.set_physics_process(false)
    enemy.get_node("ContactArea").monitoring = false
    return enemy

func reset_room() -> Node:
    var previous = current_scene
    var key := InputEventKey.new()
    key.keycode = KEY_R
    key.physical_keycode = KEY_R
    key.pressed = true
    Input.parse_input_event(key)
    await ticks(1)
    key = key.duplicate()
    key.pressed = false
    Input.parse_input_event(key)
    await ticks(4)
    check(current_scene != previous, "reinício manual troca somente a sala")
    return current_scene

func run_checks() -> void:
    var room = load("res://Scenes/Test/TestRoomA05.tscn").instantiate()
    root.add_child(room)
    current_scene = room
    await ticks(4)
    var player = room.get_node("Player")
    var enemy = isolate_enemy(room)
    var health = player.get_node("Health")
    var enemy_health = enemy.get_node("Health")
    check(health.get("Current") == 5 and enemy_health.get("Current") == 3, "vida inicial real 5/3")
    check(room.get_node("CanvasLayer/PlayerHealth").text == "Vida: 5/5", "UI inicializa com o componente real")
    health.set("Maximum", 8)
    check(health.get("Current") == 5 and room.get_node("CanvasLayer/PlayerHealth").text == "Vida: 5/8", "alterar máximo não cura e atualiza a UI")
    health.set("Maximum", 5)
    check(player.is_on_floor(), "ator pousa no ponto seguro")
    for binding in [["player_left", KEY_A], ["player_left", KEY_LEFT], ["player_right", KEY_D], ["player_right", KEY_RIGHT], ["player_jump", KEY_SPACE], ["player_attack", KEY_J], ["player_restart", KEY_R]]:
        check(InputMap.action_get_events(binding[0]).any(func(event): return event is InputEventKey and event.physical_keycode == binding[1]), "Input Map: %s / %s" % [binding[0], binding[1]])
    check(not InputMap.action_get_events("player_attack").any(func(event): return event is InputEventKey and event.physical_keycode == KEY_F9), "F9 não é ataque")
    player.position = Vector2(180, 260)
    player.velocity = Vector2.ZERO
    await ticks(60)
    check(player.is_on_floor() and absf(player.position.y - 416) < 0.5, "gravidade e piso sem atravessamento")
    var start_x: float = player.position.x
    await tap("player_right", 20)
    check(player.position.x > start_x + 60, "movimento à direita")
    start_x = player.position.x
    await tap("player_left", 20)
    check(player.position.x < start_x - 60, "movimento à esquerda")
    player.position = Vector2(850, 416)
    Input.action_press("player_right")
    await ticks(50)
    check(player.position.x <= 904.5 and player.is_on_wall(), "parede direita bloqueia o jogador")
    Input.action_release("player_right")
    await ticks(1)
    player.position = Vector2(120, 416)
    Input.action_press("player_left")
    await ticks(50)
    check(player.position.x >= 55.5 and player.is_on_wall(), "parede esquerda bloqueia o jogador")
    Input.action_release("player_left")
    await ticks(1)
    player.position = Vector2(180, 416)
    await ticks(3)
    await tap("player_jump", 8)
    check(player.position.y < 390 and player.velocity.y < 0, "pulo permitido no piso")
    var before_y_speed: float = player.velocity.y
    await tap("player_jump", 2)
    check(player.velocity.y > before_y_speed, "novo comando no ar não concede salto extra")
    await ticks(70)
    check(player.is_on_floor() and absf(player.position.y - 416) < 0.5, "pulo retorna ao piso")

    # Plataformas nativas de fixture: observar borda e parede sem simular resposta.
    var ledge := StaticBody2D.new()
    var ledge_shape := CollisionShape2D.new()
    var rectangle := RectangleShape2D.new()
    rectangle.size = Vector2(120, 20)
    ledge_shape.shape = rectangle
    ledge.position = Vector2(460, 300)
    ledge.add_child(ledge_shape)
    root.add_child(ledge)
    var patrol_fixture = load("res://Scenes/Entities/BasicEnemy.tscn").instantiate()
    patrol_fixture.set("TechnicalId", "fixture_edge")
    patrol_fixture.set("PatrolDistance", 500.0)
    patrol_fixture.position = Vector2(460, 266)
    root.add_child(patrol_fixture)
    await ticks(120)
    check(patrol_fixture.is_on_floor() and absf(patrol_fixture.position.y - 266) < 1 and patrol_fixture.position.x > 418 and patrol_fixture.position.x < 502, "RayCast2D faz o inimigo retornar antes da borda")
    patrol_fixture.queue_free()
    ledge.queue_free()
    await ticks(2)
    patrol_fixture = load("res://Scenes/Entities/BasicEnemy.tscn").instantiate()
    patrol_fixture.set("TechnicalId", "fixture_wall")
    patrol_fixture.set("PatrolDistance", 500.0)
    patrol_fixture.position = Vector2(80, 416)
    root.add_child(patrol_fixture)
    await ticks(50)
    check(patrol_fixture.position.x >= 58 and patrol_fixture.velocity.x > 0, "colisão nativa faz a patrulha inverter na parede")
    patrol_fixture.queue_free()
    await ticks(2)

    player.position = Vector2(300, 416)
    await tap("player_right")
    player.position = Vector2(300, 416)
    enemy.position = Vector2(520, 416)
    await ticks(2)
    await tap("player_attack", 16)
    check(enemy_health.get("Current") == 3, "ataque fora de alcance não causa dano")
    await ticks(20)
    enemy.position = Vector2(360, 416)
    await ticks(2)
    Input.action_press("player_attack")
    await ticks(50)
    check(enemy_health.get("Current") == 2, "mesmo alvo recebe só um dano por ataque; segurar não repete")
    Input.action_release("player_attack")
    await ticks(1)
    await tap("player_attack", 2)
    check(enemy_health.get("Current") == 1, "novo ataque após intervalo causa novo dano")
    await tap("player_attack", 2)
    check(enemy_health.get("Current") == 1, "comando antes do intervalo não cria ataque adicional")
    await ticks(30)
    enemy.position = Vector2(240, 416)
    await ticks(2)
    await tap("player_attack", 15)
    check(enemy_health.get("Current") == 1, "alvo atrás da direção capturada não é atingido")
    await ticks(20)
    await tap("player_left")
    player.position = Vector2(300, 416)
    await tap("player_attack", 15)
    check(enemy_health.get("Current") == 0 and enemy.get("IsStunned"), "ataque à esquerda atordoa a zero")
    check(room.get_node("CanvasLayer/EnemyHealth").text == "Inimigo: 0/3", "UI do inimigo acompanha o sinal de vida")
    var stunned_position: Vector2 = enemy.position
    enemy.set_physics_process(true)
    player.position = enemy.position
    await ticks(240)
    check(enemy.get("IsStunned") and enemy_health.get("Current") == 0, "atordoamento sem recuperação por tempo")
    check(enemy.is_inside_tree() and enemy.visible and enemy.position.distance_to(stunned_position) < 1, "atordoado permanece identificável em posição estável")
    check(health.get("Current") == 5, "contato com atordoado não causa dano")
    check(not enemy.call("ReceiveAttack", 100), "ataque extra no atordoado é ignorado")

    # Componente real reutilizado em outro exemplar, sem UI ou jogador associado.
    var dummy = load("res://Scenes/Entities/BasicEnemy.tscn").instantiate()
    dummy.name = "HealthFixture"
    dummy.set("TechnicalId", "fixture_health")
    root.add_child(dummy)
    dummy.set_physics_process(false)
    var dummy_health = dummy.get_node("Health")
    dummy_health.connect("Changed", on_changed)
    dummy_health.connect("Depleted", on_depleted)
    check(not dummy_health.call("ApplyDamage", 0, "fixture") and not dummy_health.call("ApplyDamage", -1, "fixture"), "dano nulo/negativo rejeitado")
    dummy_health.call("ApplyDamage", 2147483647, "fixture")
    dummy_health.call("ApplyDamage", 2147483647, "fixture")
    check(dummy_health.get("Current") == 0 and depleted_count == 1 and changed_count == 1, "vida limitada sem overflow e Depleted emitido uma vez")
    dummy_health.set("Maximum", 0)
    check(dummy_health.get("Maximum") == 1 and dummy_health.get("Current") == 0, "máximo inválido é limitado sem ressuscitar")
    dummy.queue_free()
    await ticks(2)

    room = await reset_room()
    player = room.get_node("Player")
    enemy = room.get_node("Enemy")
    health = player.get_node("Health")
    enemy.set("PatrolSpeed", 0.0) # Fixture fixa o contato para medir o intervalo.
    enemy.position = Vector2(300, 416)
    player.position = enemy.position
    await ticks(4)
    check(health.get("Current") == 4, "contato aplica o primeiro dano")
    await ticks(20)
    check(health.get("Current") == 4, "sobreposição não multiplica dano por quadro")
    check(room.get_node("CanvasLayer/PlayerHealth").text == "Vida: 4/5", "UI do jogador segue dano por sinal")
    await ticks(35)
    check(health.get("Current") == 3, "dano volta após intervalo de proteção")

    # Três mortes por contato real. O autoload não é recarregado com a sala.
    var recorder_id: int = root.get_node("TestRunRecorder").get_instance_id()
    var expected_node_count := get_node_count()
    for cycle in 3:
        if cycle > 0:
            enemy = current_scene.get_node("Enemy")
            player = current_scene.get_node("Player")
            enemy.set("PatrolSpeed", 0.0)
            enemy.position = Vector2(300, 416)
            player.position = enemy.position
        var previous = current_scene
        for frame in 300:
            await ticks(1)
            if current_scene != previous:
                break
        await ticks(4)
        check(current_scene != previous, "morte por contato reinicia a sala: ciclo %d" % (cycle + 1))
        player = current_scene.get_node("Player")
        enemy = current_scene.get_node("Enemy")
        check(player.get_node("Health").get("Current") == 5 and player.position.distance_to(Vector2(140, 416)) < 1, "retorno seguro com vida máxima: ciclo %d" % (cycle + 1))
        check(enemy.get_node("Health").get("Current") == 3 and not enemy.get("IsStunned"), "inimigo reiniciado: ciclo %d" % (cycle + 1))
        check(get_node_count() == expected_node_count and root.get_node("TestRunRecorder").get_instance_id() == recorder_id, "sem nós extras e mesmo autoload: ciclo %d" % (cycle + 1))

    enemy = isolate_enemy(current_scene)
    player = current_scene.get_node("Player")
    health = player.get_node("Health")
    await tap("player_attack", 2)
    check(player.get("IsAttacking"), "ataque tem janela ativa")
    player.call("TryReceiveDamage", 999, "fixture_lethal")
    check(health.get("Current") == 0 and not player.get("IsAttacking") and not player.get_node("AttackArea/Visual").visible, "morte interrompe janela e visual de ataque")
    check(not player.call("TryReceiveDamage", 1, "fixture_repeat"), "jogador morto não recebe novo dano")
    await ticks(5)
    # F9 é uma marca simulada, explicitamente não aprovação humana.
    var marker := InputEventKey.new()
    marker.keycode = KEY_F9
    marker.pressed = true
    Input.parse_input_event(marker)
    await ticks(3)
    var failures = checks.filter(func(item): return not item.passed)
    var report = {"schema": 1, "scenario": "A05", "headless": DisplayServer.get_name() == "headless", "simulated_input": true, "fixture_placements": true, "human_validation": "pending", "passed": checks.size() - failures.size(), "failed": failures.size(), "checks": checks}
    var path := "res://.godot/a05/behavior-results.json"
    for arg in OS.get_cmdline_user_args():
        if arg.begins_with("--a05-report="):
            path = arg.trim_prefix("--a05-report=")
    var output = FileAccess.open(path, FileAccess.WRITE)
    if output:
        output.store_string(JSON.stringify(report, "  "))
    print("A05_BEHAVIOR_RESULT: %d passed, %d failed" % [report.passed, report.failed])
    quit(0 if failures.is_empty() else 1)
