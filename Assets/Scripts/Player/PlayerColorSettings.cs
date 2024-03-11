using UnityEngine;

[CreateAssetMenu(fileName = "PlayerColorSettings", menuName = "Events/PlayerColorSettings")]
public class PlayerColorSettings : ScriptableObject
{
    public Material playerMaterial;
    public Color color;
    public bool isRandom;
}