# 🚀 SkillBridge API

API RESTful desenvolvida em ASP.NET Core 9 para o desafio **"O Futuro Precisa do Seu Trabalho"**.

A solução foca em preparar empresas e colaboradores para o futuro, permitindo a gestão de **Planos de Desenvolvimento Individuais (PDIs)** focados em competências emergentes, preparando as pessoas para "carreiras que ainda nem existem".

---

## 👥 Integrantes

* **Fabrizio Maia** - [RM551869]
* **Victor Asfur** - [RM551684]
* **Vitor Shimizu** - [RM550390]

---

## 🎯 Funcionalidades

A **v1** da API permite o gerenciamento completo (CRUD) de Colaboradores e seus respectivos Planos de Desenvolvimento.

### Colaboradores
* `POST /api/v1/colaboradores`: Cadastra um novo colaborador.
* `GET /api/v1/colaboradores`: Lista todos os colaboradores (incluindo seus planos).
* `GET /api/v1/colaboradores/{id}`: Busca um colaborador específico pelo seu ID.

### Planos de Desenvolvimento (PDIs)
* `POST /api/v1/planosdesenvolvimento`: Cria um novo plano para um colaborador.
* `GET /api/v1/planosdesenvolvimento`: Lista todos os planos existentes.
* `GET /api/v1/planosdesenvolvimento/{id}`: Busca um plano específico pelo seu ID.
* `PUT /api/v1/planosdesenvolvimento/{id}`: Atualiza um plano existente.
* `DELETE /api/v1/planosdesenvolvimento/{id}`: Remove um plano.

---

## 🛠️ Documentação (Tecnologias Utilizadas)

Este projeto foi construído utilizando as seguintes tecnologias:

* **.NET 9**: Framework principal para a construção da API.
* **ASP.NET Core Web API**: Para a criação dos endpoints RESTful.
* **Entity Framework Core 9**: ORM (Object-Relational Mapping) para interação com o banco de dados.
* **SQLite**: Banco de dados relacional leve, utilizado pela facilidade de setup e portabilidade.
* **Swagger (Swashbuckle)**: Para documentação e teste interativo da API.
* **Asp.Versioning.Mvc**: Pacote para implementação do versionamento da API (ex: `/api/v1`).
* **VS Code**: Editor de código principal, com foco no uso de terminal e ferramentas .NET.

---

## ⚙️ Forma de Funcionamento (Como Executar)

Siga os passos abaixo para executar o projeto localmente.

### 1. Pré-requisitos
* [SDK do .NET 9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
* [VS Code](https://code.visualstudio.com/) (ou outro editor de sua preferência)
* [Git](https://git-scm.com/downloads)

### 2. Passos para Execução

1.  **Clone o repositório:**
    ```bash
    git clone [COLE A URL DO SEU REPOSITÓRIO AQUI]
    cd [NOME-DA-PASTA-DO-PROJETO]
    ```

2.  **Navegue até a pasta da API:**
    (Se o seu projeto estiver aninhado, como `SkillBridge.API/SkillBridge.API`)
    ```bash
    cd SkillBridge.API
    ```

3.  **Restaure as ferramentas locais do .NET:**
    (Isso instala o `dotnet-ef` localmente, conforme definimos)
    ```bash
    dotnet tool restore
    ```

4.  **Aplique as migrações do banco de dados:**
    (Este comando cria o arquivo `skillbridge.db` com todas as tabelas)
    ```bash
    dotnet ef database update
    ```

5.  **Execute a aplicação:**
    (O `watch` reinicia a API automaticamente a cada mudança)
    ```bash
    dotnet watch run
    ```

6.  **Acesse a documentação do Swagger:**
    Abra seu navegador e acesse o endereço local informado no terminal (ex: `http://localhost:5123/swagger`). Agora você pode testar todos os endpoints!

---

## 🔀 Fluxo de Dados (Draw.io)

O diagrama abaixo ilustra o fluxo de uma requisição **POST** para a criação de um novo Plano de Desenvolvimento, desde o cliente (Swagger) até a persistência no banco de dados SQLite.

*(O GitHub irá renderizar este bloco de código como um fluxograma)*
```mermaid
graph TD
    A[Cliente (Ex: Swagger)] -- "Requisição POST /api/v1/planos" --> B[API Controller]
    B --> C{Valida os Dados (ModelState)}
    C -- "Válido" --> D[AppDbContext (EF Core)]
    D -- "Gera SQL (INSERT)" --> E[Banco de Dados (SQLite)]
    E -- "Retorna Sucesso" --> D
    D -- "Cria o objeto" --> B
    B -- "Retorna 201 Created" --> A
    C -- "Inválido" --> F[Retorna 400 Bad Request]
    F --> A
```

---

## 📺 Vídeo de Demonstração (Máx. 5 min)

O vídeo abaixo demonstra a API em funcionamento, utilizando a interface do Swagger para executar todas as operações CRUD (Create, Read, Update, Delete) nos endpoints de Colaboradores e Planos, e mostrando o banco de dados sendo atualizado.

**https://www.youtube.com/watch?v=X0UecMj2MWw**
