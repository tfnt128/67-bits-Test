using UnityEngine;

public interface IStackable
{
    public GameObject GetGameObject { get; }
    public bool CanStack { get; set; }
    public void UpdateObjectPosition(Transform followedCube, bool isFollowStart);
    public void RemoveStackedObject();
}