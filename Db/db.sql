--tabla categoria
create table category(
	idcategory integer primary key identity,
	name varchar(50) not null unique,
	description_category varchar(256) null,
	registration_date date not null,
	condition bit default(1)
);
--Tabla articulo
create table article(
	idarticle integer primary key identity,
	idcategory integer not null,
	bar_code varchar(50) null,
	sku_code varchar(50) null,
	product_name varchar(100) not null unique,
	supplier_code varchar(50) null,
	supplier varchar(50) null,
	product_description varchar(256),
	purchase_price decimal(11,2) not null,
	unit_measure varchar(50) null,
	tax decimal(11,2) not null,
	sale_price decimal(11,2) null,
	classification_product varchar(50) not null,
	invoice_number varchar(50) not null,
	maximum_product integer not null,
	registration_date date not null,
	condicion bit default(1),
	FOREIGN KEY (idcategory) REFERENCES category(idcategory)
);

--Tabla persona
create table person(
	idperson integer primary key identity,
	type_person varchar(20) not null,
	first_name varchar(100) not null,
	second_name varchar(100) not null,
	first_surname varchar(100) not null,
	second_surname varchar(100) not null,
	dpi varchar(100) not null,
	document_type varchar(20) null,
	address_person varchar(100) null,
	phone varchar(20) null,
	email varchar(50) null
);


--Tabla rol
create table rol(
	idrol integer primary key identity,
	rol_name varchar(30) not null,
	rol_descripcion varchar(100) null,
	condition bit default(1)
);

--Tabla usuario
create table users(
	iduser integer primary key identity,
	idrol integer not null,
	first_name varchar(100) not null,
	second_name varchar(100) not null,
	first_surname varchar(100) not null,
	second_surname varchar(100) not null,
	document_type varchar(20) null,
	dpi varchar(20) null,
	address_user varchar(70) null,
	telefono varchar(20) null,
	email varchar(50) not null,
	password_hash varbinary not null,
	password_salt varbinary not null,
	condition bit default(1),
	FOREIGN KEY (idrol) REFERENCES rol (idrol)
);

--Tabla ingreso
create table income(
	idincome integer primary key identity,
	idsupplier integer not null,
	iduser integer not null,
	invoice_number varchar(20) not null,
	registration_date date null,
	tax decimal (11,2) not null,
	total decimal (11,2) not null,
	income_statement varchar(20) not null,
	FOREIGN KEY (idsupplier) REFERENCES person (idperson),
	FOREIGN KEY (iduser) REFERENCES users (iduser)
);

--Tabla detalle_ingreso
create table income_detail(
	idincome_detail integer primary key identity,
	idincome integer not null,
	idarticle integer not null,
	quantity integer not null,
	income_description varchar(100),
	sku_code varchar(50) null,
	price decimal(11,2) not null,
	unit_measure varchar(50) null,
	FOREIGN KEY (idincome) REFERENCES income (idincome) ON DELETE CASCADE,
	FOREIGN KEY (idarticle) REFERENCES article (idarticle)
);