using System;
using UnityEngine;

public class StackUpgrade : MonoBehaviour
{
    private static TradeEvent _tradeEvent;

    private void Start()
    {
        _tradeEvent = TradeEventHolder.GetTradeEvent();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _tradeEvent.NotifyTrade(TradeEvent.TradeType.UpgradeMaxStackHeight);
        }
    }
}
