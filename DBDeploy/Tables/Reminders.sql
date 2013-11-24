CREATE TABLE [dbo].[Reminders](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Time] [smalldatetime] NOT NULL,
	[Type] [int] NOT NULL,
	[TaskID] [int] NOT NULL,
 CONSTRAINT [PK_Reminder] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Reminders]  WITH CHECK ADD  CONSTRAINT [FK_Reminder_ReminderTypeEnum] FOREIGN KEY([Type])
REFERENCES [dbo].[ReminderTypeEnum] ([ID])
GO

ALTER TABLE [dbo].[Reminders] CHECK CONSTRAINT [FK_Reminder_ReminderTypeEnum]
GO

ALTER TABLE [dbo].[Reminders]  WITH CHECK ADD  CONSTRAINT [FK_Reminders_Tasks] FOREIGN KEY([TaskID])
REFERENCES [dbo].[Tasks] ([ID])
GO

ALTER TABLE [dbo].[Reminders] CHECK CONSTRAINT [FK_Reminders_Tasks]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Reminders for Tasks' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Reminders'
GO


