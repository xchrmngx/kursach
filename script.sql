USE [aaaaaaa]
GO
/****** Object:  Table [dbo].[history]    Script Date: 25.01.2025 6:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[history](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[test_id] [int] NULL,
	[result] [nvarchar](50) NULL,
	[score] [int] NULL,
	[date] [date] NULL,
 CONSTRAINT [PK_history] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[material]    Script Date: 25.01.2025 6:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[material](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[type] [int] NULL,
	[page] [int] NULL,
 CONSTRAINT [PK_discipline] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[material_type]    Script Date: 25.01.2025 6:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[material_type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type_name] [nvarchar](50) NULL,
	[preview] [nvarchar](max) NULL,
	[description] [nvarchar](max) NULL,
 CONSTRAINT [PK_material_type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[questions]    Script Date: 25.01.2025 6:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[questions](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[test_id] [int] NULL,
	[question_id] [int] NULL,
	[question] [nvarchar](max) NULL,
	[variant1] [nvarchar](max) NULL,
	[variant2] [nvarchar](max) NULL,
	[variant3] [nvarchar](max) NULL,
	[answer] [nvarchar](max) NULL,
 CONSTRAINT [PK_questions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[test]    Script Date: 25.01.2025 6:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[test](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[material_id] [int] NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_test] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user_type]    Script Date: 25.01.2025 6:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_user_type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 25.01.2025 6:45:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[login] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[fio] [nvarchar](50) NULL,
	[type] [int] NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[history] ON 

INSERT [dbo].[history] ([id], [user_id], [test_id], [result], [score], [date]) VALUES (3, 1, 1, N'Сдан', 5, CAST(N'2025-01-25' AS Date))
SET IDENTITY_INSERT [dbo].[history] OFF
GO
SET IDENTITY_INSERT [dbo].[material] ON 

INSERT [dbo].[material] ([id], [name], [type], [page]) VALUES (1, N'Название исторически происходит от набора технических правил (так называемой «формулы»; при этом обозначение «Формула-1» — одна из нескольких таких «формул», наряду с «Формулой-2» и др.), которому должны соответствовать автомобили всех участников. С 1950 по 1980 год проводился чемпионат мира для гонщиков (англ. World Championship for Drivers), на смену которому в 1981 году пришёл чемпионат мира Формулы-1 (англ. Formula 1 World Championship), позже получивший современное название: FIA Formula One World Championship. Турнир находится под управлением Международной автомобильной федерации, а ответственной за коммерческое продвижение на данный момент является группа компаний Formula One Group. Чемпионат мира проводится каждый год и состоит из отдельных этапов, имеющих статус Гран-при, в конце года подводятся итоги турнира, с учётом суммы набранных за сезон очков. В Формуле-1 соревнуются как отдельные гонщики (за титул чемпиона мира среди гонщиков, также часто называемый в русском языке личным зачётом чемпионата мира или просто личным зачётом), так и отдельные команды (за титул чемпиона мира среди конструкторов, для которого в русском языке часто используется его историческое название «кубок конструкторов»). ', 1, 1)
INSERT [dbo].[material] ([id], [name], [type], [page]) VALUES (2, N'Техника участников должна соответствовать техническому регламенту Формулы-1 и пройти тест на ударопрочность. Команды, участвующие в гонках Формулы-1, используют на Гран-при гоночные автомобили собственного производства. Таким образом, задачей команды является не только нанять быстрого и опытного гонщика и обеспечить грамотную настройку и обслуживание машины, но и вообще самостоятельно спроектировать и сконструировать машину. Но бывают и исключения. Например, шасси команд Red Bull Racing и Scuderia Toro Rosso (с 2024 RB) были очень похожи, почти идентичны, вплоть до 2009 года. Они были спроектированы и изготовлены компанией Red Bull Technology, так как обе команды и компания-изготовитель принадлежат концерну Red Bull GmbH. ', 1, 2)
INSERT [dbo].[material] ([id], [name], [type], [page]) VALUES (3, N'Поскольку команды строят машины по собственным технологиям, и ввиду высокой конкуренции команд, в Формуле-1 постоянно появляются оригинальные технические решения, что ведёт к прогрессу как гоночных машин, так и дорожных автомобилей.', 1, 3)
INSERT [dbo].[material] ([id], [name], [type], [page]) VALUES (4, N'Каждая команда сама создаёт шасси для своего автомобиля. Моторы могут быть приобретены у стороннего производителя. За соответствием машин техническому регламенту следят стюарды Международной федерации автоспорта. От каждой команды в каждом Гран-при должны выступать два гонщика, при этом раскраска машин должна быть одинаковой (за исключением номеров). Гран-при проводится с пятницы по воскресенье (за исключением Гран-при Монако, где до 2022 года вместо пятницы свободные заезды проходили в четверг, а также Гран-при Лас-Вегаса, где в 2023 году впервые после Гран-при ЮАР 1985 года, все заезды проходят на день раньше: с четверга по субботу, и соответственно, основная гонка проходит в субботу, а не в воскресенье) и состоит из свободных заездов, квалификации и гонки. Сезон состоит из различного количества Гран-при: от 7 в 1950 до 22 в 2021—2023 и обычно проводится с марта по ноябрь.', 1, 4)
INSERT [dbo].[material] ([id], [name], [type], [page]) VALUES (5, N'За первые 10 мест на финише гонки пилоты и команды получают очки по системе 25—18—15—12—10—8—6—4—2—1. Одно дополнительное очко получает гонщик, прошедший самый быстрый круг в гонке (при условии финиша в «очковой зоне» — то есть в первой десятке финишировавших). Трое первых гонщиков поднимаются на подиум. В честь победителя звучит гимн государства, по лицензии автоклуба которого он выступает, а затем — гимн страны команды-победителя. Под страной команды-победителя подразумевается государство, автоклуб которого выдал ей лицензию на участие. Если страна пилота и страна команды-победителя совпадают, гимн играется один раз.     На некоторых Гран-при квалификация проходит в пятницу, а в субботу дополнительно проводится спринт — укороченная гонка примерно на 100 километров, — а также квалификация к нему. В таком случае основная квалификация распределяет места на основной гонке, а спринт (и квалификация к нему) оказывается отдельным мини-Гран-при, как некая «вещь в себе» в рамках гоночного уик-энда. За финиш в спринте на первых восьми местах гонщикам и командам начисляются очки по системе 8—7—6—5—4—3—2—1. Очки, набранные каждым пилотом во всех гонках в течение сезона, суммируются и используются для присвоения титула чемпиона мира по окончании сезона; очки всех выступавших за каждую команду гонщиков также суммируются и используются для определения команды-победителя в борьбе за кубок конструкторов.', 1, 5)
INSERT [dbo].[material] ([id], [name], [type], [page]) VALUES (6, N'material2asdfasdf2', 2, 1)
SET IDENTITY_INSERT [dbo].[material] OFF
GO
SET IDENTITY_INSERT [dbo].[material_type] ON 

INSERT [dbo].[material_type] ([id], [type_name], [preview], [description]) VALUES (1, N'F1', N'f1.png', N'чемпионат мира по кольцевым автогонкам, который проводится ежегодно и состоит из этапов (называемых Гран-при), в соответствии с техническими нормами, требованиями и правилами, установленными Международной автомобильной федерацией (ФИА, англ. FIA).')
INSERT [dbo].[material_type] ([id], [type_name], [preview], [description]) VALUES (2, N'F2', N'F2_logo.png', N'Формула-2 разработана для того, чтобы сделать гонки относительно доступными для команд и превратить их в идеальную тренировочную площадку для жизни в Формуле-1. Серия является специальной серией; все команды обязаны использовать одно и то же шасси, двигатель и поставщика шин. Формула-2 в основном участвует в гонках на европейских и ближневосточных трассах, но выступает и на других международных гоночных трассах, таких как трасса Альберт-Парк в Австралии. ')
INSERT [dbo].[material_type] ([id], [type_name], [preview], [description]) VALUES (3, N'F3', N'f3_logo.png', N'это чемпионат Международной автомобильной федерации, который проводится с 2019 года. Формат этапов похож на тот, что используется в Формуле-2: в пятницу проводится 45-минутная тренировочная сессия и 30-минутная квалификация. За ними следуют субботняя спринтерская гонка и одна основная воскресная. Дистанция обоих заездов устанавливается заранее, субботний спринт не должен длиться более 40 минут, а воскресная гонка — не более 45 минут.')
INSERT [dbo].[material_type] ([id], [type_name], [preview], [description]) VALUES (4, N'Formula E', N'fe_logo.png', N'eto fe')
SET IDENTITY_INSERT [dbo].[material_type] OFF
GO
SET IDENTITY_INSERT [dbo].[questions] ON 

INSERT [dbo].[questions] ([id], [test_id], [question_id], [question], [variant1], [variant2], [variant3], [answer]) VALUES (1, 1, 1, N'Что такое формула-1?', N'Чемпионат мира по кольцевым автогонкам.', N'Чемпионат мира по дрифту.', N'Чемпионат мира по мото-кроссу.', N'Чемпионат мира по кольцевым автогонкам.')
INSERT [dbo].[questions] ([id], [test_id], [question_id], [question], [variant1], [variant2], [variant3], [answer]) VALUES (2, 1, 2, N'На чем участвуют пилоты?', N'Арендуют у других команд.', N'Каждая команда сама создает шасси для своего автомобиля и использует его в гонках.', N'Покупают в автосалонах.', N'Каждая команда сама создает шасси для своего автомобиля и использует его в гонках.')
INSERT [dbo].[questions] ([id], [test_id], [question_id], [question], [variant1], [variant2], [variant3], [answer]) VALUES (3, 1, 3, N'Кто является действующим чемпионом?', N'Lando Norris', N'Lewis Hamilton', N'Max Verstappen', N'Max Verstappen')
INSERT [dbo].[questions] ([id], [test_id], [question_id], [question], [variant1], [variant2], [variant3], [answer]) VALUES (4, 1, 4, N'Кто главный поставщик шин в Формуле 1?', N'Pirelli', N'Toyo Tires', N'Yokohama', N'Pirelli')
INSERT [dbo].[questions] ([id], [test_id], [question_id], [question], [variant1], [variant2], [variant3], [answer]) VALUES (5, 1, 5, N'Какая команда является действующим чемпионом?', N'BWT', N'Mercedes AMG Petronas', N'McLaren', N'McLaren')
SET IDENTITY_INSERT [dbo].[questions] OFF
GO
SET IDENTITY_INSERT [dbo].[test] ON 

INSERT [dbo].[test] ([id], [material_id], [name]) VALUES (1, 1, N'test1')
INSERT [dbo].[test] ([id], [material_id], [name]) VALUES (2, 2, N'test2')
SET IDENTITY_INSERT [dbo].[test] OFF
GO
SET IDENTITY_INSERT [dbo].[user_type] ON 

INSERT [dbo].[user_type] ([id], [type_name]) VALUES (1, N'user')
INSERT [dbo].[user_type] ([id], [type_name]) VALUES (2, N'admin')
SET IDENTITY_INSERT [dbo].[user_type] OFF
GO
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([id], [login], [password], [fio], [type]) VALUES (0, N'asdf', N'sadf', N'sadf', 1)
INSERT [dbo].[users] ([id], [login], [password], [fio], [type]) VALUES (1, N'user', N'user', N'fio', 1)
INSERT [dbo].[users] ([id], [login], [password], [fio], [type]) VALUES (2, N'admin', N'admin', N'fio', 2)
INSERT [dbo].[users] ([id], [login], [password], [fio], [type]) VALUES (3, N'asdf', N'asdf', N'asdf', 1)
SET IDENTITY_INSERT [dbo].[users] OFF
GO
ALTER TABLE [dbo].[history]  WITH CHECK ADD  CONSTRAINT [FK_history_test] FOREIGN KEY([test_id])
REFERENCES [dbo].[test] ([id])
GO
ALTER TABLE [dbo].[history] CHECK CONSTRAINT [FK_history_test]
GO
ALTER TABLE [dbo].[history]  WITH CHECK ADD  CONSTRAINT [FK_history_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[history] CHECK CONSTRAINT [FK_history_users]
GO
ALTER TABLE [dbo].[material]  WITH CHECK ADD  CONSTRAINT [FK_material_material_type] FOREIGN KEY([type])
REFERENCES [dbo].[material_type] ([id])
GO
ALTER TABLE [dbo].[material] CHECK CONSTRAINT [FK_material_material_type]
GO
ALTER TABLE [dbo].[questions]  WITH CHECK ADD  CONSTRAINT [FK_questions_test] FOREIGN KEY([test_id])
REFERENCES [dbo].[test] ([id])
GO
ALTER TABLE [dbo].[questions] CHECK CONSTRAINT [FK_questions_test]
GO
ALTER TABLE [dbo].[test]  WITH CHECK ADD  CONSTRAINT [FK_test_material] FOREIGN KEY([material_id])
REFERENCES [dbo].[material] ([id])
GO
ALTER TABLE [dbo].[test] CHECK CONSTRAINT [FK_test_material]
GO
ALTER TABLE [dbo].[test]  WITH CHECK ADD  CONSTRAINT [FK_test_material_type] FOREIGN KEY([material_id])
REFERENCES [dbo].[material_type] ([id])
GO
ALTER TABLE [dbo].[test] CHECK CONSTRAINT [FK_test_material_type]
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK_users_user_type] FOREIGN KEY([type])
REFERENCES [dbo].[user_type] ([id])
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_users_user_type]
GO
