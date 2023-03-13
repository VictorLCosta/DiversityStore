# API de Gerenciamento de Estoque e Venda de uma Loja de Diversidades

Olá,

Este projeto foi feito para um processo seletivo para uma vaga de emprego. O projeto foi construído em ASP.NET Core e React Typescript.

## API

### Instalação

Para utilizar a API, é necessário ter instalado o ASP.NET Core Runtime 7.0.102 ou superior em seu computador. Você pode baixar e instalar a versão mais recente do [site oficial da Microsoft](https://dotnet.microsoft.com/download/dotnet/7.0).

### Instalando as dependências

Entre na pasta do projeto e instale as dependências:

```bash
cd API
dotnet restore
```

### Iniciando a API

Para iniciar a API, execute o seguinte comando na pasta raiz do projeto:

```bash
dotnet run
```

A API estará disponível em http://localhost:5154.

### Configurando o banco de dados

A API irá inicializar o banco de dados automaticamente e todas as migrações necessárias serão aplicadas e o banco de dados será populado com dados de exemplo.

### Utilização

A API pode ser consumida pelo Swagger ou pelo Postman. Em ambos os casos, é preciso fazer login para poder utilizar as outras operações:

#### Swagger

1. Abra o Swagger da sua API. O Swagger está na URL raiz `http://localhost:5154/`.

2. Ative o endpoint de login e copie o token de autenticação retornado.

3. Clique no botão "Authorize" para abrir a aba.

4. Informe o valor "Bearer [seu-token-de-autenticação]" sem aspas e aperte o botão "Authorize"

5. Se suas credenciais forem válidas, o Swagger adicionará automaticamente o token de autenticação ao cabeçalho de todas as solicitações subsequentes.

#### Postman

1. Abra o Postman.

2. Crie uma nova solicitação para o endpoint de login da sua API.

3. Selecione o método HTTP correto (geralmente POST).

4. Adicione os parâmetros de login necessários (email e senha) no corpo da solicitação.

5. Clique na guia "Headers".

6. Adicione um novo cabeçalho com o nome "Authorization" e o valor "Bearer [seu-token-de-autenticação]". Substitua [seu-token-de-autenticação] pelo token de autenticação retornado pela API.

7. Envie a solicitação.

## Client

Na pasta client deste repositório, há um projeto React TypeScript gerado através do Vite para consumir esta API. Para utilizá-lo, execute os seguintes comandos:

```bash
cd client
npm install
npm run dev
```

O cliente estará disponível em `http://localhost:5173`
