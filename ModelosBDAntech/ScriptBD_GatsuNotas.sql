/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     10/9/2022 10:38:56                           */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ASISTENCIA') and o.name = 'FK_ASISTENC_EST_ASIS_ESTUDIAN')
alter table ASISTENCIA
   drop constraint FK_ASISTENC_EST_ASIS_ESTUDIAN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ASISTENCIA') and o.name = 'FK_ASISTENC_HOR_ASIS_HORARIO')
alter table ASISTENCIA
   drop constraint FK_ASISTENC_HOR_ASIS_HORARIO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ESTUDIANTE') and o.name = 'FK_ESTUDIAN_REP_EST_REPRESEN')
alter table ESTUDIANTE
   drop constraint FK_ESTUDIAN_REP_EST_REPRESEN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ESTUDIANTE') and o.name = 'FK_ESTUDIAN_US_EST_TIPO_USU')
alter table ESTUDIANTE
   drop constraint FK_ESTUDIAN_US_EST_TIPO_USU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('HORARIO') and o.name = 'FK_HORARIO_MAT_HOR_MATERIA')
alter table HORARIO
   drop constraint FK_HORARIO_MAT_HOR_MATERIA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MATERIA') and o.name = 'FK_MATERIA_PROF_MATE_PROFESOR')
alter table MATERIA
   drop constraint FK_MATERIA_PROF_MATE_PROFESOR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('NOTA') and o.name = 'FK_NOTA_ANO_ESCOL_ANO_LECT')
alter table NOTA
   drop constraint FK_NOTA_ANO_ESCOL_ANO_LECT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('NOTA') and o.name = 'FK_NOTA_MATERIA_N_MATERIA')
alter table NOTA
   drop constraint FK_NOTA_MATERIA_N_MATERIA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('NOTA') and o.name = 'FK_NOTA_NOTA_ESTU_ESTUDIAN')
alter table NOTA
   drop constraint FK_NOTA_NOTA_ESTU_ESTUDIAN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PROFESOR') and o.name = 'FK_PROFESOR_US_PROF_TIPO_USU')
alter table PROFESOR
   drop constraint FK_PROFESOR_US_PROF_TIPO_USU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('REPRESENTANTE') and o.name = 'FK_REPRESEN_US_REP_TIPO_USU')
alter table REPRESENTANTE
   drop constraint FK_REPRESEN_US_REP_TIPO_USU
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ANO_LECTIVO')
            and   type = 'U')
   drop table ANO_LECTIVO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ASISTENCIA')
            and   name  = 'EST_ASIS_FK'
            and   indid > 0
            and   indid < 255)
   drop index ASISTENCIA.EST_ASIS_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ASISTENCIA')
            and   name  = 'HOR_ASIS_FK'
            and   indid > 0
            and   indid < 255)
   drop index ASISTENCIA.HOR_ASIS_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ASISTENCIA')
            and   type = 'U')
   drop table ASISTENCIA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ESTUDIANTE')
            and   name  = 'US_EST_FK'
            and   indid > 0
            and   indid < 255)
   drop index ESTUDIANTE.US_EST_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ESTUDIANTE')
            and   name  = 'REP_EST_FK'
            and   indid > 0
            and   indid < 255)
   drop index ESTUDIANTE.REP_EST_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ESTUDIANTE')
            and   type = 'U')
   drop table ESTUDIANTE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('HORARIO')
            and   name  = 'MAT_HOR_FK'
            and   indid > 0
            and   indid < 255)
   drop index HORARIO.MAT_HOR_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('HORARIO')
            and   type = 'U')
   drop table HORARIO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('MATERIA')
            and   name  = 'PROF_MATERIA_FK'
            and   indid > 0
            and   indid < 255)
   drop index MATERIA.PROF_MATERIA_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MATERIA')
            and   type = 'U')
   drop table MATERIA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('NOTA')
            and   name  = 'ANO_ESCOLAR_NOT_FK'
            and   indid > 0
            and   indid < 255)
   drop index NOTA.ANO_ESCOLAR_NOT_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('NOTA')
            and   name  = 'NOTA_ESTUD_FK'
            and   indid > 0
            and   indid < 255)
   drop index NOTA.NOTA_ESTUD_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('NOTA')
            and   name  = 'MATERIA_NOTA_FK'
            and   indid > 0
            and   indid < 255)
   drop index NOTA.MATERIA_NOTA_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('NOTA')
            and   type = 'U')
   drop table NOTA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PROFESOR')
            and   name  = 'US_PROF_FK'
            and   indid > 0
            and   indid < 255)
   drop index PROFESOR.US_PROF_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PROFESOR')
            and   type = 'U')
   drop table PROFESOR
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('REPRESENTANTE')
            and   name  = 'US_REP_FK'
            and   indid > 0
            and   indid < 255)
   drop index REPRESENTANTE.US_REP_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('REPRESENTANTE')
            and   type = 'U')
   drop table REPRESENTANTE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TIPO_USUARIO')
            and   type = 'U')
   drop table TIPO_USUARIO
go

/*==============================================================*/
/* Table: ANO_LECTIVO                                           */
/*==============================================================*/
create table ANO_LECTIVO (
   ID_ANO               numeric              identity,
   ANO_DESCRIP          varchar(15)          not null,
   constraint PK_ANO_LECTIVO primary key nonclustered (ID_ANO)
)
go

/*==============================================================*/
/* Table: ASISTENCIA                                            */
/*==============================================================*/
create table ASISTENCIA (
   ID_ASIS              numeric              identity,
   ID_HORARIO           int                  null,
   ID_ESTUDIANTE        int                  null,
   ASIS_FECHA           datetime             not null,
   ASIS_CONF            varchar(2)           not null,
   constraint PK_ASISTENCIA primary key nonclustered (ID_ASIS)
)
go

/*==============================================================*/
/* Index: HOR_ASIS_FK                                           */
/*==============================================================*/
create index HOR_ASIS_FK on ASISTENCIA (
ID_HORARIO ASC
)
go

/*==============================================================*/
/* Index: EST_ASIS_FK                                           */
/*==============================================================*/
create index EST_ASIS_FK on ASISTENCIA (
ID_ESTUDIANTE ASC
)
go

/*==============================================================*/
/* Table: ESTUDIANTE                                            */
/*==============================================================*/
create table ESTUDIANTE (
   ID_ESTUDIANTE        numeric              identity,
   ID_REP               int                  null,
   ID_TIPOU             int                  null,
   EST_NOMBRE           varchar(50)          not null,
   EST_APELLIDO         varchar(50)          not null,
   EST_CEDULA           varchar(10)          not null,
   EST_FECHANAC         datetime             not null,
   EST_PASSWORD         varchar(15)          not null,
   constraint PK_ESTUDIANTE primary key nonclustered (ID_ESTUDIANTE)
)
go

/*==============================================================*/
/* Index: REP_EST_FK                                            */
/*==============================================================*/
create index REP_EST_FK on ESTUDIANTE (
ID_REP ASC
)
go

/*==============================================================*/
/* Index: US_EST_FK                                             */
/*==============================================================*/
create index US_EST_FK on ESTUDIANTE (
ID_TIPOU ASC
)
go

/*==============================================================*/
/* Table: HORARIO                                               */
/*==============================================================*/
create table HORARIO (
   ID_HORARIO           numeric              identity,
   ID_MATERIA           varchar(2)           null,
   HOR_DIA              varchar(15)          not null,
   HOR_HORA             varchar(10)          not null,
   constraint PK_HORARIO primary key nonclustered (ID_HORARIO)
)
go

/*==============================================================*/
/* Index: MAT_HOR_FK                                            */
/*==============================================================*/
create index MAT_HOR_FK on HORARIO (
ID_MATERIA ASC
)
go

/*==============================================================*/
/* Table: MATERIA                                               */
/*==============================================================*/
create table MATERIA (
   ID_MATERIA           varchar(2)           not null,
   ID_PROFESOR          int                  not null,
   MAT_NOMBRE           varchar(20)          not null,
   MAT_GRADO            varchar(3)           not null,
   MAT_PARALELO         varchar(3)           not null,
   constraint PK_MATERIA primary key nonclustered (ID_MATERIA)
)
go

/*==============================================================*/
/* Index: PROF_MATERIA_FK                                       */
/*==============================================================*/
create index PROF_MATERIA_FK on MATERIA (
ID_PROFESOR ASC
)
go

/*==============================================================*/
/* Table: NOTA                                                  */
/*==============================================================*/
create table NOTA (
   ID_NOTA              numeric              identity,
   ID_MATERIA           varchar(2)           not null,
   ID_ESTUDIANTE        int                  not null,
   ID_ANO               int                  null,
   NP1                  float(4)             null,
   NP2                  float(4)             null,
   NP3                  float(4)             null,
   EQ1                  float(4)             null,
   Q1                   float(4)             null,
   NP4                  float(4)             null,
   NP5                  float(4)             null,
   NP6                  float(4)             null,
   EQ2                  float(4)             null,
   Q2                   float(4)             null,
   FINAL                float(4)             null,
   constraint PK_NOTA primary key nonclustered (ID_NOTA)
)
go

/*==============================================================*/
/* Index: MATERIA_NOTA_FK                                       */
/*==============================================================*/
create index MATERIA_NOTA_FK on NOTA (
ID_MATERIA ASC
)
go

/*==============================================================*/
/* Index: NOTA_ESTUD_FK                                         */
/*==============================================================*/
create index NOTA_ESTUD_FK on NOTA (
ID_ESTUDIANTE ASC
)
go

/*==============================================================*/
/* Index: ANO_ESCOLAR_NOT_FK                                    */
/*==============================================================*/
create index ANO_ESCOLAR_NOT_FK on NOTA (
ID_ANO ASC
)
go

/*==============================================================*/
/* Table: PROFESOR                                              */
/*==============================================================*/
create table PROFESOR (
   ID_PROFESOR          numeric              identity,
   ID_TIPOU             int                  null,
   PROF_NOMBRE          varchar(50)          not null,
   PROF_APELLIDO        varchar(50)          not null,
   PROF_CEDULA          varchar(10)          not null,
   PROF_DIRECCION       varchar(100)         not null,
   PROF_TELF            int                  not null,
   PROF_PASSWORD        varchar(15)          not null,
   constraint PK_PROFESOR primary key nonclustered (ID_PROFESOR)
)
go

/*==============================================================*/
/* Index: US_PROF_FK                                            */
/*==============================================================*/
create index US_PROF_FK on PROFESOR (
ID_TIPOU ASC
)
go

/*==============================================================*/
/* Table: REPRESENTANTE                                         */
/*==============================================================*/
create table REPRESENTANTE (
   ID_REP               numeric              identity,
   ID_TIPOU             int                  null,
   REP_NOMBRE           varchar(50)          not null,
   REP_APELLIDO         varchar(50)          not null,
   REP_CEDULA           varchar(10)          not null,
   REP_DIRECCION        varchar(100)         not null,
   REP_TELEFONO         int                  not null,
   REP_PASSWORD         varchar(15)          not null,
   constraint PK_REPRESENTANTE primary key nonclustered (ID_REP)
)
go

/*==============================================================*/
/* Index: US_REP_FK                                             */
/*==============================================================*/
create index US_REP_FK on REPRESENTANTE (
ID_TIPOU ASC
)
go

/*==============================================================*/
/* Table: TIPO_USUARIO                                          */
/*==============================================================*/
create table TIPO_USUARIO (
   ID_TIPOU             numeric              identity,
   TU_DESCRIP           varchar(30)          not null,
   constraint PK_TIPO_USUARIO primary key nonclustered (ID_TIPOU)
)
go

alter table ASISTENCIA
   add constraint FK_ASISTENC_EST_ASIS_ESTUDIAN foreign key (ID_ESTUDIANTE)
      references ESTUDIANTE (ID_ESTUDIANTE)
go

alter table ASISTENCIA
   add constraint FK_ASISTENC_HOR_ASIS_HORARIO foreign key (ID_HORARIO)
      references HORARIO (ID_HORARIO)
go

alter table ESTUDIANTE
   add constraint FK_ESTUDIAN_REP_EST_REPRESEN foreign key (ID_REP)
      references REPRESENTANTE (ID_REP)
go

alter table ESTUDIANTE
   add constraint FK_ESTUDIAN_US_EST_TIPO_USU foreign key (ID_TIPOU)
      references TIPO_USUARIO (ID_TIPOU)
go

alter table HORARIO
   add constraint FK_HORARIO_MAT_HOR_MATERIA foreign key (ID_MATERIA)
      references MATERIA (ID_MATERIA)
go

alter table MATERIA
   add constraint FK_MATERIA_PROF_MATE_PROFESOR foreign key (ID_PROFESOR)
      references PROFESOR (ID_PROFESOR)
go

alter table NOTA
   add constraint FK_NOTA_ANO_ESCOL_ANO_LECT foreign key (ID_ANO)
      references ANO_LECTIVO (ID_ANO)
go

alter table NOTA
   add constraint FK_NOTA_MATERIA_N_MATERIA foreign key (ID_MATERIA)
      references MATERIA (ID_MATERIA)
go

alter table NOTA
   add constraint FK_NOTA_NOTA_ESTU_ESTUDIAN foreign key (ID_ESTUDIANTE)
      references ESTUDIANTE (ID_ESTUDIANTE)
go

alter table PROFESOR
   add constraint FK_PROFESOR_US_PROF_TIPO_USU foreign key (ID_TIPOU)
      references TIPO_USUARIO (ID_TIPOU)
go

alter table REPRESENTANTE
   add constraint FK_REPRESEN_US_REP_TIPO_USU foreign key (ID_TIPOU)
      references TIPO_USUARIO (ID_TIPOU)
go

