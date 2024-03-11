using UnityEngine;

[CreateAssetMenu(fileName = "TradePrices", menuName = "Trade/Trade Prices")]
public class TradePrices : ScriptableObject
{
    public int humanToMoneyPrice = 10;
    public int changeColorPrice = 10;
    public int upgradeMaxStackHeightPrice = 30;
}