using UnityEngine;

public interface IPunchable
{
    void OnPunched(Vector3 punchForce, PlayerPunch player);
}