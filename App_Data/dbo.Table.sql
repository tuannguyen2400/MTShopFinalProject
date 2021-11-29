CREATE TABLE [dbo].[Manufacturer]
(
	[ManufacturerCode] INT NOT NULL PRIMARY KEY IDENTITY, 
    [NameManfacturer] NVARCHAR(100) NULL, 
    [Information] NVARCHAR(255) NULL, 
    [Logo] NVARCHAR(MAX) NULL
)
