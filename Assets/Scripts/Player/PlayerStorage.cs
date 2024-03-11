using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStorage", menuName = "Player/PlayerStorage")]
public class PlayerStorage : ScriptableObject
{
    public int Money { get; private set; } = 0;
    
    public void AddMoney(int amount)
    {
        Money += amount;
        Debug.Log("Current money: : " + Money);
    }
    public void RemoveMoney(int amount)
    {
        Money -= amount;
        Debug.Log("Current money: : " + Money);
    }
    
    public void ResetStorage()
    {
        Money = 0;
        Debug.Log("Money Reset");
    }
}
