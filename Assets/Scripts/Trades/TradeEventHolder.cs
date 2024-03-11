public static class TradeEventHolder
{
    private static TradeEvent _tradeEvent;
    private static PlayerStorage _playerStorage;
    private static TradePrices _tradePrices;
    private static AllEventsData _allEventsData;

    public static void Initialize(TradeEvent tradeEvent, PlayerStorage playerStorage, TradePrices tradePrices, AllEventsData allEventsData)
    {
        _tradeEvent = tradeEvent;
        _playerStorage = playerStorage;
        _tradePrices = tradePrices;
        _allEventsData = allEventsData;
    }

    public static TradeEvent GetTradeEvent()
    {
        return _tradeEvent;
    }

    public static PlayerStorage GetPlayerStorage()
    {
        return _playerStorage;
    }

    public static TradePrices GetTradePrices()
    {
        return _tradePrices;
    }

    public static AllEventsData GetAllEventsSettings()
    {
        return _allEventsData;
    }
}