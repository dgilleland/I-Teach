CREATE TABLE [dbo].[Events]
(
    [AggregateId] [uniqueidentifier] NOT NULL PRIMARY KEY,
    [Type] [varchar](max) NOT NULL,
    [Body] [varchar](max) NOT NULL,
    [SequenceNumber] [int] NOT NULL,
    [Timestamp] [datetime] NOT NULL
)
