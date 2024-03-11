using System;
using UnityEngine;

public class TradeEventListener : MonoBehaviour
{
    private AllEventsData _allEventsData;
    private TradeEvent _tradeEvent;
    private PlayerStorage _playerStorage;
    private TradePrices _tradePrices;
    
    private void Start()
    {
        _tradeEvent = TradeEventHolder.GetTradeEvent();
        _tradeEvent.OnTrade += OnTrade;
        _tradeEvent.OnColor += OnColor;
        
        _playerStorage = TradeEventHolder.GetPlayerStorage();
        _tradePrices = TradeEventHolder.GetTradePrices();
        _allEventsData = TradeEventHolder.GetAllEventsSettings();
        
        _playerStorage.ResetStorage();
    }

    private void OnDisable()
    {
        _tradeEvent.OnTrade -= OnTrade;
        _tradeEvent.OnColor -= OnColor;
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

    private void OnColor(Color color)
    {
        ChangeColorPlayer(_tradePrices.changeColorPrice, color);
    }
    private void UpgradeMaxStackHeight(int cost)
    {
        if (_playerStorage.Money >= cost)
        {
            
            _playerStorage.RemoveMoney(cost);
            _allEventsData.playerStackable.MaxStackHeight += 1;
            Debug.Log("Max stack height upgraded to: " + _allEventsData.playerStackable.MaxStackHeight);
            Debug.Log("Current Money: " + _playerStorage.Money);
        }
        else
        {
            Debug.Log("Not enough money to upgrade max stack height.");
            Debug.Log("Current Money: " + _playerStorage.Money);
        }
    }
    
    private void ChangeColorPlayer(int cost, Color color)
    {
        if (_playerStorage.Money >= cost)
        {
            _allEventsData.playerColor.playerMaterial.color = color;
            _playerStorage.RemoveMoney(cost);
            Debug.Log("Color Updated: " + _allEventsData.playerStackable.MaxStackHeight);
            Debug.Log("Current Money: " + _playerStorage.Money);
        }
        else
        {
            Debug.Log("Not enough money to change color.");
            Debug.Log("Current Money: " + _playerStorage.Money);
        }
    }
}