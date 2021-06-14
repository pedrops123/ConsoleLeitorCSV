USE [TesteDB]
GO
/****** Object:  Table [dbo].[tblCliente]    Script Date: 13/11/2020 15:02:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCliente](
	[CodCliente] [int] IDENTITY(1,1) NOT NULL,
	[DescCliente] [varchar](500) NULL,
	[CodPais] [int] NULL,
	[DDD] [varchar](10) NULL,
	[Fone] [varchar](50) NULL,
	[CodSexo] [int] NULL,
	[Email] [varchar](1000) NULL,
	/* Campos atividade ex  C# e ASP.NET  - 1  - 14/06 - Pedro Furlan */
	[Endereco][varchar](1000) NULL,
	[Cidade][varchar](1000) NULL
 CONSTRAINT [PK_tblCliente] PRIMARY KEY CLUSTERED 
(
	[CodCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPais]    Script Date: 13/11/2020 15:02:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPais](
	[CodPais] [int] IDENTITY(1,1) NOT NULL,
	[DescPais] [varchar](50) NULL,
 CONSTRAINT [PK_tblPais] PRIMARY KEY CLUSTERED 
(
	[CodPais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPedido]    Script Date: 13/11/2020 15:02:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPedido](
	[CodPedido] [int] IDENTITY(1,1) NOT NULL,
	[CodCliente] [int] NULL,
	[QtdPedidos] [int] NULL,
 CONSTRAINT [PK_tblPedidos] PRIMARY KEY CLUSTERED 
(
	[CodPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblQuestao]    Script Date: 13/11/2020 15:02:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblQuestao](
	[CodQuestao] [int] IDENTITY(1,1) NOT NULL,
	[DescQuestao] [varchar](500) NULL,
 CONSTRAINT [PK_tblQuestao] PRIMARY KEY CLUSTERED 
(
	[CodQuestao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblQuestaoOpcao]    Script Date: 13/11/2020 15:02:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblQuestaoOpcao](
	[CodQuestaoOpcao] [int] IDENTITY(1,1) NOT NULL,
	[CodQuestao] [int] NOT NULL,
	[CodOpcao] [int] NOT NULL,
	[DescOpcao] [varchar](50) NULL,
 CONSTRAINT [PK_tblQuestaoOpcao_1] PRIMARY KEY CLUSTERED 
(
	[CodQuestaoOpcao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblResposta]    Script Date: 13/11/2020 15:02:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblResposta](
	[CodResposta] [int] IDENTITY(1,1) NOT NULL,
	[CodCliente] [int] NOT NULL,
	[CodQuestaoOpcao] [int] NOT NULL,
 CONSTRAINT [PK_tblResposta_1] PRIMARY KEY CLUSTERED 
(
	[CodResposta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSexo]    Script Date: 13/11/2020 15:02:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSexo](
	[CodSexo] [int] IDENTITY(1,1) NOT NULL,
	[DescSexo] [varchar](50) NULL,
 CONSTRAINT [PK_tblSexo] PRIMARY KEY CLUSTERED 
(
	[CodSexo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblCliente]  WITH CHECK ADD  CONSTRAINT [FK_tblCliente_tblPais] FOREIGN KEY([CodPais])
REFERENCES [dbo].[tblPais] ([CodPais])
GO
ALTER TABLE [dbo].[tblCliente] CHECK CONSTRAINT [FK_tblCliente_tblPais]
GO
ALTER TABLE [dbo].[tblCliente]  WITH CHECK ADD  CONSTRAINT [FK_tblCliente_tblSexo] FOREIGN KEY([CodSexo])
REFERENCES [dbo].[tblSexo] ([CodSexo])
GO
ALTER TABLE [dbo].[tblCliente] CHECK CONSTRAINT [FK_tblCliente_tblSexo]
GO
ALTER TABLE [dbo].[tblPedido]  WITH CHECK ADD  CONSTRAINT [FK_tblPedidos_tblPedidos] FOREIGN KEY([CodPedido])
REFERENCES [dbo].[tblPedido] ([CodPedido])
GO
ALTER TABLE [dbo].[tblPedido] CHECK CONSTRAINT [FK_tblPedidos_tblPedidos]
GO
ALTER TABLE [dbo].[tblQuestaoOpcao]  WITH CHECK ADD  CONSTRAINT [FK_tblQuestaoOpcao_tblQuestao] FOREIGN KEY([CodQuestao])
REFERENCES [dbo].[tblQuestao] ([CodQuestao])
GO
ALTER TABLE [dbo].[tblQuestaoOpcao] CHECK CONSTRAINT [FK_tblQuestaoOpcao_tblQuestao]
GO
ALTER TABLE [dbo].[tblResposta]  WITH CHECK ADD  CONSTRAINT [FK_tblResposta_tblCliente] FOREIGN KEY([CodCliente])
REFERENCES [dbo].[tblCliente] ([CodCliente])
GO
ALTER TABLE [dbo].[tblResposta] CHECK CONSTRAINT [FK_tblResposta_tblCliente]
GO
ALTER TABLE [dbo].[tblResposta]  WITH CHECK ADD  CONSTRAINT [FK_tblResposta_tblQuestaoOpcao] FOREIGN KEY([CodQuestaoOpcao])
REFERENCES [dbo].[tblQuestaoOpcao] ([CodQuestaoOpcao])
GO
ALTER TABLE [dbo].[tblResposta] CHECK CONSTRAINT [FK_tblResposta_tblQuestaoOpcao]
GO
