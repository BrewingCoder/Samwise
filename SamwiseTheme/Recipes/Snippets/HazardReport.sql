-- auto-generated definition
create table HazardReport
(
    Id            int auto_increment,
    DateSubmitted datetime                  null,
    ControlNumber varchar(7)                null,
    LocationId    int                       null,
    Description   text                      null,
    Emloyee       varchar(255) charset utf8 null,
    Stage         int                       null,
    StageText     varchar(255) charset utf8 null,
    OfficerId     varchar(255) charset utf8 null,
    OfficerEmail  varchar(255) charset utf8 null,
    OfficerAction text                      null,
    isclosed      tinyint(1)                null,
    constraint HazardReport_Id_uindex
        unique (Id),
    constraint HazardReport_Locations_Id_fk
        foreign key (LocationId) references Locations (Id)
);

alter table HazardReport
    add primary key (Id);