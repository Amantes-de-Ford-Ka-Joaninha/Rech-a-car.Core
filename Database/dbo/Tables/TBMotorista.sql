﻿CREATE TABLE [dbo].[TBMotorista] (
    [ID]         INT          IDENTITY (1, 1) NOT NULL,
    [NOME]       VARCHAR (50) NOT NULL,
    [TELEFONE]   VARCHAR (50) NOT NULL,
    [ENDERECO]   VARCHAR (50) NOT NULL,
    [DOCUMENTO]  VARCHAR (50) NOT NULL,
    [ID_CNH]     INT          NOT NULL,
    [ID_EMPRESA] INT          NOT NULL,
    CONSTRAINT [PK_TBMotorista] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_TBMotorista_TBClientePJ] FOREIGN KEY ([ID_EMPRESA]) REFERENCES [dbo].[TBClientePJ] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_TBMotorista_TBCnh] FOREIGN KEY ([ID_CNH]) REFERENCES [dbo].[TBCnh] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
);

