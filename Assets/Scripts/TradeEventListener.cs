using System;
using UnityEngine;

[Serializable]
public class UpgradeSettings
{
    public PlayerStackable playerStackable;
}
public class TradeEventListener : MonoBehaviour
{
    [SerializeField] private UpgradeSettings _upgradeSettings;
    
    private TradeEvent _tradeEvent;
    private PlayerStorage _playerStorage;
    private TradePrices _tradePrices;
    
    private void Start()
    {
        _playerStorage = TradeEventHolder.GetPlayerStorage();
        _tradePrices = TradeEventHolder.GetTradePrices();
        
        _playerStorage.ResetStorage();
    }

    private void OnEnable()
    {
        _tradeEvent = TradeEventHolder.GetTradeEvent();
        _tradeEvent.OnTrade += OnTrade;
    }

    private void OnDisable()
    {
        _tradeEvent.OnTrade -= OnTrade;
    }

    private void OnTrade(TradeEvent.TradeType tradeType)
    {
        if (tradeType == TradeEvent.TradeType.UpgradeMaxStackHeight)
        {
            UpgradeMaxStackHeight(_tradePrices.upgradeMaxStackHeightPrice);
        }
        else if (tradeType == TradeEvent.TradeType.HumanToMoney)
        {
            _playerStorage.AddMoney(_tradePrices.humanToMoneyPrice);
        }
    }

    private void UpgradeMaxStackHeight(int cost)
    {
        if (_playerStorage.Money >= cost)
        {
            _playerStorage.RemoveMoney(cost);
            _upgradeSettings.playerStackable.MaxStackHeight += 1;
            Debug.Log("Max stack height upgraded to: " + _upgradeSettings.playerStackable.MaxStackHeight);
            Debug.Log("Current Money: " + _playerStorage.Money);
        }
        else
        {
            Debug.Log("Not enough money to upgrade max stack height.");
            Debug.Log("Current Money: " + _playerStorage.Money);
        }
    }
}