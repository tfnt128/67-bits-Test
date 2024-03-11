using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColorChange : MonoBehaviour
{
   [SerializeField] private PlayerColorSettings _playerColorSettings;
   
    private Color _newColor;

    private void OnEnable()
    {
        _playerColorSettings.playerMaterial.color = Color.white;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_playerColorSettings.isRandom)
                _newColor = new Color(Random.value, Random.value, Random.value);
            else
                _newColor = _playerColorSettings.color;

            TradeEvent tradeEvent = TradeEventHolder.GetTradeEvent();
            tradeEvent.NotifyColorChange(_newColor);
        }
    }
}