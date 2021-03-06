USE [UniSales]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 23.3.2021. 16:56:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 23.3.2021. 16:56:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[Street] [nvarchar](max) NULL,
	[Number] [nvarchar](max) NULL,
	[ZipCode] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 23.3.2021. 16:56:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactInfos]    Script Date: 23.3.2021. 16:56:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactInfos](
	[ContactInfoId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Message] [nvarchar](max) NULL,
 CONSTRAINT [PK_ContactInfos] PRIMARY KEY CLUSTERED 
(
	[ContactInfoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 23.3.2021. 16:56:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [nvarchar](450) NOT NULL,
	[OrderTotal] [decimal](18, 2) NOT NULL,
	[AddressId] [int] NULL,
	[UserId] [nvarchar](max) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 23.3.2021. 16:56:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ShortDescription] [nvarchar](500) NULL,
	[LongDescription] [nvarchar](2000) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[ImageUrl] [nvarchar](max) NOT NULL,
	[ImageThumbnailUrl] [nvarchar](max) NOT NULL,
	[IsProductOfTheWeek] [bit] NOT NULL,
	[InStock] [bit] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[OrderId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShoppingCartItems]    Script Date: 23.3.2021. 16:56:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShoppingCartItems](
	[ShoppingCartItemId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[ShoppingCartId] [int] NOT NULL,
 CONSTRAINT [PK_ShoppingCartItems] PRIMARY KEY CLUSTERED 
(
	[ShoppingCartItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShoppingCarts]    Script Date: 23.3.2021. 16:56:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShoppingCarts](
	[ShoppingCartId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](max) NULL,
 CONSTRAINT [PK_ShoppingCarts] PRIMARY KEY CLUSTERED 
(
	[ShoppingCartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210323131022_InitialCreate', N'5.0.4')
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Description]) VALUES (1, N'Kategorija 1', NULL)
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Description]) VALUES (2, N'Kategorija 2', NULL)
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Description]) VALUES (3, N'Kategorija 3', NULL)
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[ContactInfos] ON 

INSERT [dbo].[ContactInfos] ([ContactInfoId], [Email], [Message]) VALUES (1, N'string', N'string')
SET IDENTITY_INSERT [dbo].[ContactInfos] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductId], [Name], [ShortDescription], [LongDescription], [Price], [ImageUrl], [ImageThumbnailUrl], [IsProductOfTheWeek], [InStock], [CategoryId], [OrderId]) VALUES (1, N'Proizvod 1', N'Kratak opis proizvoda', N'Detaljan opis proizvoda', CAST(12.95 AS Decimal(18, 2)), N'https://www.pizzacorner.rs/imgs_android/1.jpg', N'https://www.pizzacorner.rs/imgs_android/1.jpg', 1, 1, 1, NULL)
INSERT [dbo].[Products] ([ProductId], [Name], [ShortDescription], [LongDescription], [Price], [ImageUrl], [ImageThumbnailUrl], [IsProductOfTheWeek], [InStock], [CategoryId], [OrderId]) VALUES (2, N'Proizvod 2', N'Kratak opis proizvoda', N'Detaljan opis proizvoda', CAST(18.95 AS Decimal(18, 2)), N'https://www.pizzacorner.rs/imgs_android/2.jpg', N'https://www.pizzacorner.rs/imgs_android/2.jpg', 0, 1, 1, NULL)
INSERT [dbo].[Products] ([ProductId], [Name], [ShortDescription], [LongDescription], [Price], [ImageUrl], [ImageThumbnailUrl], [IsProductOfTheWeek], [InStock], [CategoryId], [OrderId]) VALUES (3, N'Proizvod 3', N'Kratak opis proizvoda', N'Detaljan opis proizvoda', CAST(18.95 AS Decimal(18, 2)), N'https://www.pizzacorner.rs/imgs_android/3.jpg', N'https://www.pizzacorner.rs/imgs_android/3.jpg', 0, 1, 1, NULL)
INSERT [dbo].[Products] ([ProductId], [Name], [ShortDescription], [LongDescription], [Price], [ImageUrl], [ImageThumbnailUrl], [IsProductOfTheWeek], [InStock], [CategoryId], [OrderId]) VALUES (4, N'Proizvod 4', N'Kratak opis proizvoda', N'Detaljan opis proizvoda', CAST(15.95 AS Decimal(18, 2)), N'https://www.pizzacorner.rs/imgs_android/4.jpg', N'https://www.pizzacorner.rs/imgs_android/4.jpg', 0, 1, 2, NULL)
INSERT [dbo].[Products] ([ProductId], [Name], [ShortDescription], [LongDescription], [Price], [ImageUrl], [ImageThumbnailUrl], [IsProductOfTheWeek], [InStock], [CategoryId], [OrderId]) VALUES (5, N'Proizvod 5', N'Kratak opis proizvoda', N'Detaljan opis proizvoda', CAST(13.95 AS Decimal(18, 2)), N'https://www.pizzacorner.rs/imgs_android/5.jpg', N'https://www.pizzacorner.rs/imgs_android/5.jpg', 0, 1, 2, NULL)
INSERT [dbo].[Products] ([ProductId], [Name], [ShortDescription], [LongDescription], [Price], [ImageUrl], [ImageThumbnailUrl], [IsProductOfTheWeek], [InStock], [CategoryId], [OrderId]) VALUES (6, N'Proizvod 6', N'Kratak opis proizvoda', N'Detaljan opis proizvoda', CAST(17.95 AS Decimal(18, 2)), N'https://www.pizzacorner.rs/imgs_android/6.jpg', N'https://www.pizzacorner.rs/imgs_android/6.jpg', 0, 1, 2, NULL)
INSERT [dbo].[Products] ([ProductId], [Name], [ShortDescription], [LongDescription], [Price], [ImageUrl], [ImageThumbnailUrl], [IsProductOfTheWeek], [InStock], [CategoryId], [OrderId]) VALUES (7, N'Proizvod 7', N'Kratak opis proizvoda', N'Detaljan opis proizvoda', CAST(15.95 AS Decimal(18, 2)), N'https://www.pizzacorner.rs/imgs_android/7.jpg', N'https://www.pizzacorner.rs/imgs_android/7.jpg', 0, 0, 2, NULL)
INSERT [dbo].[Products] ([ProductId], [Name], [ShortDescription], [LongDescription], [Price], [ImageUrl], [ImageThumbnailUrl], [IsProductOfTheWeek], [InStock], [CategoryId], [OrderId]) VALUES (8, N'Proizvod 8', N'Kratak opis proizvoda', N'Detaljan opis proizvoda', CAST(12.95 AS Decimal(18, 2)), N'https://www.pizzacorner.rs/imgs_android/8.jpg', N'https://www.pizzacorner.rs/imgs_android/8.jpg', 1, 1, 3, NULL)
INSERT [dbo].[Products] ([ProductId], [Name], [ShortDescription], [LongDescription], [Price], [ImageUrl], [ImageThumbnailUrl], [IsProductOfTheWeek], [InStock], [CategoryId], [OrderId]) VALUES (9, N'Proizvod 9', N'Kratak opis proizvoda', N'Detaljan opis proizvoda', CAST(15.95 AS Decimal(18, 2)), N'https://www.pizzacorner.rs/imgs_android/9.jpg', N'https://www.pizzacorner.rs/imgs_android/9.jpg', 1, 1, 3, NULL)
INSERT [dbo].[Products] ([ProductId], [Name], [ShortDescription], [LongDescription], [Price], [ImageUrl], [ImageThumbnailUrl], [IsProductOfTheWeek], [InStock], [CategoryId], [OrderId]) VALUES (10, N'Proizvod 10', N'Kratak opis proizvoda', N'Detaljan opis proizvoda', CAST(15.95 AS Decimal(18, 2)), N'https://www.pizzacorner.rs/imgs_android/10.jpg', N'https://www.pizzacorner.rs/imgs_android/10.jpg', 0, 1, 3, NULL)
INSERT [dbo].[Products] ([ProductId], [Name], [ShortDescription], [LongDescription], [Price], [ImageUrl], [ImageThumbnailUrl], [IsProductOfTheWeek], [InStock], [CategoryId], [OrderId]) VALUES (11, N'Proizvod 11', N'Kratak opis proizvoda', N'Detaljan opis proizvoda', CAST(18.95 AS Decimal(18, 2)), N'https://www.pizzacorner.rs/imgs_android/12.jpg', N'https://www.pizzacorner.rs/imgs_android/11.jpg', 0, 0, 3, NULL)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[ShoppingCartItems] ON 

INSERT [dbo].[ShoppingCartItems] ([ShoppingCartItemId], [ProductId], [Quantity], [ShoppingCartId]) VALUES (1, 1, 1, 1)
INSERT [dbo].[ShoppingCartItems] ([ShoppingCartItemId], [ProductId], [Quantity], [ShoppingCartId]) VALUES (2, 1, 1, 1)
INSERT [dbo].[ShoppingCartItems] ([ShoppingCartItemId], [ProductId], [Quantity], [ShoppingCartId]) VALUES (3, 1, 1, 2)
SET IDENTITY_INSERT [dbo].[ShoppingCartItems] OFF
GO
SET IDENTITY_INSERT [dbo].[ShoppingCarts] ON 

INSERT [dbo].[ShoppingCarts] ([ShoppingCartId], [UserId]) VALUES (1, N'250df9d7-822d-43a5-b97c-3eb58f8ff33b')
INSERT [dbo].[ShoppingCarts] ([ShoppingCartId], [UserId]) VALUES (2, N'1a161842-d023-45ef-bba3-bfddfb5cb798')
INSERT [dbo].[ShoppingCarts] ([ShoppingCartId], [UserId]) VALUES (3, N'd3942882-6aae-438e-a0e0-621729d43393')
SET IDENTITY_INSERT [dbo].[ShoppingCarts] OFF
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Addresses_AddressId] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([AddressId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Addresses_AddressId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Category_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Category_CategoryId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Orders_OrderId]
GO
ALTER TABLE [dbo].[ShoppingCartItems]  WITH CHECK ADD  CONSTRAINT [FK_ShoppingCartItems_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ShoppingCartItems] CHECK CONSTRAINT [FK_ShoppingCartItems_Products_ProductId]
GO
ALTER TABLE [dbo].[ShoppingCartItems]  WITH CHECK ADD  CONSTRAINT [FK_ShoppingCartItems_ShoppingCarts_ShoppingCartId] FOREIGN KEY([ShoppingCartId])
REFERENCES [dbo].[ShoppingCarts] ([ShoppingCartId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ShoppingCartItems] CHECK CONSTRAINT [FK_ShoppingCartItems_ShoppingCarts_ShoppingCartId]
GO
