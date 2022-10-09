/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     6/10/2022 11:00:32                           */
/*==============================================================*/




/*==============================================================*/
/* Table: ANO_LECTIVO                                           */
/*==============================================================*/
create table ANO_LECTIVO (
   ID_ANO               int                  not null,
   ANO_DESCRIP          varchar(15)          not null,
   constraint PK_ANO_LECTIVO primary key nonclustered (ID_ANO)
)
go

/*==============================================================*/
/* Table: ASISTENCIA                                            */
/*==============================================================*/
create table ASISTENCIA (
   ID_ASIS              int               identity,
   ID_HORARIO           int                  not null,
   ID_ESTUDIANTE        int                  not null,
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
   ID_ESTUDIANTE        int               identity,
   EST_USU              varchar(10)          not null,
   ID_REP               int                  not null,
   ID_TIPOU             int                  not null,
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
   ID_HORARIO           int               identity,
   ID_MATERIA           int                  not null,
   HOR_DIA              varchar(15)          not null,
   HOR_HORA             datetime             not null,
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
   ID_MATERIA           int                  not null,
   MAT_COD              varchar(5)           not null,
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
   ID_NOTA              int             identity,
   ID_MATERIA           int                  not null,
   ID_ESTUDIANTE        int                  not null,
   ID_ANO               int                  not null,
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
   ID_PROFESOR          int               identity,
   PROF_USU             varchar(10)          not null,
   ID_TIPOU             int                  not null,
   PROF_NOMBRE          varchar(50)          not null,
   PROF_APELLIDO        varchar(50)          not null,
   PROF_CEDULA          varchar(10)          not null,
   PROF_DIRECCION       varchar(100)         not null,
   PROF_TELF            varchar(10)          not null,
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
   ID_REP               int               identity,
   REP_USU              varchar(10)          not null,
   ID_TIPOU             int                  not null,
   REP_NOMBRE           varchar(50)          not null,
   REP_APELLIDO         varchar(50)          not null,
   REP_CEDULA           varchar(10)          not null,
   REP_DIRECCION        varchar(100)         not null,
   REP_TELEFONO         varchar(10)          not null,
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
   ID_TIPOU             int                  not null,
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

