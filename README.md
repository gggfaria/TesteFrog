# Teste prático para back-end .net

Para rodar o projeto basta utilizar o docker com o comando:

```
docker-compose up --build

```

Irá subir a API com Swagger e uma base de dados Postgres

Url para acesso ao Swagger é http://localhost/swagger/index.html





a) Implementar mecanismo de autorização e autenticação;
 - Existem dois tipos de acesso para o usuário: ADMIN e PADRAO
 - Utilize usuário pré-criado "gabriel" com a senha "123456" para fazer login como ADMIN

b) A solução de autenticação deverá expirar a cada 5 minutos;
 - Configurado para expirar
   
c) Implementar pelo menos os verbos post, put, get;
 - CRUD para cada uma das tabelas foi criado em controllers:
 - Pessoa;
 - DadosBancarios;
 - Endeereço;
 - Loja.
   
d) Conter recursos de paginação em ao menos uma consulta;
- Consulta de pessoas possui paginação;
  
e) Os dados produzidos deverão ser armazenados no servidor de banco de dados previamente criado em container;
- Estão sendo salvos no container com Postgres, criado usando o script de inicialização contido no projeto;
  
f) Orquestrar a solução final utilizando Docker Compose de modo que inclua todos os
contêineres utilizados;
- Utilizar comando do docker para subir os containers e executar.

  

