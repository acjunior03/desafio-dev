CREATE DATABASE DesafioDev

SET QUOTED_IDENTIFIER OFF;
GO
USE [DesafioDev];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

CREATE TABLE [dbo].[Transaction] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Nature] nvarchar(max)  NOT NULL,
    [Signal] nvarchar(max)  NOT NULL,
    [Type] bigint  NOT NULL
);
GO

CREATE TABLE [dbo].[TransactionDescription] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [TransactionId] bigint  NOT NULL,
    [DateTime] datetime  NOT NULL,
    [Value] decimal(18,2)  NOT NULL,
    [CPF] nvarchar(11)  NOT NULL,
    [Card] nvarchar(max)  NOT NULL,
    [StoreOwner] nvarchar(max)  NOT NULL,
    [StoreName] nvarchar(max)  NOT NULL
);
GO

ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [PK_Transactions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

ALTER TABLE [dbo].[TransactionDescription]
ADD CONSTRAINT [PK_TransactionDescription]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

ALTER TABLE [dbo].[TransactionDescription]
ADD CONSTRAINT [FK_TransactionsTransactionDescription]
    FOREIGN KEY ([TransactionsId])
    REFERENCES [dbo].[Transactions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

CREATE INDEX [IX_FK_TransactionsTransactionDescription]
ON [dbo].[TransactionDescription]
    ([TransactionsId]);
GO

INSERT INTO [dbo].[Transaction]
           ([Description]
           ,[Nature]
           ,[Signal]
           ,[Type])
     VALUES
           ('Débito'
           ,'Entrada'
           ,'+'
           ,1)
GO

INSERT INTO [dbo].[Transaction]
           ([Description]
           ,[Nature]
           ,[Signal]
           ,[Type])
     VALUES
           ('Boleto'
           ,'Saída'
           ,'-'
           ,2)
GO
INSERT INTO [dbo].[Transaction]
           ([Description]
           ,[Nature]
           ,[Signal]
           ,[Type])
     VALUES
           ('Financiamento'
           ,'Saída'
           ,'-'
           ,3)
GO

INSERT INTO [dbo].[Transaction]
           ([Description]
           ,[Nature]
           ,[Signal]
           ,[Type])
     VALUES
           ('Crédito'
           ,'Entrada'
           ,'+'
           ,4)
GO

INSERT INTO [dbo].[Transaction]
           ([Description]
           ,[Nature]
           ,[Signal]
           ,[Type])
     VALUES
           ('Recebimento Empréstimo'
           ,'Entrada'
           ,'+'
           ,5)
GO

INSERT INTO [dbo].[Transaction]
           ([Description]
           ,[Nature]
           ,[Signal]
           ,[Type])
     VALUES
           ('Vendas'
           ,'Entrada'
           ,'+'
           ,6)
GO
INSERT INTO [dbo].[Transaction]
           ([Description]
           ,[Nature]
           ,[Signal]
           ,[Type])
     VALUES
           ('Recebimento TED'
           ,'Entrada'
           ,'+'
           ,7)
GO

INSERT INTO [dbo].[Transaction]
           ([Description]
           ,[Nature]
           ,[Signal]
           ,[Type])
     VALUES
           ('Recebimento DOC'
           ,'Entrada'
           ,'+'
           ,8)
GO

INSERT INTO [dbo].[Transaction]
           ([Description]
           ,[Nature]
           ,[Signal]
           ,[Type])
     VALUES
           ('Aluguel'
           ,'Saída'
           ,'+'
           ,9)
GO
