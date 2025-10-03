# 🚀 Projeto School - API Completa para Gestão Escolar

Bem-vindo ao **School**! Este projeto foi desenvolvido como parte do desafio *Internal Talent* e tem o objetivo de apresentar uma API robusta, moderna e bem estruturada para CRUD de entidades escolares. Aqui você encontra exemplos reais de boas práticas em arquitetura de software, programação orientada a objetos, padrões de projeto, integração contínua e muito mais! 😎

---

## ✨ Principais Funcionalidades

- **API RESTful** completa para gerenciamento de entidades escolares (CRUD 📝).
- Uso de **banco de dados SQL Server** via Docker para fácil setup e portabilidade.
- **Documentação interativa** com Swagger.
- **Testes unitários** para garantir qualidade e confiabilidade das funcionalidades.
- **Integração contínua** com GitHub Actions para builds automáticos.
- Código versionado e organizado segundo as melhores práticas do mercado.
- Uso de **Conventional Commits** para padronização dos commits.
- Implementação de **padrões de projeto** (Facade, Strategy, Singleton).
- Exemplo dos quatro pilares da **Programação Orientada a Objetos** (OOP).
- **Relacionamentos entre objetos** (1:1, 1:n, n:n) utilizando ORM.

---

## 🚦 Pré-requisitos

- [.NET 6+](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/)
- Cliente SQL Server (Management Studio, Azure Data Studio, DBeaver, etc.)

---

## 🐳 Subindo o Banco de Dados com Docker

Execute o comando abaixo no PowerShell para criar um container SQL Server local:

```bash
docker run `
-e "ACCEPT_EULA=Y" `
-e "SA_PASSWORD=Bruno@123" `
-e MSSQL_PID=Developer `
-p 1433:1433 `
-d mcr.microsoft.com/mssql/server:2022-latest
```

Conexão sugerida:
```
Server Name: localhost,1433
Authentication: SQL Server Authentication
User Name: sa
Password: Bruno@123
```

---

## ⚡ Migrations do Banco de Dados

Após iniciar o banco, rode os migrations para criar/atualizar as tabelas:

```bash
dotnet ef migrations add alterStudent --project .\src\School.API\
dotnet ef database update --project .\src\School.API\
```

---

## 🧑‍💻 Padrões de Projeto Utilizados

- **Facade** *(Estrutural)*: Centraliza e esconde subsistemas do cliente, simplificando o uso de funcionalidades complexas.
- **Strategy** *(Comportamental)*: Permite selecionar dinamicamente algoritmos ou comportamentos em tempo de execução.
- **Singleton** *(Criacional)*: Garante que uma classe tenha apenas uma instância, fornecendo um ponto global de acesso.

---

## 🧩 Pilares de Programação Orientada a Objetos (OOP)

O projeto demonstra:
- **Abstração**
- **Encapsulamento**
- **Herança**
- **Polimorfismo**

---

## 🛠️ ORM

Utilização de ORM para mapeamento objeto-relacional e gerenciamento dos relacionamentos entre entidades (1:1, 1:n, n:n), facilitando consultas e manutenção do código.

---

## 🧪 Testes Unitários

> **Destaque!**  
> O projeto contém testes unitários para garantir a qualidade e robustez das principais funcionalidades!  
> Execute os testes com o comando:

```bash
dotnet test
```

Garanta que tudo está funcionando antes de subir suas alterações! ✅

---

## 📖 Documentação com Swagger

Acesse a documentação interativa em:  
`http://localhost:<porta>/swagger`

Explore e teste os endpoints da API diretamente pelo navegador!

---

## 🔄 Integração Contínua

Este projeto utiliza **GitHub Actions** para build e testes automáticos a cada commit, garantindo qualidade contínua! Veja o status das builds diretamente no repositório.

---

## 📋 Checklist de Requisitos Atendidos

- [x] CRUD completo
- [x] Uso de tipos primitivos (int, bool, datetime, string, array)
- [x] 1 exemplo de cada pilar OOP
- [x] 1 exemplo de Design Pattern (criação, comportamento, estrutura)
- [x] Relacionamento entre objetos
- [x] ORM
- [x] Testes unitários
- [x] Swagger
- [x] README.md detalhado
- [x] Código versionado no GitHub
- [x] Build no GitHub Actions
- [x] Conventional Commits

---

## 💡 Como contribuir

Sinta-se à vontade para enviar PRs, abrir issues, sugerir melhorias ou relatar bugs.  
Vamos construir juntos um projeto cada vez melhor! 🤝✨

---

Feito com dedicação por [BrunoSouzza](https://github.com/BrunoSouzza) 🚀
