CREATE TABLE dbo.MCSyncVersion
(
	MCSyncVersionID bigint identity primary key,
	Major tinyint not null,
	Minor tinyint not null,
	Revision tinyint not null,
	Build tinyint not null,
	Valid datetime2 not null,
	ReleaseNotes nvarchar(max) not null
)