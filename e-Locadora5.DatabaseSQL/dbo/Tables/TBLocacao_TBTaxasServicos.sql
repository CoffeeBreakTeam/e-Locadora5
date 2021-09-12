CREATE TABLE [dbo].[TBLocacao_TBTaxasServicos] (
    [Id]              INT IDENTITY (1, 1) NOT NULL,
    [idLocacao]       INT NOT NULL,
    [idTaxasServicos] INT NOT NULL,
    CONSTRAINT [FK_TBLocacao_TBTaxasServicos_TBLocacao] FOREIGN KEY ([idLocacao]) REFERENCES [dbo].[TBLocacao] ([Id]),
    CONSTRAINT [FK_TBLocacao_TBTaxasServicos_TBTaxasServicos] FOREIGN KEY ([idTaxasServicos]) REFERENCES [dbo].[TBTaxasServicos] ([ID])
);

