using UnityEngine;

public class TradeManager : MonoBehaviour
{
    [SerializeField] private TradeEvent _tradeEvent;
    [SerializeField] private PlayerStorage _playerStorage;
    [SerializeField] private TradePrices _tradePrices;

    private void Awake()
    {
        TradeEventHolder.SetTradeEvent(_tradeEvent);
        TradeEventHolder.SetPlayerStorage(_playerStorage);
        TradeEventHolder.SetTradePrices(_tradePrices);
    }
}