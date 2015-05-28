CREATE TABLE [dbo].[DraftPlanningCalendars]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [CourseName] NVARCHAR(50) NOT NULL, 
    [CourseNumber] NVARCHAR(16) NOT NULL
)
