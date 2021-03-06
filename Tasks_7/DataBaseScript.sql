USE [master]
GO
/****** Object:  Database [Task_7]    Script Date: 22/09/2020 23:53:25 ******/
CREATE DATABASE [Task_7]
 CONTAINMENT = NONE
 ON  PRIMARY 

GO
ALTER DATABASE [Task_7] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Task_7].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Task_7] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Task_7] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Task_7] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Task_7] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Task_7] SET ARITHABORT OFF 
GO
ALTER DATABASE [Task_7] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Task_7] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Task_7] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Task_7] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Task_7] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Task_7] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Task_7] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Task_7] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Task_7] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Task_7] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Task_7] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Task_7] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Task_7] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Task_7] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Task_7] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Task_7] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Task_7] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Task_7] SET RECOVERY FULL 
GO
ALTER DATABASE [Task_7] SET  MULTI_USER 
GO
ALTER DATABASE [Task_7] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Task_7] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Task_7] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Task_7] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Task_7] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Task_7', N'ON'
GO
ALTER DATABASE [Task_7] SET QUERY_STORE = OFF
GO
USE [Task_7]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 22/09/2020 23:53:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Id] [uniqueidentifier] NOT NULL,
	[AuthenticationID] [int] NOT NULL,
	[AutorisationID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Account.Authentication]    Script Date: 22/09/2020 23:53:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account.Authentication](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Authentication] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Account.Autorisation]    Script Date: 22/09/2020 23:53:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account.Autorisation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Role] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Autorisation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Account.User]    Script Date: 22/09/2020 23:53:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account.User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountAndAward]    Script Date: 22/09/2020 23:53:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountAndAward](
	[AccountID] [uniqueidentifier] NOT NULL,
	[AwardID] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Award]    Script Date: 22/09/2020 23:53:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Award](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Award] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Account.Authentication] FOREIGN KEY([AuthenticationID])
REFERENCES [dbo].[Account.Authentication] ([Id])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Account.Authentication]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Account.Autorisation] FOREIGN KEY([AutorisationID])
REFERENCES [dbo].[Account.Autorisation] ([Id])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Account.Autorisation]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Account.User] FOREIGN KEY([UserID])
REFERENCES [dbo].[Account.User] ([Id])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Account.User]
GO
ALTER TABLE [dbo].[AccountAndAward]  WITH CHECK ADD  CONSTRAINT [FK_AccountAndAward_Account] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[AccountAndAward] CHECK CONSTRAINT [FK_AccountAndAward_Account]
GO
ALTER TABLE [dbo].[AccountAndAward]  WITH CHECK ADD  CONSTRAINT [FK_AccountAndAward_Award] FOREIGN KEY([AwardID])
REFERENCES [dbo].[Award] ([Id])
GO
ALTER TABLE [dbo].[AccountAndAward] CHECK CONSTRAINT [FK_AccountAndAward_Award]
GO
/****** Object:  StoredProcedure [dbo].[Account_AddUser]    Script Date: 22/09/2020 23:53:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Account_AddUser]
	@Id uniqueidentifier,
	@Login nvarchar(20),
	@Password nvarchar(20),
	@Role nvarchar(20),
	@Name nvarchar(20),
	@DateOfBirth datetime

AS
BEGIN
	SET NOCOUNT off;

	declare
		@AuthenticationID int,
		@AutorisationID int,
		@UserID int

	insert into [Account.Authentication] (Login, Password) values (@Login, @Password);

	set @AuthenticationID = @@IDENTITY;

	insert into [Account.Autorisation] (Role) values (@Role);

	set @AutorisationID = @@IDENTITY;

	insert into [Account.User] (Name, DateOfBirth) values (@Name, @DateOfBirth);

	set @UserID = @@IDENTITY;

	insert into Account (Id, AuthenticationID, AutorisationID, UserID) values (@Id, @AuthenticationID, @AutorisationID, @UserID);

END
GO
/****** Object:  StoredProcedure [dbo].[Account_ChangeUser]    Script Date: 22/09/2020 23:53:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Account_ChangeUser]
	@Id uniqueidentifier,
	@Login nvarchar(20),
	@Password nvarchar(20),
	@Role nvarchar(20),
	@Name nvarchar(20),
	@DateOfBirth datetime
	

AS
BEGIN
	SET NOCOUNT off;

	declare
		@AuthenticationID int,
		@AutorisationID int,
		@UserID int

	select 
		@AuthenticationID = AuthenticationID,
		@AutorisationID = AutorisationID,
		@UserID = UserID
	from Account where Id = @Id;

	update [Account.Authentication] set 
		Login = @Login, 
		Password = @Password
	where Id = @AuthenticationID;

	update [Account.Autorisation] set
		Role = @Role
	where Id = @AutorisationID;

	update [Account.User] set
		Name = @Name,
		DateOfBirth = @DateOfBirth
	where Id = @UserID;

END
GO
/****** Object:  StoredProcedure [dbo].[Account_GetAllUsers]    Script Date: 22/09/2020 23:53:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Account_GetAllUsers]

AS
BEGIN
	SET NOCOUNT on;

	select 
		Account.Id,
		[Account.Authentication].Login,
		[Account.Authentication].Password,
		[Account.Autorisation].Role,
		[Account.User].Name,
		[Account.User].DateOfBirth
	from Account
	inner join [Account.Authentication] on [Account.Authentication].Id = Account.AuthenticationID
	inner join [Account.Autorisation] on [Account.Autorisation].Id = Account.AutorisationID
	inner join [Account.User] on [Account.User].Id = Account.UserID;

END
GO
/****** Object:  StoredProcedure [dbo].[Account_GetUser]    Script Date: 22/09/2020 23:53:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Account_GetUser]
		@Id uniqueidentifier

AS
BEGIN
	SET NOCOUNT on;

	declare
		@AuthenticationID int,
		@AutorisationID int,
		@UserID int

	select 
		@AuthenticationID = AuthenticationID,
		@AutorisationID = AutorisationID,
		@UserID = UserID
	from Account where Id = @Id;

	select 
		Account.Id,
		[Account.Authentication].Login,
		[Account.Authentication].Password,
		[Account.Autorisation].Role,
		[Account.User].Name,
		[Account.User].DateOfBirth
	from Account
	inner join [Account.Authentication] on [Account.Authentication].Id = @AuthenticationID
	inner join [Account.Autorisation] on [Account.Autorisation].Id = @AutorisationID
	inner join [Account.User] on [Account.User].Id = @UserID
	where Account.Id = @Id;

END
GO
/****** Object:  StoredProcedure [dbo].[Account_IsUser]    Script Date: 22/09/2020 23:53:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Account_IsUser]
		@Id uniqueidentifier

AS
BEGIN
	SET NOCOUNT on;

	select Account.Id from Account
	where Account.Id = @Id;

END
GO
/****** Object:  StoredProcedure [dbo].[Account_RemoveUser]    Script Date: 22/09/2020 23:53:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Account_RemoveUser]
	@Id uniqueidentifier


AS
BEGIN
	SET NOCOUNT off;

	declare
		@AuthenticationID int,
		@AutorisationID int,
		@UserID int

	select 
		@AuthenticationID = AuthenticationID,
		@AutorisationID = AutorisationID,
		@UserID = UserID
	from Account where Id = @Id;

	delete from Account
	where Id = @Id;

	delete from [Account.Authentication]
	where Id = @AuthenticationID;

	delete from [Account.Autorisation]
	where Id = @AutorisationID;

	delete from [Account.User]
	where Id = @UserID;

END
GO
/****** Object:  StoredProcedure [dbo].[AccountAndAward_AddDependUserAndAwards]    Script Date: 22/09/2020 23:53:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AccountAndAward_AddDependUserAndAwards]
	@UserId uniqueidentifier,
	@AwardId uniqueidentifier

AS
BEGIN
	SET NOCOUNT off;

    Insert into AccountAndAward (AccountID, AwardID) values (@UserId, @AwardId);
END
GO
/****** Object:  StoredProcedure [dbo].[AccountAndAward_GetAllAwardedUserGuids]    Script Date: 22/09/2020 23:53:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AccountAndAward_GetAllAwardedUserGuids]
	@Id uniqueidentifier

AS
BEGIN
	SET NOCOUNT ON;

	select AccountAndAward.AccountID from AccountAndAward
	where AccountAndAward.AwardID = @Id;
end
GO
/****** Object:  StoredProcedure [dbo].[AccountAndAward_GetAllСustomAwardGuids]    Script Date: 22/09/2020 23:53:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AccountAndAward_GetAllСustomAwardGuids]
	@Id uniqueidentifier

AS
BEGIN
	SET NOCOUNT ON;

	select AccountAndAward.AwardID from AccountAndAward
	where AccountAndAward.AccountID = @Id;
end
GO
/****** Object:  StoredProcedure [dbo].[AccountAndAward_RemoveDependUserAndAwards]    Script Date: 22/09/2020 23:53:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AccountAndAward_RemoveDependUserAndAwards]
	@UserId uniqueidentifier,
	@AwardId uniqueidentifier

AS
BEGIN
	SET NOCOUNT off;

	delete from AccountAndAward
	where AccountID = @UserId and AwardID = @AwardId;

end
GO
/****** Object:  StoredProcedure [dbo].[Award_AddAward]    Script Date: 22/09/2020 23:53:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Award_AddAward]
	@Id uniqueidentifier,
	@Title nvarchar(20)

AS
BEGIN
	SET NOCOUNT off;

    insert into Award (Id, Title) values (@Id, @Title);
END
GO
/****** Object:  StoredProcedure [dbo].[Award_GetAllAwards]    Script Date: 22/09/2020 23:53:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Award_GetAllAwards]

AS
BEGIN
	SET NOCOUNT ON;

	select * from Award;
END
GO
/****** Object:  StoredProcedure [dbo].[Award_GetAward]    Script Date: 22/09/2020 23:53:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Award_GetAward]
	@Id uniqueidentifier
	
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * from Award
	where Award.Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[Award_RemoveAward]    Script Date: 22/09/2020 23:53:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Award_RemoveAward]
	@Id uniqueidentifier

AS
BEGIN
	SET NOCOUNT off;

    delete from Award
	where Id = @Id;

END
GO
/****** Object:  StoredProcedure [dbo].[Awards_ChangeAward]    Script Date: 22/09/2020 23:53:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Awards_ChangeAward]
	@Id uniqueidentifier,
	@Title nvarchar(20)

AS
BEGIN
	SET NOCOUNT off;

	update Award set Title = @Title
	where Id = @Id;

END
GO
USE [master]
GO
ALTER DATABASE [Task_7] SET  READ_WRITE 
GO
