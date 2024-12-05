# CRUD em C#

Este é um projeto de **CRUD** (Create, Read, Update, Delete) desenvolvido em **C#** com as seguintes ferramentas e tecnologias:

- **Editor**: Visual Studio Code  
- **Framework**: .NET 8  
- **Banco de Dados**: SQL Server, gerenciado pelo **SQL Server Management Studio**  

## Estrutura do Projeto

O projeto organiza as funcionalidades do CRUD dentro da pasta **Pages** e depois na pasta **Products**, contendo 8 arquivos no total, organizados em pares (C# e HTML):

### Funcionalidades:

- **Index**: Responsável por listar os produtos.  
- **Create**: Cria novos produtos.  
- **Edit**: Edita produtos existentes.  
- **Delete**: Remove produtos.  

Cada funcionalidade conta com um arquivo de lógica em **C#** e uma interface em **HTML** para a interação do usuário.

## Extensões do VS Code utilizadas

As seguintes extensões foram essenciais para o desenvolvimento:

- **SQL Server**  
- **SQL Data Base Projects**  
- **SQL Bindings**  
- **NuGet Package Manager**  
- **C# Extensions**  
- **.NET Install Tool**  
- **C# Language**  

## Configuração do Banco de Dados

Para executar o projeto em um ambiente de testes, siga os seguintes passos:

### 1. Configuração da String de Conexão

Localize a seguinte linha de código nos 4 arquivos C# dentro da pasta **Products**:

```csharp
string connectionString = "Server=GUERRERO-PC\\SQLSERVER;Database=cruddb;Trusted_Connection=True;TrustServerCertificate=True;";
```
Substitua GUERRERO-PC\\SQLSERVER pelo nome do servidor SQL criado no seu ambiente local.

### 2. Criação da Tabela

Use o arquivo CREATE TABLE products.sql para criar a tabela products no banco de dados. Este arquivo contém o script SQL necessário para configurar a tabela, facilitando a preparação do ambiente de testes.

### 3. Para Iniciar o Código 

Abra um terminal e assim digite dotnet run e assim irá compilar dando um link do localhost e assim acessando já poderá usar o sistema.
