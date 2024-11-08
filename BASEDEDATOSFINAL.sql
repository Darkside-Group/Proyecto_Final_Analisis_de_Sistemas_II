USE [master]
GO
/****** Object:  Database [Inventario]    Script Date: 1/11/2024 21:14:19 ******/
CREATE DATABASE [Inventario]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Inventario', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Inventario.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Inventario_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Inventario_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Inventario] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Inventario].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Inventario] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Inventario] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Inventario] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Inventario] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Inventario] SET ARITHABORT OFF 
GO
ALTER DATABASE [Inventario] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Inventario] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Inventario] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Inventario] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Inventario] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Inventario] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Inventario] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Inventario] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Inventario] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Inventario] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Inventario] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Inventario] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Inventario] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Inventario] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Inventario] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Inventario] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Inventario] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Inventario] SET RECOVERY FULL 
GO
ALTER DATABASE [Inventario] SET  MULTI_USER 
GO
ALTER DATABASE [Inventario] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Inventario] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Inventario] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Inventario] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Inventario] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Inventario] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Inventario', N'ON'
GO
ALTER DATABASE [Inventario] SET QUERY_STORE = ON
GO
ALTER DATABASE [Inventario] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Inventario]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/11/2024 21:14:19 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CitasDeMascotas]    Script Date: 1/11/2024 21:14:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CitasDeMascotas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPerfilMascota] [int] NOT NULL,
	[FechaCita] [datetime] NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventarioPorMes]    Script Date: 1/11/2024 21:14:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventarioPorMes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Mes] [nvarchar](max) NOT NULL,
	[CantidadInicial] [int] NOT NULL,
	[CantidadVendidaMes] [int] NOT NULL,
	[CantidadFinal] [int] NOT NULL,
 CONSTRAINT [PK_InventarioPorMes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PetObservations]    Script Date: 1/11/2024 21:14:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PetObservations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PetProfileId] [int] NOT NULL,
	[ObservationDate] [datetime] NOT NULL,
	[ObservationText] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PetProfiles]    Script Date: 1/11/2024 21:14:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PetProfiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Edad] [int] NOT NULL,
	[Raza] [nvarchar](50) NOT NULL,
	[Peso] [float] NOT NULL,
	[Observaciones] [nvarchar](max) NULL,
	[Medicamento] [nvarchar](max) NULL,
	[ProximaCita] [date] NULL,
	[GastoDelDia] [float] NOT NULL,
	[NombreDueno] [nvarchar](100) NOT NULL,
	[Telefono] [nvarchar](15) NOT NULL,
	[Dpi] [nvarchar](20) NOT NULL,
	[EdadDueno] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 1/11/2024 21:14:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Informacion] [nvarchar](max) NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[FechaIngreso] [datetime2](7) NOT NULL,
	[FechaExpiracion] [datetime2](7) NOT NULL,
	[Cantidad] [int] NOT NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 1/11/2024 21:14:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 1/11/2024 21:14:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[RoleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ventas]    Script Date: 1/11/2024 21:14:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ventas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductoId] [int] NOT NULL,
	[CantidadVendida] [int] NOT NULL,
	[FechaVenta] [datetime] NOT NULL,
	[CantidadActual] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VentasDiarias]    Script Date: 1/11/2024 21:14:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VentasDiarias](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdProducto] [int] NOT NULL,
	[FechaVenta] [datetime2](7) NOT NULL,
	[CantidadVendida] [int] NOT NULL,
	[PrecioTotal] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_VentasDiarias] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CitasDeMascotas] ON 

INSERT [dbo].[CitasDeMascotas] ([Id], [IdPerfilMascota], [FechaCita], [Descripcion]) VALUES (1, 1, CAST(N'2024-12-01T00:00:00.000' AS DateTime), N'Mejora')
INSERT [dbo].[CitasDeMascotas] ([Id], [IdPerfilMascota], [FechaCita], [Descripcion]) VALUES (2, 1, CAST(N'2024-11-01T18:51:33.023' AS DateTime), N'Debe mejorar los sintomas con la medicina que le dimos! ')
INSERT [dbo].[CitasDeMascotas] ([Id], [IdPerfilMascota], [FechaCita], [Descripcion]) VALUES (3, 1, CAST(N'2024-11-08T00:00:00.000' AS DateTime), N'1123')
INSERT [dbo].[CitasDeMascotas] ([Id], [IdPerfilMascota], [FechaCita], [Descripcion]) VALUES (4, 1, CAST(N'2024-11-30T00:00:00.000' AS DateTime), N'123123123123123')
INSERT [dbo].[CitasDeMascotas] ([Id], [IdPerfilMascota], [FechaCita], [Descripcion]) VALUES (6, 4, CAST(N'2024-11-19T00:00:00.000' AS DateTime), N'Debe traer la tarjeta del gato')
SET IDENTITY_INSERT [dbo].[CitasDeMascotas] OFF
GO
SET IDENTITY_INSERT [dbo].[PetObservations] ON 

INSERT [dbo].[PetObservations] ([Id], [PetProfileId], [ObservationDate], [ObservationText]) VALUES (1, 1, CAST(N'2024-11-01T00:00:00.000' AS DateTime), N'Necesita mas docis de medicamento!')
INSERT [dbo].[PetObservations] ([Id], [PetProfileId], [ObservationDate], [ObservationText]) VALUES (4, 1, CAST(N'2024-11-01T17:23:43.277' AS DateTime), N'El perro presenta nauseas')
INSERT [dbo].[PetObservations] ([Id], [PetProfileId], [ObservationDate], [ObservationText]) VALUES (5, 1, CAST(N'2024-11-01T00:00:00.000' AS DateTime), N'123')
INSERT [dbo].[PetObservations] ([Id], [PetProfileId], [ObservationDate], [ObservationText]) VALUES (6, 1, CAST(N'2024-11-01T18:51:33.023' AS DateTime), N'El perro sufre de moquillo')
INSERT [dbo].[PetObservations] ([Id], [PetProfileId], [ObservationDate], [ObservationText]) VALUES (7, 1, CAST(N'2024-11-02T00:00:00.000' AS DateTime), N'1')
INSERT [dbo].[PetObservations] ([Id], [PetProfileId], [ObservationDate], [ObservationText]) VALUES (8, 1, CAST(N'2024-11-01T00:00:00.000' AS DateTime), N'123123')
INSERT [dbo].[PetObservations] ([Id], [PetProfileId], [ObservationDate], [ObservationText]) VALUES (10, 4, CAST(N'2024-11-01T00:00:00.000' AS DateTime), N'Presenta mejoras en la columna')
SET IDENTITY_INSERT [dbo].[PetObservations] OFF
GO
SET IDENTITY_INSERT [dbo].[PetProfiles] ON 

INSERT [dbo].[PetProfiles] ([Id], [Nombre], [Edad], [Raza], [Peso], [Observaciones], [Medicamento], [ProximaCita], [GastoDelDia], [NombreDueno], [Telefono], [Dpi], [EdadDueno]) VALUES (1, N'Mack', 13, N'Beagle', 15, N'Primeras Revisiones', N'1', CAST(N'2024-11-04' AS Date), 1500, N'Kevin', N'44196128', N'0303505199', 22)
INSERT [dbo].[PetProfiles] ([Id], [Nombre], [Edad], [Raza], [Peso], [Observaciones], [Medicamento], [ProximaCita], [GastoDelDia], [NombreDueno], [Telefono], [Dpi], [EdadDueno]) VALUES (3, N'Toby', 11, N'French', 12, N'Pequeño y gordito', N'Pedilit', CAST(N'2024-11-21' AS Date), 1500, N'Sara', N'44559922', N'458919545', 27)
INSERT [dbo].[PetProfiles] ([Id], [Nombre], [Edad], [Raza], [Peso], [Observaciones], [Medicamento], [ProximaCita], [GastoDelDia], [NombreDueno], [Telefono], [Dpi], [EdadDueno]) VALUES (4, N'Felix', 11, N'Negro', 12, N'Malo de la columna', N'Yiodo', CAST(N'2024-11-16' AS Date), 1500, N'Chiris', N'55998877', N'123123534534', 22)
SET IDENTITY_INSERT [dbo].[PetProfiles] OFF
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([Id], [Nombre], [Informacion], [Precio], [FechaIngreso], [FechaExpiracion], [Cantidad]) VALUES (1, N'shacalaca', N'buenprecio', CAST(123.00 AS Decimal(18, 2)), CAST(N'2024-11-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-11-02T00:00:00.0000000' AS DateTime2), 75)
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (1, N'Administrador')
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (2, N'Jefe')
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (3, N'Empleado')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Password], [RoleId]) VALUES (1, N'kevin', N'esteban', N'kevinstb2711', N'kevin2001esteban', 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Ventas] ON 

INSERT [dbo].[Ventas] ([Id], [ProductoId], [CantidadVendida], [FechaVenta], [CantidadActual]) VALUES (1, 1, 100, CAST(N'2024-11-01T17:03:52.407' AS DateTime), 23)
INSERT [dbo].[Ventas] ([Id], [ProductoId], [CantidadVendida], [FechaVenta], [CantidadActual]) VALUES (2, 1, 23, CAST(N'2024-11-01T17:04:34.597' AS DateTime), 0)
INSERT [dbo].[Ventas] ([Id], [ProductoId], [CantidadVendida], [FechaVenta], [CantidadActual]) VALUES (3, 1, 5, CAST(N'2024-11-01T21:05:21.687' AS DateTime), 75)
SET IDENTITY_INSERT [dbo].[Ventas] OFF
GO
/****** Object:  Index [IX_InventarioPorMes_IdProducto]    Script Date: 1/11/2024 21:14:19 ******/
CREATE NONCLUSTERED INDEX [IX_InventarioPorMes_IdProducto] ON [dbo].[InventarioPorMes]
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__536C85E4F1FCD3F1]    Script Date: 1/11/2024 21:14:19 ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_VentasDiarias_IdProducto]    Script Date: 1/11/2024 21:14:19 ******/
CREATE NONCLUSTERED INDEX [IX_VentasDiarias_IdProducto] ON [dbo].[VentasDiarias]
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Productos] ADD  DEFAULT ((0)) FOR [Cantidad]
GO
ALTER TABLE [dbo].[CitasDeMascotas]  WITH CHECK ADD  CONSTRAINT [FK_CitasDeMascotas_PerfilesDeMascotas] FOREIGN KEY([IdPerfilMascota])
REFERENCES [dbo].[PetProfiles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CitasDeMascotas] CHECK CONSTRAINT [FK_CitasDeMascotas_PerfilesDeMascotas]
GO
ALTER TABLE [dbo].[InventarioPorMes]  WITH CHECK ADD  CONSTRAINT [FK_InventarioPorMes_Productos_IdProducto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InventarioPorMes] CHECK CONSTRAINT [FK_InventarioPorMes_Productos_IdProducto]
GO
ALTER TABLE [dbo].[PetObservations]  WITH CHECK ADD  CONSTRAINT [FK_PetObservations_PetProfiles] FOREIGN KEY([PetProfileId])
REFERENCES [dbo].[PetProfiles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PetObservations] CHECK CONSTRAINT [FK_PetObservations_PetProfiles]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Producto] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Productos] ([Id])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_Producto]
GO
ALTER TABLE [dbo].[VentasDiarias]  WITH CHECK ADD  CONSTRAINT [FK_VentasDiarias_Productos_IdProducto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VentasDiarias] CHECK CONSTRAINT [FK_VentasDiarias_Productos_IdProducto]
GO
ALTER TABLE [dbo].[PetProfiles]  WITH CHECK ADD CHECK  (([EdadDueno]>=(0) AND [EdadDueno]<=(100)))
GO
ALTER TABLE [dbo].[PetProfiles]  WITH CHECK ADD CHECK  (([EdadDueno]>=(0) AND [EdadDueno]<=(100)))
GO
ALTER TABLE [dbo].[PetProfiles]  WITH CHECK ADD CHECK  (([Edad]>=(0) AND [Edad]<=(50)))
GO
ALTER TABLE [dbo].[PetProfiles]  WITH CHECK ADD CHECK  (([Edad]>=(0) AND [Edad]<=(50)))
GO
ALTER TABLE [dbo].[PetProfiles]  WITH CHECK ADD CHECK  (([Peso]>=(0) AND [Peso]<=(100)))
GO
ALTER TABLE [dbo].[PetProfiles]  WITH CHECK ADD CHECK  (([Peso]>=(0) AND [Peso]<=(100)))
GO
USE [master]
GO
ALTER DATABASE [Inventario] SET  READ_WRITE 
GO
