# I-Teach Assembly

The I-Teach Assembly presumes the existance of an SQL Server database using this connection string information:

```
    <add name="DefaultConnection"
         connectionString="Data Source=.;Initial Catalog=ITeachTestDb;Integrated Security=True"
         providerName="System.Data.SqlClient"/>
```

## The Database

The following script is needed to generate the database tables:

```
USE [ITeachTestDb]
GO

/****** Object:  Table [dbo].[Aggregates]    Script Date: 5/23/2015 2:21:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Aggregates](
	[Id] [uniqueidentifier] NOT NULL,
	[Type] [varchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Events]    Script Date: 5/23/2015 2:21:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Events](
	[AggregateId] [uniqueidentifier] NOT NULL,
	[Type] [varchar](max) NOT NULL,
	[Body] [varchar](max) NOT NULL,
	[SequenceNumber] [int] NOT NULL,
	[Timestamp] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

```