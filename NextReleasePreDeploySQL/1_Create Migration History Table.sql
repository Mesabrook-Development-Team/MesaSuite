create schema mesasys
go

create table mesasys.MigrationHistory
(
	MigrationHistoryID bigint not null identity primary key,
	MigrationNumber int not null
);

insert into mesasys.MigrationHistory (MigrationNumber) values (0)