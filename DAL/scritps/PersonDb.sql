
Create table Persona(
		PersonaId int primary key identity(1,1),
		Nombre varchar(30),
		Sexo varchar(3)
);

Create table PersonaTelefono(
	PersonaTelefonoId int primary key identity(1,1),
	PersonaId int foreign key references Persona(PersonaId),
	TipoTelefono varchar(10),
	Telefono varchar(15)
);

select * from Persona