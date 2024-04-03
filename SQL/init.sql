create table tb_pessoa
(
    id              uuid PRIMARY KEY,
    nome            varchar            not null,
    cpf             varchar            not null,
    data_nascimento date            not null,
    ativo           boolean            not null,
    data_criacao    date default now() not null,
    usuario         varchar not null,
    senha           varchar not null,
    permissao       varchar
);

create table tb_endereco
(
    id          uuid        not null,
    id_pessoa   uuid        not null
        constraint tb_endereco_tb_pessoa_id_fk
            references tb_pessoa,
    uf          varchar(2)  not null,
    cidade      varchar     not null,
    logradouro  varchar     not null,
    bairro      varchar(500),
    numero      varchar(20) not null,
    complemento varchar(100),
    data_criacao    date default now() not null
);

create table tb_dados_bancarios
(
    id           uuid        not null
        constraint tb_dados_bancarios_pk
            primary key,
    id_pessoa    uuid        not null
        constraint tb_dados_bancarios_tb_pessoa_id_fk
            references tb_pessoa,
    codigo       varchar     not null,
    agencia      varchar     not null,
    conta        varchar     not null,
    digito_conta varchar(20) not null,
    data_criacao    date default now() not null
);


create table tb_loja
(
    id            uuid               not null
        constraint tb_loja_pk
            primary key,
    pessoa_id     uuid               not null
        constraint tb_loja_tb_pessoa_id_fk
            references tb_pessoa,
    nome_fantasia varchar            not null,
    razao_social  varchar            not null,
    cnpj          varchar            not null,
    data_abertura date               not null,
    data_criacao  date default now() not null
);


insert into tb_pessoa (id, nome, cpf, data_nascimento, ativo, data_criacao, usuario, senha, permissao)
values ('23a6005e-eb69-4790-af5d-3d5b984047df', 'Gabriel', '54345354','1973-01-01',true, now(), 'gabriel',
        'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'ADMIN');

/*senha 123456*/
