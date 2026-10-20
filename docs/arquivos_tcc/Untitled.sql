CREATE TABLE [SAVE_JOGADOR] (
  [id_save] int PRIMARY KEY,
  [pontos_vida] int,
  [id_secao_atual] int,
  [id_habilidade_ativa] int,
  [qt_uso_atual] int
)
GO

CREATE TABLE [SECAO] (
  [id_secao] int PRIMARY KEY,
  [nome_secao] nvarchar(255)
)
GO

CREATE TABLE [HABILIDADE] (
  [id_habilidade] int PRIMARY KEY,
  [nome_habilidade] nvarchar(255),
  [is_desbloqueada] binary,
  [qt_uso] int
)
GO

CREATE TABLE [OBSTACULO_ESTADO] (
  [id_obstaculo] int PRIMARY KEY,
  [id_secao] int,
  [id_habilidade_requerida] int,
  [is_superado] binary
)
GO

ALTER TABLE [SAVE_JOGADOR] ADD FOREIGN KEY ([id_secao_atual]) REFERENCES [SECAO] ([id_secao])
GO

ALTER TABLE [SAVE_JOGADOR] ADD FOREIGN KEY ([id_habilidade_ativa]) REFERENCES [HABILIDADE] ([id_habilidade])
GO

ALTER TABLE [OBSTACULO_ESTADO] ADD FOREIGN KEY ([id_secao]) REFERENCES [SECAO] ([id_secao])
GO

ALTER TABLE [OBSTACULO_ESTADO] ADD FOREIGN KEY ([id_habilidade_requerida]) REFERENCES [HABILIDADE] ([id_habilidade])
GO
