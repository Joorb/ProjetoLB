create database EcomLoja;
use Ecomloja;

create table produtos(
Id int primary key auto_increment,
Nome varchar(40),
Descricao varchar(40),
Preco decimal(10,2),
ImageUrl varchar(255),
Estoque int
);

create table pedido(
Id int primary key auto_increment ,
DataPedido datetime,
Total decimal(10,2),
Status varchar(50),
Endereco varchar(100),
FormaPagamento varchar(100),
Frete decimal (10,2)
);


create table itemPedido(
Id int primary key auto_increment ,
PedidoId int,
ProdutoId int,
Quantidade int,
PrecoUnitario decimal(10,2)
);

INSERT INTO produtos (Nome, Descricao, Preco, ImageUrl, Estoque)
VALUES ('Game Boy Advance', 'Videogame Game Boy Advance', 799.99, '/img/prod1.jpg', 10),
('Labubu', 'Boneco Labubu Marrom', 30.00, '/img/prod2.jpeg', 10),
('Kit Bobbie Goods + 120 canetas', 'Kit Bobbie Goods + 120 canetas ', 109.90, '/img/prod3.webp', 20),
('Pop it', 'Pop it colorido Among Us', 19.99, '/img/prod4.webp', 15),
('Fidget Spiner', 'Brinquedo Fidget Spinner verde', 8.00, '/img/prod5.webp', 25),
('Boneco José Comilão', 'Boneco José Comilão', 94.40, '/img/prod6.webp', 30);

select * from produtos;
select * from pedido;
select * from itemPedido;