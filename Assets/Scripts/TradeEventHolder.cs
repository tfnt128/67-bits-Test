public static class TradeEventHolder
{
    private static TradeEvent _tradeEvent;
    private static PlayerStorage _playerStorage;
    private static TradePrices _tradePrices;

    public static void SetTradeEvent(TradeEvent tradeEvent)
    {
        _tradeEvent = tradeEvent;
    }

    public static TradeEvent GetTradeEvent()
    {
        return _tradeEvent;
    }

    public static void SetPlayerStorage(PlayerStorage playerStorage)
    {
        _playerStorage = playerStorage;
    }

    public static PlayerStorage GetPlayerStorage()
    {
        return _playerStorage;
    }

    public static void SetTradePrices(TradePrices tradePrices)
    {
        _tradePrices = tradePrices;
    }

    public static TradePrices GetTradePrices()
    {
        return _tradePrices;
    }
}