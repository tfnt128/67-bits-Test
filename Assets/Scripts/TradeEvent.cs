using UnityEngine;

[CreateAssetMenu(fileName = "TradeEvent", menuName = "Events/TradeEvent")]
public class TradeEvent : ScriptableObject
{
    public enum TradeType { HumanToMoney, UpgradeMaxStackHeight }
    public delegate void TradeAction(TradeType tradeType);
    public event TradeAction OnTrade;

    public void NotifyTrade(TradeType tradeType)
    {
        OnTrade?.Invoke(tradeType);
    }
}