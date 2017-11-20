Create database AgendaContatos;

Use AgendaContatos;

Create table TipoContato (
	codigoTipoContato int not null primary key auto_increment,
	descricao varchar(200) 
);

create table Contato (
	codigoContato int not null primary key auto_increment,
	nome varchar(100),
	endereco varchar(100),
	bairro varchar(100),
	cidade varchar(100),
	estado varchar(100),
	telefone varchar(100),
    codigoTipoContato int not null,
	constraint contato_tipocontato_fk foreign key (codigoContato) references TipoContato(codigoTipoContato)
);

INSERT INTO TipoContato (descricao) VALUES
( 'Familia'),
( 'Amigos'),
('Comércio'),
('Novinhas');

INSERT INTO Contato (nome, endereco, bairro, cidade, estado, telefone, codigoTipoContato) VALUES
( 'Juliane', 'Rua Manoel Gouveia', '206', 'Matão','SP', '3382-7551', 1),
( 'João', 'Rua Carlos Gomes', '126', 'Matão','SP', '99155-2630', 2),
( 'Marcelinho Calhas', 'Rua João Cechetto', '291', 'Matão','SP', '3384-7569', 3),
( 'Giovanna', 'Av Mastropietro', '1024', 'Matão','SP', '99155-9648', 4);

