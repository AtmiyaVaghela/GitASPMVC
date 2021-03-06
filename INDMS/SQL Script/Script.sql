﻿
 CREATE TABLE [dbo].[Standards1] (
    [Id]           NUMERIC (18)  NOT NULL identity(1,1) primary Key,
    [StandardNo]   VARCHAR (MAX) NOT NULL,
    [Year]         VARCHAR (10)  NOT NULL,
    [Revision]     VARCHAR (MAX) NOT NULL,
    [SubjectParam] VARCHAR (50)  NOT NULL,
    [Subject]      VARCHAR (MAX) NOT NULL,
    [Type]         VARCHAR (50)  NOT NULL,
    [FilePath]     VARCHAR (MAX) NOT NULL,
    [CreatedBy]    VARCHAR (50)  NULL,
    [CreatedDate]  DATETIME      NULL,
);

insert into Standards1( [StandardNo],[Year],[Revision],[SubjectParam],[Subject],[Type],[FilePath],[CreatedBy],[CreatedDate])
select  [StandardNo],[Year],[Revision],[SubjectParam],[Subject],[Type],[FilePath],[CreatedBy],[CreatedDate]
from Standards;

drop table Standards;

EXEC sp_rename 'Standards1', 'Standards';  