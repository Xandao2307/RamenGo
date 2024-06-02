# RamenGo API

## Descrição

Este projeto é uma API para a aplicação web **RamenGo**, desenvolvida com **C# .NET 8**. A API permite que os usuários montem pedidos de ramen, selecionando tipos de caldos e proteínas. A API oferece endpoints para listar as opções disponíveis e um endpoint para processar e confirmar o pedido do usuário.

## Funcionalidades

1. **Listar Caldos Disponíveis**: Retorna uma lista de tipos de caldos que podem ser escolhidos para o ramen.
2. **Listar Proteínas Disponíveis**: Retorna uma lista de tipos de proteínas que podem ser escolhidas para o ramen.
3. **Fazer Pedido**: Recebe as seleções do usuário (um tipo de caldo e um tipo de proteína) e processa o pedido, retornando uma confirmação com um código do pedido.

## Endpoints

- **Listar Caldos**: `GET /api/caldos`
- **Listar Proteínas**: `GET /api/proteinas`
- **Fazer Pedido**: `POST /api/pedidos`

## Requisitos

- **.NET 8 SDK**
- **ASP.NET Core**

## Como Rodar o Projeto

1. **Clonar o repositório**:
   ```bash
   git clone https://github.com/seu-usuario/ramengo-api.git
   cd ramengo-api
   dotnet restore 
   ```

2. **Configurar as variavéis de ambiente**:
```json
[
    {
        "ApiKey": "ZtVdh8XQ2U8pWI2gmZ7f796Vh8GllXoN7mr0djNf"
    }
]
```
3. **Rodar Aplicação**:
   ```bash
   dotnet run
   ```

   ## Tecnologias Utilizadas

- **.NET 8 SDK**
- **Entity Framework**