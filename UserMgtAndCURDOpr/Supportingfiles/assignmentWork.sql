
Select * from AspNetUsers

Select * from AspNetUserRoles

Select * from AspNetUserLogins

Select * from AspNetRoles

Create table Projects(
ProjectId int constraint PK_ProjectId Primary key identity(1,1),
ProjectName Nvarchar(100) not null,
ClientName nvarchar(100) not null,
ProjDescription nvarchar(500))

-- drop table UserComments
create table UserComments(
UserCommentsId int constraint PK_UserCommentsId Primary Key identity(1,1),
UserId nvarchar(128) constraint FK_UserComments_AspNetUsers foreign key references AspNetUsers(id),
ProjectId int constraint FK_UserComments_Projects foreign key references Projects(ProjectId),
UserComments nvarchar(1000),
createdDate datetime default getdate())

-- Stored Procedure to Insert Project

Create Procedure SP_InsertProjects
@ProjectName Nvarchar(100),
@ClientName nvarchar(100),
@ProjDescription nvarchar(500)
as

	Begin
		Insert into Projects(ProjectName,ClientName,ProjDescription) 
			values(@ProjectName,@ClientName,@ProjDescription) 

	End

-- Stored Procedure to update Project

Create Procedure SP_UpdateProjects
@ProjectId int,
@ProjectName Nvarchar(100),
@ClientName nvarchar(100),
@ProjDescription nvarchar(500)
as

	Begin
	update Projects 
		set ProjectName = @ProjectName,
			ClientName = @ClientName,
			ProjDescription = @ProjDescription
			where ProjectId = @ProjectId
		
	End


-- Stored Procedure to update Project

Create Procedure SP_DeleteProjects
@ProjectId int

as

	Begin
	delete from  Projects 
			where ProjectId = @ProjectId
		
	End

-- Stored Procedure to Select Single Project

Create Procedure SP_SelectSingleProjects
@ProjectId int

as

	Begin
	    Select ProjectId, ProjectName, ClientName, ProjDescription from  Projects 
			where ProjectId = @ProjectId
		


	End


-- Stored Procedure to Fetch Projects
-- drop  Procedure SP_SelectAllProjecs
Create Procedure SP_SelectAllProjects
as

	Begin

		Select ProjectId, ProjectName, ClientName, ProjDescription from Projects

	End


-- Stored Procedure to Fech Projectand Comments

Create Procedure SP_SelectProjectsWithComments
@ProjectId int
as

	Begin

		Select P.ProjectId, P.ProjectName, P.ClientName, P.ProjDescription,
		UC.UserComments from 
		Projects P join UserComments UC on P.ProjectId = UC.ProjectId
		where UC.ProjectId = @ProjectId

	End

-- StoredProcedure to Insert User Comments
	
Create Procedure SP_InsertUserComments
@UserId nvarchar(128),
@ProjectId int,
@UserComments nvarchar(1000)


as

	Begin
		Insert into UserComments(UserId, ProjectId, UserComments) 
			values(@UserId,@ProjectId,@UserComments) 

	End


	create table ProjectsImages(
	ProjectsImageId int Constraint PK_ProjectsImage Primary key Identity(1,1),
	ProjectId int Constraint FK_ProjectsImage_Project foreign key references Projects(ProjectId),
	Images varbinary
	)