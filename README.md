# Atividade - API Hexagonal

**Autor:** Mateus Amaro  
**RA:** 2015116  

## Banco de Dados
- **Plataforma:** .NET 8 / C#
- **ORM:** Entity Framework Core
- **Banco de Dados:** MySQL (Rodando atrav√©s do **XAMPP**)
- **Documenta√ß√£o da API:** Swagger

O banco de dados utilizado na aplica√ß√£o foi o **MySQL**. Para facilitar o uso do servidor de banco relacional localmente, optou-se pela utiliza√ß√£o do pacote **XAMPP**.

## Como executar o projeto localmente

### 1. Pr√©-requisitos
- Ter o [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) instalado.
- Ter o [XAMPP](https://www.apachefriends.org/pt_br/index.html) instalado.

### 2. Configurando o Banco de Dados (XAMPP)
1. Abra o **XAMPP Control Panel**.
2. Inicie os m√≥dulos **Apache** e **MySQL** clicando em `Start`.
3. Certifique-se de que a porta `3306` (padr√£o do MySQL) est√° liberada.

### 3. Configura√ß√µes da API
No arquivo `appsettings.json` ou `appsettings.Development.json` localizado na raiz do projeto, temos a string de conex√£o configurada para o ambiente local:
```json
"ConnectionStrings": {
  "Develop": "server=localhost; port=3306; database=apihexagonal; user=root; password=; Persist Security Info=False; Convert Zero Datetime=True"
}
```
*Se voc√™ possui uma senha root espec√≠fica no seu XAMPP, basta atualizar o campo `password=`.*

### 4. Criando e Populando o Banco (Migrations)
Com o XAMPP ativado e o MySQL conectado, abra a raiz deste projeto no seu terminal e execute:
```bash
dotnet ef database update
```
Isso criar√° o banco de dados `apihexagonal` e todas as respectivas tabelas para turmas e alunos.

### 5. Executando a Aplica√ß√£o
Ap√≥s as tabelas serem constru√≠das via Entity Framework, inicie a API:
```bash
dotnet run
```
A aplica√ß√£o abrir√° no seu navegador na interface do **Swagger** (ex: `https://localhost:7XXX/swagger/index.html`), a partir de onde voc√™ poder√° testar todas as rotas de manipula√ß√£o (GET/POST) do fluxo da aplica√ß√£o.

## DocumentaÁ„o Visual (Swagger e XAMPP)

Abaixo est„o as imagens da pasta FotosPOSTMAN-SWAGGER, demonstrando o funcionamento de cada etapa:

### Banco de Dados Local
- **Banco-de-dados-Xampp.jpeg**: Demonstra a listagem de registros e criaÁ„o das tabelas no MySQL integrado via XAMPP.

### OperaÁıes de Turma
- **Turma-PostClasses.jpeg**: Demonstra o cadastro de uma nova Turma (POST) documentado no Swagger.
- **Turma-ListClasses.jpeg**: Demonstra a listagem geral das turmas cadastradas (GET).

### OperaÁıes de Aluno
- **Aluno-Post-Aluno.jpeg**: Demonstra a criaÁ„o de um Aluno matriculado a uma turma (POST) via Swagger.
- **Aluno-PostAluno@faculdade.edu.jpeg**: Demonstra o teste validando as regras de negÛcio de e-mail limitadas ao domÌnio \@faculdade.edu\ no cadastro.
- **Aluno-ListaAluno.jpeg**: Traz todos os alunos j· criados listados em uma chamada GET genÈrica de listar.
- **Aluno-GetAluno-1.jpeg**: Traz as informaÁıes de um determinado Aluno baseado em uma busca com identificador ID = 1.

