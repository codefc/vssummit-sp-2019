# vssummit-sp-2019
Repositório contendo o material sobre Feature Toggle apresentado no Visual Studio Summit, 2019, em SP.

# Descrição do projeto

Este projeto tem como objetivo demonstrar uma utilização básica da estratégia de [Feature Toggles](https://martinfowler.com/articles/feature-toggles.html).

Requisitos:
- Visual Studio / Visual Studio Code
- Uma conta no site [Config Cat][http://www.configcat.com] 
- Docker - Se desejar utilizar uma versão da aplicação em contâiner

# Como executar o projeto

Após criada sua conta no site do Config Cat, você poderá obter o Token de acesso para o ambiente desejado. Esta chave deverá ser configurada no projeto através do **appsettings.json** ou utilizando a funcionalidade **secret** do .net core.

## Configurando através do appsettings.json

Basta adicionar mais uma chave conforme o exemplo abaixo:

```json
{
    //...demais chaves
    "ConfigCatKey" : "suachave"
}
```

## App secret

Pelo prompt de comando, acesso o diretório que contém o **cproj** da sua aplicação. Execute o seguinte comando:

```bash
dotnet user-secrets set "ConfigCatKey" "sua chave"
```
Não será necessária outra configuração já que o projeto está configurado para aceitar secrets(em desenvolvimento).

Para maiores detalhes sobre o uso de secrets, consulte a [documentação](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-2.2&tabs=windows).

# Docker

Caso deseje utilizar ou testar a sua aplicação através de containers docker, serão necessários alguns passos - gerar uma imagem docker e executar um container.

## Gerar imagem docker

Para gerar uma imagem docker da aplicação, acesse o dirório **src/FeatureToggle** e execute o comando:

```bash
docker build -t vssummit:1.0 .
```

O comando acima gera uma imagem chamada **vssummit** na tag **1.0**.

> o parâmetro **-t** determina um **nome:tag** para a imagem.

## Executar um container

Para execução de um container, execute o comando:

```bash
docker run -dt -p 8989:80 -e ConfigCatKey=suakey -e ASPNETCORE_ENVIRONMENT=Development vssummit:1.0
```

Neste exemplo, executei a imagem gerada anteriormente e determinei, na variável ambiente **ASPNETCORE_ENVIRONMENT** que estou executando em um ambiente que chamei de **Development**. Você poderá determinar o nome do seu ambiente.

Uma atenção no parâmetro **-p**. Este parâmetro determina a porta de execução do container, sendo o primeiro parâmetro a porta do HOST de execução do container e o seguindo parâmetro, a porta que será executada dentro do container. De forma simples o parâmetro diz: Quando acessar o endereço **http://localhost:8989** na máquina host, estou acessando a porta **80** dentro do container. E justamente a porta **80** dentro do container é onde a aplicação, dentro do container, espera conexões.

> **Dica**
> 
>Como o ConfigCat, em sua versão gratuita, permite a criação de dois ambientes e permite a replicação de toggles para os ambientes, você poderá testar ou sumilar a mesma aplicação em ambientes distintos utilizando a execução de outro container, conforme demonstrado acima, variando a **key** e a variável **ASPNETCORE_ENVIRONMENT**, além da porta de execução do nome container, determinada no parâmetro **-p**.