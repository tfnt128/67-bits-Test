using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class AllEventsData
{
    public PlayerStackable playerStackable;
    public PlayerColorSettings playerColor;
}
public class TradeManager : MonoBehaviour
{
    [SerializeField] private TradeEvent _tradeEvent;
    [SerializeField] private PlayerStorage _playerStorage;
    [SerializeField] private TradePrices _tradePrices;
    [FormerlySerializedAs("_allEventsSettings")] [SerializeField] private AllEventsData allEventsData;

    private void Awake()
    {
        TradeEventHolder.Initialize(_tradeEvent, _playerStorage, _tradePrices, allEventsData);
    }
}