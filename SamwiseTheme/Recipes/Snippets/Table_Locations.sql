create table Locations
(
    Id           int auto_increment,
    Name         varchar(255) charset utf8 not null,
    Street       varchar(255) charset utf8 null,
    street2      varchar(255) charset utf8 null,
    city         varchar(255) charset utf8 null,
    state        char(2)                   null,
    zip          char(10)                  null,
    ContactName  varchar(255) charset utf8 null,
    ContactPhone varchar(255) charset utf8 null,
    constraint Locations_Id_uindex
        unique (Id),
    constraint Locations_Name_uindex
        unique (Name)
);

alter table Locations add primary key (Id);