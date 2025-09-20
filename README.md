# Secure API with Auth & Testing - .NET 8 Portfolio

![.NET](https://img.shields.io/badge/.NET-8-blueviolet) ![C#](https://img.shields.io/badge/C%23-11-blue) ![xUnit](https://img.shields.io/badge/Tests-xUnit-green) ![JWT](https://img.shields.io/badge/Auth-JWT-red) ![Clean Architecture](https://img.shields.io/badge/Architecture-Clean-orange) ![SOLID Principles](https://img.shields.io/badge/SOLID-Principles-brightgreen)

This repository is a focused .NET 8 project demonstrating the implementation of a secure, token-based authentication and authorization system using JWT (JSON Web Tokens). The API provides the essential endpoints for user registration and login, alongside a protected resource to validate the security flow. A key feature is the inclusion of foundational integration tests (xUnit) that automatically verify the authentication logic, ensuring that protected endpoints are correctly secured.

## 🚀 Key Features & Concepts Demonstrated

This project serves as a practical demonstration of the following concepts and technologies:

* **Security & Authentication:**
    * **ASP.NET Core Identity:** Used for the underlying user and password management, including secure hashing and data storage.
    * **JWT (JSON Web Token) Authentication:** Implementation of a stateless, token-based flow with endpoints for user registration, login, and token generation via a dedicated `TokenService`.
    * **Authorization Middleware:** Configuration of the `JwtBearer` middleware to validate tokens on incoming requests.
    * **Protected Endpoints:** Use of the `[Authorize]` attribute to secure specific API resources from unauthenticated access.

* **Automated Testing (xUnit):**
    * **Integration Testing:** A dedicated test project (`SecureApi.Tests`) with foundational tests that validate the API's security logic from end to end.
    * **`WebApplicationFactory`:** Utilization of a custom, in-memory test server to make real HTTP requests to the API.
    * **In-Memory SQLite Database:** Configuration of the test factory to use a clean, isolated, in-memory database for each test run, ensuring reliable and repeatable test results.
    * **Security Verification:** Automated tests prove that security rules are enforced, correctly returning `401 Unauthorized` for requests without a token and `200 OK` for requests with a valid token.

* **Architecture & Best Practices:**
    * **Clean Architecture & SOLID:** A layered architecture (Controller, Service, Repository) that adheres to SOLID principles for a maintainable codebase.
    * **Repository Pattern & Dependency Injection:** Abstraction of data access and extensive use of DI for a decoupled and testable application structure.
    * **Swagger/OpenAPI:** Configuration of Swagger to support JWT authentication, allowing for easy manual testing of protected endpoints.

## 📋 API Endpoints

The API exposes the following endpoints to demonstrate the authentication flow:

| Verb     | Route                 | Description                        | Security             |
| :------- | :-------------------- | :--------------------------------- | :------------------- |
| `POST`   | `/api/Auth/register`  | Registers a new user.              | **Public** |
| `POST`   | `/api/Auth/login`     | Authenticates a user and returns a JWT. | **Public** |
| `GET`    | `/api/Products`       | (Example) Lists all products.                | **Protected (Requires Token)** |

## ⚙️ How to Run the Project

### Prerequisites
* [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* Git

### Steps

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/SEU-USUARIO/.Net8-RestfulAPI-With-Middleware.git](https://github.com/SEU-USUARIO/.Net8-RestfulAPI-With-Middleware.git)
    ```
    (Remember to replace `SEU-USUARIO` with your GitHub username)

2.  **Navigate to the project folder:**
    ```bash
    cd .Net8-RestfulAPI-With-Middleware/SecureApi
    ```

3.  **Prepare the Database (First time only):**
    This command creates the `secureapi.db` database file with the Identity tables. The command you use depends on your terminal.

    * **If you are using a standard terminal (Git Bash, PowerShell, CMD):**
        First, you may need to install the EF Core global tool (you only need to do this once per machine):
        ```bash
        dotnet tool install --global dotnet-ef
        ```
        Then, run the update command:
        ```bash
        dotnet ef database update
        ```

    * **If you are using the Visual Studio Package Manager Console (PMC):**
        Simply run the command:
        ```powershell
        Update-Database
        ```

4.  **Run the application:**
    This is the command you will use daily to start the API server.
    ```bash
    dotnet run
    ```
    The API will be running locally. You can access the Swagger UI at the URL shown in the terminal (usually `https://localhost:7XXX/swagger`).

## 🧪 How to Run the Tests

You can run the automated tests in two ways:

1.  **Via .NET CLI:**
    Navigate to the solution's root folder (`.Net8-Auth-And-Testing`) and run:
    ```bash
    dotnet test
    ```

2.  **Via Visual Studio:**
    Open the **Test Explorer** window (**Test > Test Explorer**). The tests will be discovered automatically, and you can run them by clicking the "Run All Tests" button.

---
---

# API Segura com Autenticação e Testes - Portfólio .NET 8

![.NET](https://img.shields.io/badge/.NET-8-blueviolet) ![C#](https://img.shields.io/badge/C%23-11-blue) ![xUnit](https://img.shields.io/badge/Testes-xUnit-green) ![JWT](https://img.shields.io/badge/Auth-JWT-red) ![Arquitetura Limpa](https://img.shields.io/badge/Arquitetura-Clean-orange) ![SOLID Principles](https://img.shields.io/badge/Princípios-SOLID-brightgreen)

Este repositório é um projeto focado em .NET 8 que demonstra a implementação de um sistema seguro de autenticação e autorização baseado em tokens JWT (JSON Web Tokens). A API fornece os endpoints essenciais para registro e login de usuários, juntamente com um recurso protegido para validar o fluxo de segurança. Uma característica chave é a inclusão de testes de integração fundamentais (xUnit) que verificam automaticamente a lógica de autenticação, garantindo que os endpoints protegidos estão corretamente seguros.

## 🚀 Principais Funcionalidades e Conceitos Demonstrados

Este projeto serve como uma demonstração prática dos seguintes conceitos e tecnologias:

* **Segurança e Autenticação:**
    * **ASP.NET Core Identity:** Utilizado para o gerenciamento de usuários e senhas, incluindo hashing seguro e armazenamento de dados.
    * **Autenticação JWT (JSON Web Token):** Implementação de um fluxo de autenticação stateless baseado em token, com endpoints para registro, login e geração de token via um `TokenService` dedicado.
    * **Middleware de Autorização:** Configuração do middleware `JwtBearer` para validar os tokens em requisições recebidas.
    * **Endpoints Protegidos:** Uso do atributo `[Authorize]` para proteger recursos específicos da API contra acesso não autenticado.

* **Testes Automatizados (xUnit):**
    * **Testes de Integração:** Um projeto de teste (`SecureApi.Tests`) com testes fundamentais que validam a lógica de segurança da API de ponta a ponta.
    * **`WebApplicationFactory`:** Utilização de um servidor de teste customizado e em memória para realizar requisições HTTP reais à API.
    * **Banco de Dados SQLite em Memória:** Configuração da `WebApplicationFactory` para garantir que cada execução de teste utilize um banco de dados limpo e isolado, assegurando resultados de teste confiáveis e repetíveis.
    * **Verificação de Segurança:** Testes automatizados que provam que as regras de segurança são aplicadas, retornando `401 Unauthorized` para requisições sem token e `200 OK` para requisições com um token válido.

* **Arquitetura e Boas Práticas:**
    * **Arquitetura Limpa & SOLID:** Uma arquitetura em camadas (Controller, Service, Repository) que adere aos princípios SOLID para um código manutenível.
    * **Padrão de Repositório & Injeção de Dependência:** Abstração do acesso a dados e uso extensivo de DI para uma estrutura de aplicação desacoplada e testável.
    * **Swagger/OpenAPI:** Configuração do Swagger para suportar autenticação JWT, permitindo testes manuais de endpoints protegidos.

## 📋 Endpoints da API

A API expõe os seguintes endpoints para demonstrar o fluxo de autenticação:

| Verbo    | Rota                  | Descrição                                 | Segurança                     |
| :------- | :-------------------- | :---------------------------------------- | :---------------------------- |
| `POST`   | `/api/Auth/register`  | Registra um novo usuário.                 | **Público** |
| `POST`   | `/api/Auth/login`     | Autentica um usuário e retorna um JWT.    | **Público** |
| `GET`    | `/api/Products`       | (Exemplo) Lista todos os produtos.        | **Protegido (Requer Token)** |

## ⚙️ Como Executar o Projeto

### Pré-requisitos
* [.NET 8 SDK](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)
* Git

### Passos

1.  **Clone o repositório:**
    ```bash
    git clone [https://github.com/SEU-USUARIO/.Net8-RestfulAPI-With-Middleware.git](https://github.com/SEU-USUARIO/.Net8-RestfulAPI-With-Middleware.git)
    ```
    (Lembre-se de substituir `SEU-USUARIO` pelo seu nome de usuário do GitHub)

2.  **Navegue até a pasta do projeto:**
    ```bash
    cd .Net8-RestfulAPI-With-Middleware/SecureApi
    ```

3.  **Prepare o Banco de Dados (Apenas na primeira vez):**
    Este comando cria o arquivo de banco de dados `secureapi.db` com as tabelas do Identity. O comando a ser usado depende do seu terminal.

    * **Se você estiver usando um terminal padrão (Git Bash, PowerShell, CMD):**
        Primeiro, pode ser necessário instalar a ferramenta global do EF Core (você só precisa fazer isso uma vez por máquina):
        ```bash
        dotnet tool install --global dotnet-ef
        ```
        Em seguida, execute o comando de atualização:
        ```bash
        dotnet ef database update
        ```

    * **Se você estiver usando o Package Manager Console (PMC) do Visual Studio:**
        Simplesmente execute o comando:
        ```powershell
        Update-Database
        ```

4.  **Execute a Aplicação:**
    Este é o comando que você usará no dia a dia para iniciar o servidor da API.
    ```bash
    dotnet run
    ```
    A API estará rodando localmente. Você pode acessar a documentação do Swagger na URL indicada no terminal (geralmente `https://localhost:7XXX/swagger`).

## 🧪 Como Rodar os Testes

Você pode executar os testes automatizados de duas formas:

1.  **Via .NET CLI:**
    Navegue até a pasta raiz da solução (`.Net8-Auth-And-Testing`) e execute:
    ```bash
    dotnet test
    ```

2.  **Via Visual Studio:**
    Abra a janela do **Test Explorer** (**Menu Test > Test Explorer**). Os testes serão descobertos automaticamente, e você pode executá-los clicando no botão "Run All Tests".
