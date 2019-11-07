BEGIN TRAN T1;

	CREATE TABLE [dbo].[Article] (
		[Id]    INT           NOT NULL PRIMARY KEY,
		[Title] NVARCHAR (50) NOT NULL
	);

	CREATE TABLE [dbo].[Tag] (
		[Id]  INT           NOT NULL PRIMARY KEY,
		[Tag] NVARCHAR (50) NOT NULL
	);

	CREATE TABLE [dbo].[ArticlesWithTags] (
		[ArticleId] INT NOT NULL,
		[TagId]     INT NOT NULL,
		CONSTRAINT [FK_ArticlesWithTags_ToArcticle] FOREIGN KEY ([ArticleId]) REFERENCES [dbo].[Article]([Id]),
		CONSTRAINT [FK_ArticlesWithTags_ToTag] FOREIGN KEY ([TagId]) REFERENCES [dbo].[Tag]([Id])
	);

	INSERT INTO [dbo].[Article] ([Id], [Title]) VALUES (1, N'Дорожная ситуация')
	INSERT INTO [dbo].[Article] ([Id], [Title]) VALUES (2, N'Новые санкции')
	INSERT INTO [dbo].[Article] ([Id], [Title]) VALUES (3, N'Найден самый вкусный сыр')
	INSERT INTO [dbo].[Article] ([Id], [Title]) VALUES (4, N'Тема без тегов')

	INSERT INTO [dbo].[Tag] ([Id], [Tag]) VALUES (1, N'Авто')
	INSERT INTO [dbo].[Tag] ([Id], [Tag]) VALUES (2, N'Дороги')
	INSERT INTO [dbo].[Tag] ([Id], [Tag]) VALUES (3, N'Россия')
	INSERT INTO [dbo].[Tag] ([Id], [Tag]) VALUES (4, N'Политика')
	INSERT INTO [dbo].[Tag] ([Id], [Tag]) VALUES (5, N'Еда')

	INSERT INTO [dbo].[ArticlesWithTags] ([ArticleId], [TagId]) VALUES (1, 3)
	INSERT INTO [dbo].[ArticlesWithTags] ([ArticleId], [TagId]) VALUES (1, 1)
	INSERT INTO [dbo].[ArticlesWithTags] ([ArticleId], [TagId]) VALUES (1, 2)
	INSERT INTO [dbo].[ArticlesWithTags] ([ArticleId], [TagId]) VALUES (2, 3)
	INSERT INTO [dbo].[ArticlesWithTags] ([ArticleId], [TagId]) VALUES (2, 4)
	INSERT INTO [dbo].[ArticlesWithTags] ([ArticleId], [TagId]) VALUES (3, 5)


	-- test query
	SELECT art.Title, COALESCE(tag.Tag,'')
	FROM dbo.Tag tag
	INNER join dbo.ArticlesWithTags link on link.TagId = tag.Id
	RIGHT JOIN dbo.Article art on art.Id = link.ArticleId

COMMIT TRAN T1;

