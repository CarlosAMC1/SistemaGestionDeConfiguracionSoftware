CREATE DATABASE DB_SGCSW
Go 
USE DB_SGCSW
GO

--- Tabla TipoUsuario
create table TIPO_USUARIO
(
    ID_TIPOUSUARIO int identity
        primary key,
    DESCRIPCION    varchar(20)
)
go
-- Tabla usuario
create table USUARIO
(
    ID_USUARIO     int identity primary key,
    NOMBRE         varchar(60) not null,
    APELLIDO       varchar(60) not null,
    FECHA_CREACION datetime,
    CODIGO         varchar(15),
    TELEFONO       varchar(15),
    EMAIL          varchar(50) not null,
    PASSWORD       varchar(80) not null,
    ID_TIPOUSUARIO int         not null
        constraint fk_USUARIO_IDTIPOUSUARIO
            references TIPO_USUARIO,
    ESTADO         bit
)
go


create table METODOLOGIA
(
    ID_METODOLOGIA int identity
        primary key,
    DESCRIPCION    varchar(20),
    ESTADO         bit
)
go

create table PROYECTO
(
    ID_PROYECTO     int identity
        constraint PK__PROYECTO__6D6606937BB58B76
            primary key,
    NOMBRE          varchar(50) not null,
    DESCRIPCION     varchar(60) not null,
    ID_CLIENTE      int         not null
        constraint fk_PROYECTO_ID_USUARIO
            references USUARIO,
    ID_METODOLOGIA  int         not null
        constraint fk_PROYECTO_ID_METODOLOGIA
            references METODOLOGIA,
    ESTADO          bit,
    ID_JEFEPROYECTO int         not null
        constraint fk_PROYECTO_ID_JEFEPROYECTO
            references USUARIO,
    FECHA_INICIO    date        not null,
    FECHA_FIN       date        not null
)
go


--- lo nuevoooooooooo
create table MIEMBRO
(
    ID_MIEMBRO    int identity primary key,
    ID_PROYECTO         int,
	NOMBRE			varchar(50),
    ROL				varchar(50) not null,
    RESPONSABILIDAD       varchar(50),
    FOREIGN KEY (ID_PROYECTO) REFERENCES PROYECTO(ID_PROYECTO)
)
go

create table SOLICITUDCAMBIO
(
    ID_SOLICITUD     int identity primary key,
    FECHA_INICIO         date not null,
	FECHA_FIN        date not null,
    DESCRIPCION		text not null,
    TIPO_CAMBIO       varchar(50),
    ID_MIEMBRO		int not null,
    FOREIGN KEY (ID_MIEMBRO) REFERENCES MIEMBRO(ID_MIEMBRO)
)
go
create table ECS
(
    ID_ECS    int identity primary key,
	DESCRIPCION VARCHAR(50)
)
go
create table ETAPA
(
    ID_ETAPA   int identity primary key,
	DESCRIPCION VARCHAR(50)
)
go
create table PLANTILLAECS
(
    ID_PLANTILLAECS    int identity primary key,
	ID_PROYECTO		int not null,
    PORCENTAJE_AVANCE  int  not null,
	FECHA_INICIO    date not null,
	FECHA_FIN        date not null,
	TAREA_FINALIZADA      varchar(50),
	TAREA_ENPROCESO      varchar(50),
	TAREA_ABIERTA     varchar(50),
	ID_METODOLOGIA      INT ,
	ID_FASE    INT,
	VERSION_ACTUAL       varchar(50),
	ID_ECS INT ,
	ID_MIEMBRO     INT,
	FOREIGN KEY (ID_METODOLOGIA) REFERENCES METODOLOGIA(ID_METODOLOGIA),
    FOREIGN KEY (ID_FASE) REFERENCES ETAPA(ID_ETAPA),
	FOREIGN KEY (ID_MIEMBRO) REFERENCES MIEMBRO(ID_MIEMBRO),
	FOREIGN KEY (ID_ECS) REFERENCES ECS(ID_ECS)
)
go

create table CRONOGRAMA
(
    ID_CRONOGRAMA    int identity primary key,
	ID_PROYECTO		int not null,
    PORCENTAJE_AVANCE  int  not null,
	FECHA_INICIO    date not null,
	FECHA_FIN        date not null,
	TAREA_FINALIZADA      varchar(50),
	TAREA_ENPROCESO      varchar(50),
	TAREA_ABIERTA     varchar(50),
	ID_METODOLOGIA      INT ,
	ID_FASE    INT,
	VERSION_ACTUAL       varchar(50),
	ECS      varchar(50),
	ID_MIEMBRO     INT,
	FOREIGN KEY (ID_METODOLOGIA) REFERENCES METODOLOGIA(ID_METODOLOGIA),
    FOREIGN KEY (ID_FASE) REFERENCES ETAPA(ID_ETAPA),
	FOREIGN KEY (ID_MIEMBRO) REFERENCES MIEMBRO(ID_MIEMBRO)
)
go