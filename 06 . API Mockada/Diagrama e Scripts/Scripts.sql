USE [API_MOCKADA]
GO
/****** Object:  Table [dbo].[Carros]    Script Date: 04/12/2021 12:59:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carros](
	[IdCarro] [int] IDENTITY(1,1) NOT NULL,
	[Placa] [varchar](8) NOT NULL,
	[Ano] [int] NOT NULL,
	[Cor] [varchar](20) NULL,
	[Municipio] [varchar](100) NOT NULL,
	[Marca] [varchar](50) NOT NULL,
	[Modelo] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCarro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Carros] ON 

INSERT [dbo].[Carros] ([IdCarro], [Placa], [Ano], [Cor], [Municipio], [Marca], [Modelo]) VALUES (1, N'FRD4486', 2015, N'Branco', N'São Paulo', N'Mercedes', N'AMG4')
INSERT [dbo].[Carros] ([IdCarro], [Placa], [Ano], [Cor], [Municipio], [Marca], [Modelo]) VALUES (2, N'JRK4601', 2008, N'Prata', N'São Paulo', N'Nissan', N'Sentra')
INSERT [dbo].[Carros] ([IdCarro], [Placa], [Ano], [Cor], [Municipio], [Marca], [Modelo]) VALUES (3, N'CNN8572', 1998, N'Prata', N'São Paulo', N'Chevrolet', N'Corsa')
SET IDENTITY_INSERT [dbo].[Carros] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Carros__8310F99DD927F81F]    Script Date: 04/12/2021 12:59:43 ******/
ALTER TABLE [dbo].[Carros] ADD UNIQUE NONCLUSTERED 
(
	[Placa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
