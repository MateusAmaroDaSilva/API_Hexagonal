# Atividade - API Hexagonal

**Autor:** Mateus Amaro  
**RA:** 2015116  

## Descrição do Projeto
Este projeto tem como objetivo desenvolver uma API em C# (.NET 8) para gerenciamento de alunos, seguindo rigidamente os princípios da **Arquitetura Hexagonal (Ports and Adapters)**. O foco central é o total desacoplamento da lógica de negócios (Domain/Application) em relação a camadas de tecnologias externas (Banco de Dados, Frameworks Web, etc.).

As principais regras de negócio exigidas contemplam a validação dos alunos na matrícula (Nome preenchido e com limite de caracteres, e-mail padronizado `@faculdade.edu` e unicidade de e-mail no ato do cadastro).

## Tecnologias e Banco de Dados
- **Plataforma:** .NET 8 / C#
- **ORM:** Entity Framework Core
- **Banco de Dados:** MySQL (Rodando através do **XAMPP**)
- **Documentação da API:** Swagger

O banco de dados utilizado na aplicação foi o **MySQL**. Para facilitar o uso do servidor de banco relacional localmente, optou-se pela utilização do pacote **XAMPP**.

## Como executar o projeto localmente

### 1. Pré-requisitos
- Ter o [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) instalado.
- Ter o [XAMPP](https://www.apachefriends.org/pt_br/index.html) instalado.

### 2. Configurando o Banco de Dados (XAMPP)
1. Abra o **XAMPP Control Panel**.
2. Inicie os módulos **Apache** e **MySQL** clicando em `Start`.
3. Certifique-se de que a porta `3306` (padrão do MySQL) está liberada.
4. *(Opcional)* Você pode gerenciar o banco através do phpMyAdmin (`http://localhost/phpmyadmin`) caso possua alguma necessidade visual, porém as tabelas serão geradas automaticamente pelas *Migrations* do Entity Framework.

### 3. Configurações da API
No arquivo `appsettings.json` ou `appsettings.Development.json` localizado na raiz do projeto, temos a string de conexão configurada para o ambiente local:
```json
"ConnectionStrings": {
  "Develop": "server=localhost; port=3306; database=apihexagonal; user=root; password=; Persist Security Info=False; Convert Zero Datetime=True"
}
```
*Se você possui uma senha root específica no seu XAMPP, basta atualizar o campo `password=`.*

### 4. Criando e Populando o Banco (Migrations)
Com o XAMPP ativado e o MySQL conectado, abra a raiz deste projeto no seu terminal e execute:
```bash
dotnet ef database update
```
Isso criará o banco de dados `apihexagonal` e todas as respectivas tabelas para turmas e alunos.

### 5. Executando a Aplicação
Após as tabelas serem construídas via Entity Framework, inicie a API:
```bash
dotnet run
```
A aplicação abrirá no seu navegador na interface do **Swagger** (ex: `https://localhost:7XXX/swagger/index.html`), a partir de onde você poderá testar todas as rotas de manipulação (GET/POST) do fluxo da aplicação.
