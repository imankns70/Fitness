USE [Fitness]
GO
SET IDENTITY_INSERT [dbo].[Workouts] ON 

INSERT [dbo].[Workouts] ([Id], [Name], [Type], [Reps], [Sets], [Weight], [Distance], [Duration]) VALUES (1, N'تردمیل', N'Endurance', NULL, NULL, NULL, 3, 40)
INSERT [dbo].[Workouts] ([Id], [Name], [Type], [Reps], [Sets], [Weight], [Distance], [Duration]) VALUES (2, N'طناب', N'Strength', 3, 50, 15, NULL, NULL)
INSERT [dbo].[Workouts] ([Id], [Name], [Type], [Reps], [Sets], [Weight], [Distance], [Duration]) VALUES (4, N'پرس سینه', N'Strength', 3, 10, 80, NULL, NULL)
INSERT [dbo].[Workouts] ([Id], [Name], [Type], [Reps], [Sets], [Weight], [Distance], [Duration]) VALUES (5, N'تردمیل', N'Endurance', NULL, NULL, NULL, 3, 40)
INSERT [dbo].[Workouts] ([Id], [Name], [Type], [Reps], [Sets], [Weight], [Distance], [Duration]) VALUES (6, N'بارفیکس', N'Strength', 3, 50, 20, NULL, NULL)
INSERT [dbo].[Workouts] ([Id], [Name], [Type], [Reps], [Sets], [Weight], [Distance], [Duration]) VALUES (7, N'پرس سینه', N'Strength', 3, 10, 80, NULL, NULL)
INSERT [dbo].[Workouts] ([Id], [Name], [Type], [Reps], [Sets], [Weight], [Distance], [Duration]) VALUES (8, N'تردمیل', N'Endurance', NULL, NULL, NULL, 4, 60)
INSERT [dbo].[Workouts] ([Id], [Name], [Type], [Reps], [Sets], [Weight], [Distance], [Duration]) VALUES (9, N'بارفیکس', N'Strength', 3, 40, 20, NULL, NULL)
INSERT [dbo].[Workouts] ([Id], [Name], [Type], [Reps], [Sets], [Weight], [Distance], [Duration]) VALUES (10, N'اسکات', N'Strength', 3, 10, 120, NULL, NULL)
INSERT [dbo].[Workouts] ([Id], [Name], [Type], [Reps], [Sets], [Weight], [Distance], [Duration]) VALUES (11, N'جلو پا', N'Strength', 3, 10, 95, NULL, NULL)
INSERT [dbo].[Workouts] ([Id], [Name], [Type], [Reps], [Sets], [Weight], [Distance], [Duration]) VALUES (12, N'فوتسال', N'endurance', NULL, NULL, NULL, 4, 100)
INSERT [dbo].[Workouts] ([Id], [Name], [Type], [Reps], [Sets], [Weight], [Distance], [Duration]) VALUES (13, N'سرشانه', N'strength', NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Workouts] ([Id], [Name], [Type], [Reps], [Sets], [Weight], [Distance], [Duration]) VALUES (14, N'شنا', N'endurance', NULL, NULL, NULL, 1, 60)
SET IDENTITY_INSERT [dbo].[Workouts] OFF
GO
SET IDENTITY_INSERT [dbo].[Schedules] ON 

INSERT [dbo].[Schedules] ([Id], [SelectedDay]) VALUES (1, CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Schedules] ([Id], [SelectedDay]) VALUES (2, CAST(N'2021-12-14T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Schedules] ([Id], [SelectedDay]) VALUES (3, CAST(N'2021-12-16T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Schedules] ([Id], [SelectedDay]) VALUES (8, CAST(N'2021-12-20T15:16:29.8610000' AS DateTime2))
INSERT [dbo].[Schedules] ([Id], [SelectedDay]) VALUES (9, CAST(N'2021-12-15T20:30:00.0000000' AS DateTime2))
INSERT [dbo].[Schedules] ([Id], [SelectedDay]) VALUES (10, CAST(N'2021-12-12T20:30:00.0000000' AS DateTime2))
INSERT [dbo].[Schedules] ([Id], [SelectedDay]) VALUES (11, CAST(N'2021-12-13T20:30:00.0000000' AS DateTime2))
INSERT [dbo].[Schedules] ([Id], [SelectedDay]) VALUES (12, CAST(N'2021-12-21T18:37:29.7010000' AS DateTime2))
INSERT [dbo].[Schedules] ([Id], [SelectedDay]) VALUES (13, CAST(N'2021-12-22T18:37:29.7010000' AS DateTime2))
INSERT [dbo].[Schedules] ([Id], [SelectedDay]) VALUES (14, CAST(N'2021-12-23T18:37:29.7010000' AS DateTime2))
INSERT [dbo].[Schedules] ([Id], [SelectedDay]) VALUES (15, CAST(N'2021-12-24T18:37:29.7010000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Schedules] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Email], [Password]) VALUES (1, N'fafa@gmail.om', N'123456')
INSERT [dbo].[Users] ([Id], [Email], [Password]) VALUES (2, N'iman@gmail.com', N'123456')
INSERT [dbo].[Users] ([Id], [Email], [Password]) VALUES (3, N'farhan@gmail.com', N'123456')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Sections] ON 

INSERT [dbo].[Sections] ([Id], [SectionKey], [Name]) VALUES (2, N'morning', N'morning')
INSERT [dbo].[Sections] ([Id], [SectionKey], [Name]) VALUES (1002, N'lunch', N'Lunch')
INSERT [dbo].[Sections] ([Id], [SectionKey], [Name]) VALUES (1003, N'evening', N'Evening or afternoon')
INSERT [dbo].[Sections] ([Id], [SectionKey], [Name]) VALUES (1004, N'dinner', N'Dinner')
SET IDENTITY_INSERT [dbo].[Sections] OFF
GO
SET IDENTITY_INSERT [dbo].[Ingredients] ON 

INSERT [dbo].[Ingredients] ([Id], [Name]) VALUES (7, N'تخم مرغ')
INSERT [dbo].[Ingredients] ([Id], [Name]) VALUES (8, N'گوجه')
INSERT [dbo].[Ingredients] ([Id], [Name]) VALUES (9, N'قارچ')
INSERT [dbo].[Ingredients] ([Id], [Name]) VALUES (1002, N'هویچ')
INSERT [dbo].[Ingredients] ([Id], [Name]) VALUES (1003, N'سینه مرغ')
INSERT [dbo].[Ingredients] ([Id], [Name]) VALUES (1004, N'ذرت')
INSERT [dbo].[Ingredients] ([Id], [Name]) VALUES (1005, N'لوبیا سبز')
INSERT [dbo].[Ingredients] ([Id], [Name]) VALUES (1006, N'خیار')
INSERT [dbo].[Ingredients] ([Id], [Name]) VALUES (1007, N'کاهو')
INSERT [dbo].[Ingredients] ([Id], [Name]) VALUES (1008, N'کره بادام زمینی')
INSERT [dbo].[Ingredients] ([Id], [Name]) VALUES (1009, N'بال مرغ')
INSERT [dbo].[Ingredients] ([Id], [Name]) VALUES (1010, N'نون سنگک')
INSERT [dbo].[Ingredients] ([Id], [Name]) VALUES (1011, N'گوشت چرخ کرده')
INSERT [dbo].[Ingredients] ([Id], [Name]) VALUES (1012, N'پاستا')
INSERT [dbo].[Ingredients] ([Id], [Name]) VALUES (1013, N'پیاز')
INSERT [dbo].[Ingredients] ([Id], [Name]) VALUES (1014, N'رب گوجه')
INSERT [dbo].[Ingredients] ([Id], [Name]) VALUES (1015, N'سیب زمینی')
INSERT [dbo].[Ingredients] ([Id], [Name]) VALUES (1016, N'شیر')
INSERT [dbo].[Ingredients] ([Id], [Name]) VALUES (1017, N'برنج')
INSERT [dbo].[Ingredients] ([Id], [Name]) VALUES (1018, N'گندم ')
INSERT [dbo].[Ingredients] ([Id], [Name]) VALUES (1019, N'گوشت')
SET IDENTITY_INSERT [dbo].[Ingredients] OFF
GO
SET IDENTITY_INSERT [dbo].[Meals] ON 

INSERT [dbo].[Meals] ([Id], [Name]) VALUES (3, N'املت')
INSERT [dbo].[Meals] ([Id], [Name]) VALUES (1002, N'سالاد فصل')
INSERT [dbo].[Meals] ([Id], [Name]) VALUES (1003, N'کباب مرغ')
INSERT [dbo].[Meals] ([Id], [Name]) VALUES (1004, N'ماکارونی')
INSERT [dbo].[Meals] ([Id], [Name]) VALUES (1005, N'مرغ آب پز')
INSERT [dbo].[Meals] ([Id], [Name]) VALUES (1006, N'سیب زمینی تخم مرغ با نون سنگک')
INSERT [dbo].[Meals] ([Id], [Name]) VALUES (1007, N'شیر برنج')
INSERT [dbo].[Meals] ([Id], [Name]) VALUES (1008, N'حلیم')
SET IDENTITY_INSERT [dbo].[Meals] OFF
GO
SET IDENTITY_INSERT [dbo].[MealIngredients] ON 

INSERT [dbo].[MealIngredients] ([Id], [MealId], [IngredientId]) VALUES (7, 3, 7)
INSERT [dbo].[MealIngredients] ([Id], [MealId], [IngredientId]) VALUES (8, 3, 8)
INSERT [dbo].[MealIngredients] ([Id], [MealId], [IngredientId]) VALUES (9, 3, 9)
INSERT [dbo].[MealIngredients] ([Id], [MealId], [IngredientId]) VALUES (1002, 1005, 1003)
INSERT [dbo].[MealIngredients] ([Id], [MealId], [IngredientId]) VALUES (1003, 1003, 1009)
INSERT [dbo].[MealIngredients] ([Id], [MealId], [IngredientId]) VALUES (1004, 1003, 1003)
INSERT [dbo].[MealIngredients] ([Id], [MealId], [IngredientId]) VALUES (1005, 1002, 8)
INSERT [dbo].[MealIngredients] ([Id], [MealId], [IngredientId]) VALUES (1006, 1002, 9)
INSERT [dbo].[MealIngredients] ([Id], [MealId], [IngredientId]) VALUES (1007, 1002, 1002)
INSERT [dbo].[MealIngredients] ([Id], [MealId], [IngredientId]) VALUES (1008, 1002, 1004)
INSERT [dbo].[MealIngredients] ([Id], [MealId], [IngredientId]) VALUES (1009, 1002, 1005)
INSERT [dbo].[MealIngredients] ([Id], [MealId], [IngredientId]) VALUES (1010, 1002, 1006)
INSERT [dbo].[MealIngredients] ([Id], [MealId], [IngredientId]) VALUES (1011, 1002, 1007)
INSERT [dbo].[MealIngredients] ([Id], [MealId], [IngredientId]) VALUES (1012, 1004, 1012)
INSERT [dbo].[MealIngredients] ([Id], [MealId], [IngredientId]) VALUES (1013, 1004, 1013)
INSERT [dbo].[MealIngredients] ([Id], [MealId], [IngredientId]) VALUES (1014, 1004, 1014)
INSERT [dbo].[MealIngredients] ([Id], [MealId], [IngredientId]) VALUES (1015, 1004, 9)
INSERT [dbo].[MealIngredients] ([Id], [MealId], [IngredientId]) VALUES (1016, 1004, 1011)
INSERT [dbo].[MealIngredients] ([Id], [MealId], [IngredientId]) VALUES (1017, 1006, 7)
INSERT [dbo].[MealIngredients] ([Id], [MealId], [IngredientId]) VALUES (1018, 1006, 1010)
INSERT [dbo].[MealIngredients] ([Id], [MealId], [IngredientId]) VALUES (1019, 1006, 1015)
INSERT [dbo].[MealIngredients] ([Id], [MealId], [IngredientId]) VALUES (1020, 1004, 1015)
INSERT [dbo].[MealIngredients] ([Id], [MealId], [IngredientId]) VALUES (1021, 1007, 1016)
INSERT [dbo].[MealIngredients] ([Id], [MealId], [IngredientId]) VALUES (1022, 1007, 1017)
INSERT [dbo].[MealIngredients] ([Id], [MealId], [IngredientId]) VALUES (1024, 1008, 1018)
INSERT [dbo].[MealIngredients] ([Id], [MealId], [IngredientId]) VALUES (1025, 1008, 1019)
SET IDENTITY_INSERT [dbo].[MealIngredients] OFF
GO
SET IDENTITY_INSERT [dbo].[UserMeals] ON 

INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (3, 3, 1, 2, 2)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1002, 1007, 3, 2, 2)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1006, 1004, 3, 1002, 2)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1007, 1005, 2, 1002, 2)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1008, 1003, 1, 1002, 2)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1010, 1006, 2, 1003, 2)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1012, 1005, 3, 1004, 2)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1013, 1002, 1, 1004, 2)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1014, 1003, 2, 1004, 2)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1015, 1008, 1, 2, 3)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1016, 1006, 3, 2, 3)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1017, 1007, 2, 2, 3)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1018, 1002, 3, 1002, 3)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1019, 1003, 2, 1003, 3)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1020, 1003, 1, 1002, 3)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1021, 1006, 1, 1003, 3)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1022, 1005, 3, 1004, 3)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1023, 1002, 1, 1003, 3)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1024, 1003, 2, 1004, 3)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1025, 3, 1, 2, 1)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1026, 3, 3, 2, 1)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1027, 3, 2, 2, 1)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1028, 1006, 3, 1002, 1)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1029, 1006, 2, 1002, 1)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1030, 1004, 1, 1002, 1)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1031, 1006, 2, 1003, 1)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1032, 3, 3, 1004, 1)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1033, 1002, 1, 1004, 1)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1034, 1002, 2, 1004, 1)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1054, 1005, 2, 2, 9)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1055, 1006, 2, 2, 9)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1056, 1005, 2, 2, 2)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1058, 1006, 2, 2, 10)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1059, 1005, 2, 1004, 11)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1065, 1002, 2, 2, 8)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1075, 1002, 2, 1002, 8)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1076, 1003, 2, 1002, 8)
INSERT [dbo].[UserMeals] ([Id], [MealId], [UserId], [SectionId], [ScheduleId]) VALUES (1077, 1006, 2, 2, 15)
SET IDENTITY_INSERT [dbo].[UserMeals] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211205171809_AB1', N'3.1.0')
GO
