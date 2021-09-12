CREATE TABLE [dbo].[Categorias] (
    [Id]                      INT           IDENTITY (1, 1) NOT NULL,
    [ValorDiario]             NUMERIC (18)  NOT NULL,
    [ValorDiarioKm]           NUMERIC (18)  NOT NULL,
    [ValorControladoDiario]   NUMERIC (18)  NOT NULL,
    [ValorControladoDiarioKm] NUMERIC (18)  NOT NULL,
    [ValorControladoQtdKm]    NUMERIC (18)  NOT NULL,
    [ValorLivre]              NUMERIC (18)  NOT NULL,
    [Categoria]               VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED ([Id] ASC)
);

