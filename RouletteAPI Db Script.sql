USE [master]
GO
/****** Object:  Database [Roulette]    Script Date: 20/07/2022 04:31:26 ******/
CREATE DATABASE [Roulette]
GO

USE [Roulette]
GO
/****** Object:  Table [dbo].[Bet]    Script Date: 20/07/2022 04:31:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bet](
	[betId] [int] IDENTITY(1,1) NOT NULL,
	[betType] [int] NOT NULL,
	[straightNumber] [int] NULL,
	[wheelNumber] [int] NOT NULL,
	[result] [bit] NOT NULL,
	[createdDate] [date] NOT NULL,
 CONSTRAINT [PK_Bet] PRIMARY KEY CLUSTERED 
(
	[betId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Spin]    Script Date: 20/07/2022 04:31:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Spin](
	[spinId] [int] IDENTITY(1,1) NOT NULL,
	[wheelNumber] [int] NOT NULL,
	[createdDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Spin] PRIMARY KEY CLUSTERED 
(
	[spinId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[PI_InsertBet]    Script Date: 20/07/2022 04:31:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PI_InsertBet]
    @betType INT,
    @straightNumber INT,
	@wheelNumber INT,
    @result BIT
AS
BEGIN TRY 
BEGIN TRANSACTION
BEGIN
    INSERT INTO [Bet]([betType], [straightNumber], [wheelNumber], [result], [createdDate])
    VALUES(@betType, @straightNumber, @wheelNumber, @result, GETDATE())

	EXECUTE [dbo].[PI_InsertSpin] @wheelNumber;
END

IF @@TRANCOUNT > 0
	COMMIT TRANSACTION
END TRY

BEGIN CATCH
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION
	DECLARE @ErrMsg nvarchar(4000), @ErrSeverity int
	SELECT @ErrMsg = ERROR_MESSAGE(), @ErrSeverity = ERROR_SEVERITY()
	RAISERROR(@ErrMsg, @ErrSeverity, 1)
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[PI_InsertSpin]    Script Date: 20/07/2022 04:31:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PI_InsertSpin]
	@wheelNumber INT
AS
BEGIN
	INSERT INTO [Spin](wheelNumber, createdDate)
	VALUES(@wheelNumber, GETDATE())
END
GO
/****** Object:  StoredProcedure [dbo].[PS_PreviousSpin]    Script Date: 20/07/2022 04:31:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PS_PreviousSpin]
	@pageNumber INT,
	@pageSize INT,
	@totalNumber INT OUTPUT
AS
BEGIN
	SET @totalNumber = (SELECT COUNT(spinId) FROM Spin)
	
	SELECT spinId, wheelNumber, createdDate
	FROM Spin
	ORDER BY createdDate DESC
	OFFSET (@pageNumber-1) * @pageSize ROWS FETCH NEXT @pageSize ROWS ONLY	
END
GO
USE [master]
GO
ALTER DATABASE [Roulette] SET  READ_WRITE 
GO
