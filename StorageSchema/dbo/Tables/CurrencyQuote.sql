CREATE TABLE [dbo].[CurrencyQuote] (
    [Id]                      INT             IDENTITY (1, 1) NOT NULL,
    [ProviderId]              INT             NOT NULL,
    [QuoteProviderId]         INT             NOT NULL,
    [Price]                   DECIMAL (19, 4) NOT NULL,
    [RecordUpdatedDate]       DATETIME        NOT NULL,
    [ProviderLastUpdatedDate] DATETIME        NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

