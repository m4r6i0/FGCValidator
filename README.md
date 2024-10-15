
# Validador FGC - Versão Completa

Este projeto é uma aplicação console em .NET Core para validação de arquivos JSON conforme o layout do Censo FGC (FGC300 e FGC301).

## Instruções de uso

1. Compile o projeto utilizando o .NET Core SDK.
2. Execute a aplicação e forneça o caminho do arquivo JSON a ser validado.
3. A aplicação irá verificar os campos obrigatórios e validar o layout conforme as especificações do manual operacional e técnico do Censo FGC.

## Estrutura

- `FGC300Validator`: Classe responsável pela validação do leiaute FGC300 (Censo por Produto).
- `FGC301Validator`: Classe responsável pela validação do leiaute FGC301 (Censo por Titularidade).

## Dependências

- .NET Core SDK 3.1 ou superior.
- Newtonsoft.Json (para manipulação de JSON).

## Compilação

```bash
dotnet build
```

## Execução

```bash
dotnet run
```

Ao executar, digite o caminho do arquivo JSON que deseja validar.
