CREATE TABLE [dbo].[Currency] (
    [Id]                      INT          IDENTITY (1, 1) NOT NULL,
    [ProviderId]              INT          NOT NULL,
    [Name]                    VARCHAR (25) NOT NULL,
    [Symbol]                  VARCHAR (25)  NOT NULL,
    [RecordUpdatedDate]       DATETIME     NOT NULL,
    [ProviderLastUpdatedDate] DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

