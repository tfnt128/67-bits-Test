using UnityEngine;

public interface IStackable
{
    public bool CanStack { get; set; }
    void OnStacked(Transform parent, float stackOffset, GameObject prefab);
}