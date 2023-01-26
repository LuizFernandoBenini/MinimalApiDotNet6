# Título do projeto

Projeto de estudo sobre Minimal APIs usando .Net 6.

## 🚀 Começando

Esse projeto foi desenvolvido como um projeto de estudos sobre Minimal APIs inicialmente desenvolvido em .Net 6 seguindo o vídeo do canal [Les Jackson](https://www.youtube.com/watch?v=5YB49OEmbbE&t=7687s)


### 📋 Pré-requisitos

Para execução desse projeto foram utilizados os seguintes pacotes instalados no gerenciador de pacotes Nuget

```
AutoMapper.Extensions.Microsoft.DependencyInjection
Microsoft.EntityFrameWorkCore
Microsoft.EntityFrameWorkCore.Design
Microsoft.EntityFrameWorkCore.SqlServer
```

Na base de dados foi utilizado uma instancia do SqlServer e foi criada uma base de dados de nome "MinimalApiDatabase" 
Nesse projeto a instância é executada através do docker podendo ter sua imagem baixada pelo arquivo "docker-compose.yaml"
Caso não tenha o docker instalado é possível seguir o seguinte [Tutorial](https://docs.docker.com/get-started/)

### 🔧 Configuração e Instalação

Durante a criação do projeto foram executados os seguintes passos para viabilizar o desenvolvimento do mesmo:

- Instalar o [.Net 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) para que possa utilizar o .Net 6 no projeto. 
- Instalar [Wsl2 (Docker)](https://learn.microsoft.com/pt-br/windows/wsl/install). 
- Instalar o [Docker Desktop (Docker)](https://docs.docker.com/desktop/install/windows-install/).
- Executar a instancia do SqlServer via [docker-compose.yaml (Docker)](https://docs.docker.com/compose/gettingstarted/). 
- Utilizar o comando de "update database" do entity para criar as tabelas mapeadas nos modelos. 
- (Opcional) Instalar o SqlServer management ou um conector de bancos de dados para manipulação dos dados. No meu caso eu usei o [DBeaver](https://dbeaver.io/download/).

As variáveis de da string de conexão referente a credenciais da base de dados foram criadas com o comando [dotnet user-secrets](https://learn.microsoft.com/pt-br/aspnet/core/security/app-secrets?view=aspnetcore-7.0&tabs=windows) inserindo assim os dados de UserId e Password

## 🛠️ Construído com

Para desenvolvimento dessa aplicação foram utilizadas as seguintes ferramentas

* [.Net 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) 
* [SqlServer](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) 
* [Docker](https://docs.docker.com/get-started/) 


### ⌨️ Material de estudo 
* [Criando uma Minimal API](https://learn.microsoft.com/pt-br/aspnet/core/tutorials/min-web-api?view=aspnetcore-6.0&tabs=visual-studio)
* [Aprofundando nas Minimal APIs](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-6.0)