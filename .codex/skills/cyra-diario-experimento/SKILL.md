---
name: cyra-diario-experimento
description: Atualiza automaticamente os arquivos docs/Diario_Experimento_Cyra.md e docs/Prompts_Utilizados.md após qualquer geração ou alteração de código/cena no projeto Cyra.
---

# Skill: Registro Automático do Diário do Experimento (Cyra)

## Quando usar
Execute esta skill **automaticamente ao final de qualquer tarefa** em que código C#, cenas `.tscn` ou arquivos de configuração do Godot forem gerados ou alterados.

## Procedimento Passo a Passo
1. **Registrar o Prompt (`docs/Prompts_Utilizados.md`):**
   - Crie o arquivo caso não exista.
   - Adicione um novo bloco com o próximo ID sequencial (`P01`, `P02`, `P03`...), a data atual, a Atividade/Requisito (ex: `A01`, `A05 / RF01`) e o texto exato do prompt enviado pelo desenvolvedor.

2. **Adicionar Linha na Tabela 1 (`docs/Diario_Experimento_Cyra.md`):**
   - Localize a "Tabela 1: Resumo do Diário do Experimento".
   - Insira uma nova linha com o próximo ID (`D01`, `D02`...) preenchendo automaticamente:
     - **Data:** Data atual (DD/MM).
     - **Ativ. / Req.:** Atividade e requisito informados no prompt (ex: `A01`, `A05 / RF01`).
     - **Módulo / Script:** Lista dos arquivos `.cs` e `.tscn` criados ou modificados.
     - **Ferramenta / Modelo:** `Codex`.
     - **ID do Prompt:** O ID registrado no passo 1 (`P01`, `P02`...).
     - **Saída Original da IA:** Resumo técnico objetivo em 1 frase do que foi gerado antes de qualquer edição humana.
     - **Intervenção / Revisão Humana:** Preencha com `[PENDENTE PREENCHIMENTO HUMANO: Descrever ajustes de código/Inspector]`.
     - **Resp.:** Nome do dev (Caio ou Lucas, se informado, ou `[Caio/Lucas]`).
     - **Tempo Aprendizagem Godot:** `[PENDENTE: X min]`.
     - **Tempo IA (Geração + Revisão + Correção):** `[Geração concluída | Revisão/Correção: X min]`.
     - **Versão / Commit Integrado:** `[PENDENTE COMMIT]`.

3. **Gerar Ficha Detalhada na Seção 2 (`docs/Diario_Experimento_Cyra.md`):**
   - Adicione ao final da Seção 2 uma ficha correspondente ao ID (`Registro D0X`) já com os itens **"Requisito / Objetivo"** e **"O que a IA entregou originalmente (Estado Antes da Revisão)"** totalmente preenchidos com a explicação técnica dos métodos, sinais e nós utilizados.
   - Deixe um checklist sob **"O que exigiu Curadoria / Correção Humana"** listando exatamente o que o desenvolvedor precisa conferir manualmente no Godot Editor (ex.: atribuir `CollisionShape2D`, conectar sinais no Inspector ou testar física).