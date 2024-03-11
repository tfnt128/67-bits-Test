using UnityEngine;

[CreateAssetMenu(fileName = "TradeEvent", menuName = "Events/TradeEvent")]
public class TradeEvent : ScriptableObject
{
    public enum TradeType { HumanToMoney, UpgradeMaxStackHeight }
    public delegate void TradeAction(TradeType tradeType);
    
    public delegate void ColorAction(Color color);
    public event TradeAction OnTrade;
    public event ColorAction OnColor;

    public void NotifyTrade(TradeType tradeType)
    {
        OnTrade?.Invoke(tradeType);
    }
    public void NotifyColorChange(Color color)
    {
        OnColor?.Invoke(color);
    }
}