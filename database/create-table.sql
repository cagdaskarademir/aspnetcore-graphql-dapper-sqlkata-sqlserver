-- auto-generated definition
create table Company
(
    Id       int identity
        constraint Company_pk
            primary key nonclustered,
    Name     nvarchar(200) not null,
    IsActive bit default 1 not null
)
go

create unique index Company_Id_uindex
    on Company (Id)
go

