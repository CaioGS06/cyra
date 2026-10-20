---
name: cyra-rastreabilidade-testes
description: Gera casos de teste funcionais (T00-T10) e entradas na matriz de revisão cruzada (A08) dentro de docs/Diario_Experimento_Cyra.md.
---

# Skill: Rastreabilidade, Revisão Cruzada (A08) e Testes Funcionais (A10)

## Quando usar
Sempre que um novo requisito (A01, RF01 a RF06, RNF01 a RNF06) for implementado ou quando o usuário solicitar preparação para teste/revisão cruzada.

## Procedimento
1. **Atualizar a Tabela 3 (Registro de Testes Funcionais) em `docs/Diario_Experimento_Cyra.md`:**
   - Para a funcionalidade recém-criada, adicione os cenários de teste obrigatórios (ex.: testar bloqueio sem habilidade, com habilidade errada e com habilidade correta para o RF05).
   - Preencha `ID Teste`, `Requisito / Etapa`, `Condição Inicial`, `Passos Executados`, `Resultado Esperado` e sugira o nome padronizado do print na coluna `Evidência` (ex: `docs/evidencias/T05_bloqueio_habilidade.png`).
   - Deixe `Resultado Observado` e `Situação` como `[Pendente execução humana]`.

2. **Atualizar a Seção de Revisão Cruzada (A08):**
   - Caso a seção "5. Matriz de Revisão Cruzada e Rastreabilidade (A08)" ainda não exista no arquivo `docs/Diario_Experimento_Cyra.md`, crie-a com as colunas: `Requisito | Módulo/Script e Versão | Autor Principal | Revisor Cruzado | Achado na Revisão (Estado/Sinais/Acoplamento) | Decisão/Correção | Teste Vinculado`.
   - Insira a linha pré-preenchida para que o outro desenvolvedor (Caio ou Lucas) apenas anote o achado da revisão.