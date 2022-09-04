CREATE TABLE [dbo].[UserTbl]
(
	[Uname] VARCHAR(50) NOT NULL , 
    [Ufullname] VARCHAR(50) NOT NULL, 
    [Upassword] VARCHAR(50) NOT NULL, 
    [Uphone] VARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Table] PRIMARY KEY ([Uphone])
)
