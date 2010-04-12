/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     12-Apr-10 7:50:44 PM                         */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EVENT') and o.name = 'FK_EVENT_REFERENCE_TIMELINE')
alter table EVENT
   drop constraint FK_EVENT_REFERENCE_TIMELINE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MEMBER') and o.name = 'FK_MEMBER_REFERENCE_ACCOUNT')
alter table MEMBER
   drop constraint FK_MEMBER_REFERENCE_ACCOUNT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MEMBER') and o.name = 'FK_MEMBER_REFERENCE_TIMELINE')
alter table MEMBER
   drop constraint FK_MEMBER_REFERENCE_TIMELINE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MEMBER_EVENT') and o.name = 'FK_MEMBER_E_REFERENCE_EVENT')
alter table MEMBER_EVENT
   drop constraint FK_MEMBER_E_REFERENCE_EVENT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MEMBER_EVENT') and o.name = 'FK_MEMBER_E_REFERENCE_MEMBER')
alter table MEMBER_EVENT
   drop constraint FK_MEMBER_E_REFERENCE_MEMBER
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ACCOUNT')
            and   name  = 'INDEX_1'
            and   indid > 0
            and   indid < 255)
   drop index ACCOUNT.INDEX_1
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ACCOUNT')
            and   type = 'U')
   drop table ACCOUNT
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('EVENT')
            and   name  = 'INDEX_1'
            and   indid > 0
            and   indid < 255)
   drop index EVENT.INDEX_1
go

if exists (select 1
            from  sysobjects
           where  id = object_id('EVENT')
            and   type = 'U')
   drop table EVENT
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('MEMBER')
            and   name  = 'INDEX_1'
            and   indid > 0
            and   indid < 255)
   drop index MEMBER.INDEX_1
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MEMBER')
            and   type = 'U')
   drop table MEMBER
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('MEMBER_EVENT')
            and   name  = 'INDEX_1'
            and   indid > 0
            and   indid < 255)
   drop index MEMBER_EVENT.INDEX_1
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MEMBER_EVENT')
            and   type = 'U')
   drop table MEMBER_EVENT
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TIMELINE')
            and   name  = 'INDEX_1'
            and   indid > 0
            and   indid < 255)
   drop index TIMELINE.INDEX_1
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TIMELINE')
            and   type = 'U')
   drop table TIMELINE
go

/*==============================================================*/
/* Table: ACCOUNT                                               */
/*==============================================================*/
create table ACCOUNT (
   ID                   int                  identity,
   NAME                 varchar(Max)         not null,
   DISPLAYNAME          varchar(max)         not null,
   EMAIL                varchar(100)         not null,
   PASSWORD             varchar(Max)         not null,
   VERSION              int                  not null,
   WEBSITE              varchar(max)         null,
   constraint PK_ACCOUNT primary key (ID)
)
go

/*==============================================================*/
/* Index: INDEX_1                                               */
/*==============================================================*/
create index INDEX_1 on ACCOUNT (
ID ASC,
EMAIL ASC
)
go

/*==============================================================*/
/* Table: EVENT                                                 */
/*==============================================================*/
create table EVENT (
   ID                   int                  identity,
   NAME                 varchar(Max)         not null,
   COLOR                varchar(Max)         null,
   TIMELINEID           int                  not null,
   VERSION              int                  not null,
   DESCRIPTION          varchar(max)         null,
   constraint PK_EVENT primary key (ID)
)
go

/*==============================================================*/
/* Index: INDEX_1                                               */
/*==============================================================*/
create index INDEX_1 on EVENT (
ID ASC,
TIMELINEID ASC
)
go

/*==============================================================*/
/* Table: MEMBER                                                */
/*==============================================================*/
create table MEMBER (
   ID                   int                  identity,
   USERID               int                  not null,
   TIMELINEID           int                  not null,
   ISADMIN              bit                  not null,
   VERSION              int                  not null,
   constraint PK_MEMBER primary key (ID)
)
go

/*==============================================================*/
/* Index: INDEX_1                                               */
/*==============================================================*/
create index INDEX_1 on MEMBER (
ID ASC,
USERID ASC,
TIMELINEID ASC
)
go

/*==============================================================*/
/* Table: MEMBER_EVENT                                          */
/*==============================================================*/
create table MEMBER_EVENT (
   ID                   int                  identity,
   EVENTID              int                  not null,
   MEMBERID             int                  not null,
   DATE                 datetime             not null,
   VERSION              int                  not null,
   constraint PK_MEMBER_EVENT primary key (ID)
)
go

/*==============================================================*/
/* Index: INDEX_1                                               */
/*==============================================================*/
create index INDEX_1 on MEMBER_EVENT (
ID ASC,
EVENTID ASC,
MEMBERID ASC
)
go

/*==============================================================*/
/* Table: TIMELINE                                              */
/*==============================================================*/
create table TIMELINE (
   ID                   int                  identity,
   NAME                 varchar(100)         not null,
   DESCRIPTION          varchar(Max)         null,
   CREATEDON            datetime             not null,
   VERSION              int                  not null,
   constraint PK_TIMELINE primary key (ID)
)
go

/*==============================================================*/
/* Index: INDEX_1                                               */
/*==============================================================*/
create index INDEX_1 on TIMELINE (
ID ASC,
NAME ASC
)
go

alter table EVENT
   add constraint FK_EVENT_REFERENCE_TIMELINE foreign key (TIMELINEID)
      references TIMELINE (ID)
go

alter table MEMBER
   add constraint FK_MEMBER_REFERENCE_ACCOUNT foreign key (USERID)
      references ACCOUNT (ID)
go

alter table MEMBER
   add constraint FK_MEMBER_REFERENCE_TIMELINE foreign key (TIMELINEID)
      references TIMELINE (ID)
go

alter table MEMBER_EVENT
   add constraint FK_MEMBER_E_REFERENCE_EVENT foreign key (EVENTID)
      references EVENT (ID)
go

alter table MEMBER_EVENT
   add constraint FK_MEMBER_E_REFERENCE_MEMBER foreign key (MEMBERID)
      references MEMBER (ID)
go

