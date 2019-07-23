# Copa Filmes

Copa do Mundo de filmes

## Como usar:

### [Recomendado] Instalar usando o [docker compose](https://docs.docker.com/compose/install/)

```
$ git clone https://github.com/afranioce/CopaFilmes.git
$ cd CopaFilmes
$ docker-compose up
```

Abra o link [http://localhost:8080](http://localhost:8080)

### Instalar manualmente

#### 1. Baixar e Instalar dependencias

Instalar a versão 3 do [.NET Core SDK](https://dotnet.microsoft.com/download/dotnet-core/3.0)
Instalar a versão 10 ou superior [Node js](https://cli.angular.io/)
Instalar o [Angular cli](https://cli.angular.io/)

#### 2. Baixar o repositorio e instalar os pacotes

```
$ git clone https://github.com/afranioce/CopaFilmes.git
$ cd CopaFilmes
$ cd frontend
$ npm install
$ cd ..
```

#### 3. Rodar os serviços (terminais separados)

##### Frontend

```
$ cd frontend
$ ng serve
```

##### Backend

```
$ cd backend
$ dotnet run -p ./src/MovieCup.Api
```

### Pronto

Agora é só abrir o link [http://localhost:4200](http://localhost:4200)

## Tecnologias usadas

* Anuglar 8
* Material Angular 8
* ASP.NET Core 3
* FluentValidator
* .NET Core Nativo DI
* Docker

## Arquitetura

* SOLID e Clean Code
* Injeção de dependencias (DI)
* Domain Driven Design (DDD)
* CQRS
* Repository
