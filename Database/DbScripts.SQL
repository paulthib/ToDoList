﻿CREATE TABLE [dbo].[ToDoList](
	[ToDoListID] [int] IDENTITY(1,1) NOT NULL,
	[ToDoListName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ToDoListID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[ToDoTask](
	[ToDoTaskID] [int] IDENTITY(1,1) NOT NULL,
	[ToDoListID] [int] NOT NULL,
	[ToDoTaskName] [varchar](50) NOT NULL,
	[SortOrder] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ToDoTaskID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ToDoTask]  WITH CHECK ADD  CONSTRAINT [FK_ToDoTask_ToDoList] FOREIGN KEY([ToDoListID])
REFERENCES [dbo].[ToDoList] ([ToDoListID])
GO

ALTER TABLE [dbo].[ToDoTask] CHECK CONSTRAINT [FK_ToDoTask_ToDoList]
GO