# Projeto para Internal Talent

### Requisitos

> Criar uma API para fazer um CRUD ( o CRUD mais lindo da vida).    

### Deve haver os seguintes pre requisitos:

* Utilizar os seguintes tipos primitivos (int, bool, datetime, string, arrays (Lista ou Cole��es))
* Ter 1 exemplo de cada pilar de OOP
* Ter 1 exemplo de Design Pattern (Criação, Comportamento ou estrutura)
* Ter um relacionamento entre os objetos (1:1 ou 1:n ou n:n)
* Utilizar um ORM
* Ter um teste de unidade.
* Utlizar o Swagger para documentar a API
* Criar um README.md
* Codigo precisa estar versionado no Github
* Precisa estar fazendo o build através do Github Actions (Continuos Integration)
* Utilizar Conventional Commits

---

Estou usando o Banco de Dados SQL Server em Docker. 
Para realizar a download para imagem e rodar o container, execute o comando abaixo no PowerShell: 

```
docker run `
-e "ACCEPT_EULA=Y" `
-e "SA_PASSWORD=Bruno@123" `
-e MSSQL_PID=Developer `
-p 1433:1433 `
-d mcr.microsoft.com/mssql/server:2022-latest
```
Você pode validar a coneção com seu Banco de Dados com um CLient de sua preferência. (Management Studio, Azure Studio, Dbeaver).

```
Server Name: localhost, 1433
Authentication: SQL Server Authnetication
User Name: sa
Password: Bruno@123
```
Após disponíbilização do Banco de Dados, precisamos realizar o Migrations. Para isso, execute o comando abaixo.

```
dotnet ef migrations add alterStudent --project .\src\School.API\
```

Na sequência, devemos efetivar as alterações
```
dotnet ef migrations add alterStudent --project .\src\School.API\
```
---

Nesse projetos utilizamos 3 Padrões de Projetos.

* Facade
* Strategy
* Singleton

---

> Facade [Estrutural]

Padrão de projeto que tem por objetivo centralizar e esconder subsistemas e suas implementações para o Cliente. Agindo com uma FACHADA (Facade).

---
> Strategy [Comportamento]

Padrão de projeto que permite a execução de uma família de algoritmos, onde são executados de modo independente e seletivo.

---
> Singleton [Criação]

Padrão de projeto que garante que uma classe específica só possua uma única instância. 
