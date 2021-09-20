CREATE TABLE [dbo].[TBCondutor] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [Nome]        VARCHAR (50) NOT NULL,
    [Endereco]    VARCHAR (80) NOT NULL,
    [Telefone]    VARCHAR (20) NOT NULL,
    [Rg]          VARCHAR (15) NOT NULL,
    [Cpf]         VARCHAR (20) NOT NULL,
    [Cnh]         VARCHAR (30) NOT NULL,
    [ValidadeCnh] DATE         NOT NULL,
    [Id_Cliente]  INT          NOT NULL,
    CONSTRAINT [PK_TBCondutor] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBCondutor_TBClientes] FOREIGN KEY ([Id_Cliente]) REFERENCES [dbo].[TBClientes] ([Id])
);



