--CREATE DATABASE  agdevcom_examenCrecer;
--GO

use agdevcom_examenCrecer;
GO

create table especialidad(idespecialidad int primary key identity
,nombreespecialidad varchar(150)
,estado int);
GO

create table medico (idmedico int primary key identity
,nombre varchar(50)
,especialidad int foreign key references especialidad(idespecialidad)
,estado int);
GO



create table paciente(idpaciente int primary key identity
,paciente varchar(50)
,direccion varchar(150)
,telefono varchar(10)
,estado int);
GO

create table diagnostico(iddiagnostico int primary key identity
,paciente int foreign key references paciente(idpaciente)
,medico int foreign key references medico(idmedico)
,diagnostico varchar(max)
,receta varchar(max)
,fechaconsulta datetime
,estado int);
GO

create table cita (idcita int primary key identity
,paciente int foreign key references paciente(idpaciente)
,medico int  foreign key references medico(idmedico)
,fecha date
,hora time
,estado int);
GO

insert into especialidad(nombreespecialidad,estado) values('Dermatologo',1);
insert into especialidad(nombreespecialidad,estado) values('Ginecólogo',1);
insert into especialidad(nombreespecialidad,estado) values('Oftalmólogo',1);
insert into especialidad(nombreespecialidad,estado) values('Pediatra',1);
insert into especialidad(nombreespecialidad,estado) values('Psiquiatra',1);
GO

insert into medico(nombre,especialidad,estado) values('Jose Maria Vertiz',1,1);
insert into medico(nombre,especialidad,estado) values('Manuel Altamirano',2,1);
insert into medico(nombre,especialidad,estado) values('Enrrique Cabrera',3,1);
insert into medico(nombre,especialidad,estado) values('Jose Martinez',4,1);
insert into medico(nombre,especialidad,estado) values('Francisco Becerra',5,1);
insert into medico(nombre,especialidad,estado) values('Carlos Agular',6,1);
GO

insert into paciente(paciente,direccion,telefono,estado) values('Paciente 1','Direccion 1','111111111',1);
insert into paciente(paciente,direccion,telefono,estado) values('Paciente 2','Direccion 1','111111111',1);
insert into paciente(paciente,direccion,telefono,estado) values('Paciente 3','Direccion 1','111111111',1);
insert into paciente(paciente,direccion,telefono,estado) values('Paciente 4','Direccion 1','111111111',1);
insert into paciente(paciente,direccion,telefono,estado) values('Paciente 5','Direccion 1','111111111',1);
insert into paciente(paciente,direccion,telefono,estado) values('Paciente 6','Direccion 1','111111111',1);
GO

create procedure sp_nuevaCita
(@idPaciente int
,@idmedico int
,@fecha date
,@hora time)
as
BEGIN
	if(SELECT count(*) FROM cita where medico = @idmedico and fecha = @fecha and hora = @hora and estado = 1)>0
	begin
		insert into cita(paciente,medico,fecha,hora) values(@idPaciente,@idmedico,@fecha,@hora);
		return 'La cita se agendo correctamente';
	end
	else
	begin
		return 'Medico no disponible'
	end
END
GO;

create procedure sp_diagnostico
(@paciente int
,@medico int
,@diagnostico varchar(max)
,@receta varchar(max)
,@fechaconsulta datetime
,@estado int)
as
BEGIN
	insert into diagnostico(paciente,medico,diagnostico,receta,fechaconsulta) values(@paciente,@medico,@diagnostico,@receta,@fechaconsulta);
END
GO

create procedure sp_lista_medico
as
begin
select t1.idmedico,t1.nombre, t2.nombreespecialidad from medico t1, especialidad t2 where t2.idespecialidad = t1.especialidad 
end
go

create procedure sp_lista_paciente
as
begin
 select idpaciente 
,paciente 
,direccion 
,telefono 
,estado  from paciente  where estado=1;
end
go