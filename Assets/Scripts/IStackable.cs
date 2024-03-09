using UnityEngine;

public interface IStackable
{
    public bool CanStack { get; set; }
    public void UpdateObjectPosition(Transform followedCube, bool isFollowStart);
}