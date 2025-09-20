# Secure API with Auth & Testing - .NET 8 Portfolio

![.NET](https://img.shields.io/badge/.NET-8-blueviolet) ![C#](https://img.shields.io/badge/C%23-11-blue) ![xUnit](https://img.shields.io/badge/Tests-xUnit-green) ![JWT](https://img.shields.io/badge/Auth-JWT-red) ![Clean Architecture](https://img.shields.io/badge/Architecture-Clean-orange)

This repository contains a complete RESTful API featuring a robust token-based authentication and authorization system using JWT. A key highlight of this project is the comprehensive suite of automated integration tests that validate the security and functionality of the API, ensuring its reliability.

Built with .NET 8, this project demonstrates a professional approach to creating secure and verifiable backend services.

## 🚀 Concepts and Technologies Applied

This project showcases a wide range of essential backend development skills:

* **Security & Authentication:**
    * **ASP.NET Core Identity:** For secure user and password management, including hashing and storing user data.
    * **JWT (JSON Web Token) Authentication:** Implementation of a stateless, token-based authentication flow. Includes endpoints for user registration and login, and token generation via a dedicated `TokenService`.
    * **Authorization Middleware:** Configuration of the `JwtBearer` middleware to validate tokens on incoming requests.
    * **Protected Endpoints:** Use of the `[Authorize]` attribute to secure specific API resources, making them accessible only to authenticated users.

* **Automated Testing (xUnit):**
    * **Integration Testing:** A dedicated test project (`SecureApi.Tests`) that validates the API's behavior from end to end.
    * **`WebApplicationFactory`:** Utilization of an in-memory test server to make real HTTP requests to the API without needing to host it.
    * **In-Memory SQLite Database:** Configuration of a custom `WebApplicationFactory` to ensure each test run uses a clean, isolated, in-memory database, guaranteeing test atomicity and reliability.
    * **Security Testing:** Tests that specifically prove the security rules are working, verifying that endpoints return `401 Unauthorized` for requests without a token and `200 OK` for requests with a valid token.

* **Architecture & Best Practices:**
    * **Clean Architecture & SOLID:** A layered architecture (Controller, Service, Repository) that adheres to SOLID principles for maintainable and scalable code.
    * **Repository Pattern & Dependency Injection:** Abstraction of data access and extensive use of DI for a decoupled and testable codebase.
    * **Swagger/OpenAPI:** Configuration of Swagger to support JWT authentication, allowing for easy manual testing of protected endpoints via the "Authorize" button.

## 📋 API Endpoints

The API exposes the following endpoints:

| Verb     | Route                 | Description                        | Security             |
| :------- | :-------------------- | :--------------------------------- | :------------------- |
| `POST`   | `/api/Auth/register`  | Registers a new user.              | **Public** |
| `POST`   | `/api/Auth/login`     | Authenticates a user and returns a JWT. | **Public** |
| `GET`    | `/api/Products`       | Lists all products.                | **Protected (Requires Token)** |

## ⚙️ How to Run the Project

### Prerequisites
* [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* Git

### Steps

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/SEU-USUARIO/.Net8-Auth-And-Testing.git](https://github.com/SEU-USUARIO/.Net8-Auth-And-Testing.git)
    ```
    (Remember to replace `SEU-USUARIO` with your GitHub username)

2.  **Navigate to the project folder:**
    ```bash
    cd .Net8-Auth-And-Testing/SecureApi
    ```

3.  **Prepare the Database (First time only):**
    This command creates the `secureapi.db` database file with the Identity tables.
    ```bash
    dotnet ef database update
    ```
    > **Note:** If you are using Visual Studio's Package Manager Console, use the command `Update-Database` instead. If the `dotnet ef` command is not found in your terminal, you may need to install it globally with `dotnet tool install --global dotnet-ef`.

4.  **Run the application:**
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

![.NET](https://img.shields.io/badge/.NET-8-blueviolet) ![C#](https://img.shields.io/badge/C%23-11-blue) ![xUnit](https://img.shields.io/badge/Testes-xUnit-green) ![JWT](https://img.shields.io/badge/Auth-JWT-red) ![Arquitetura Limpa](https://img.shields.io/badge/Arquitetura-Clean-orange)

Este repositório contém uma API RESTful completa com um sistema robusto de autenticação e autorização baseado em tokens JWT. Um destaque do projeto é a suíte abrangente de testes de integração automatizados que validam a segurança e a funcionalidade da API, garantindo sua confiabilidade.

Construído com .NET 8, este projeto demonstra uma abordagem profissional para a criação de serviços de backend seguros e verificáveis.

## 🚀 Conceitos e Tecnologias Aplicadas

Este projeto demonstra uma vasta gama de habilidades essenciais para o desenvolvimento backend:

* **Segurança e Autenticação:**
    * **ASP.NET Core Identity:** Para gerenciamento seguro de usuários e senhas, incluindo hashing e armazenamento de dados de usuário.
    * **Autenticação JWT (JSON Web Token):** Implementação de um fluxo de autenticação stateless baseado em token. Inclui endpoints para registro e login de usuários, e geração de token via um `TokenService` dedicado.
    * **Middleware de Autorização:** Configuração do middleware `JwtBearer` para validar tokens em requisições recebidas.
    * **Endpoints Protegidos:** Uso do atributo `[Authorize]` para proteger recursos específicos da API, tornando-os acessíveis apenas a usuários autenticados.

* **Testes Automatizados (xUnit):**
    * **Testes de Integração:** Um projeto de teste (`SecureApi.Tests`) dedicado a validar o comportamento da API de ponta a ponta.
    * **`WebApplicationFactory`:** Utilização de um servidor de teste em memória para fazer requisições HTTP reais à API sem a necessidade de hospedá-la.
    * **Banco de Dados SQLite em Memória:** Configuração de uma `WebApplicationFactory` customizada para garantir que cada execução de teste utilize um banco de dados limpo, isolado e em memória, garantindo a atomicidade e confiabilidade dos testes.
    * **Testes de Segurança:** Testes que provam especificamente que as regras de segurança estão funcionando, verificando que endpoints retornam `401 Unauthorized` para requisições sem token e `200 OK` para requisições com um token válido.

* **Arquitetura e Boas Práticas:**
    * **Arquitetura Limpa & SOLID:** Uma arquitetura em camadas (Controller, Service, Repository) que adere aos princípios SOLID para um código manutenível e escalável.
    * **Padrão de Repositório & Injeção de Dependência:** Abstração do acesso a dados e uso extensivo de DI para um código desacoplado e testável.
    * **Swagger/OpenAPI:** Configuração do Swagger para suportar autenticação JWT, permitindo testes manuais fáceis de endpoints protegidos através do botão "Authorize".

## 📋 Endpoints da API

A API expõe os seguintes endpoints:

| Verbo    | Rota                  | Descrição                                 | Segurança                     |
| :------- | :-------------------- | :---------------------------------------- | :---------------------------- |
| `POST`   | `/api/Auth/register`  | Registra um novo usuário.                 | **Público** |
| `POST`   | `/api/Auth/login`     | Autentica um usuário e retorna um JWT.    | **Público** |
| `GET`    | `/api/Products`       | Lista todos os produtos.                  | **Protegido (Requer Token)** |

## ⚙️ Como Executar o Projeto

### Pré-requisitos
* [.NET 8 SDK](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)
* Git

### Passos

1.  **Clone o repositório:**
    ```bash
    git clone [https://github.com/SEU-USUARIO/.Net8-Auth-And-Testing.git](https://github.com/SEU-USUARIO/.Net8-Auth-And-Testing.git)
    ```
    (Lembre-se de substituir `SEU-USUARIO` pelo seu nome de usuário do GitHub)

2.  **Navegue até a pasta do projeto:**
    ```bash
    cd .Net8-Auth-And-Testing/SecureApi
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
