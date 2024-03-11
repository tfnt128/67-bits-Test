using UnityEngine;

public interface IPunchable
{
    void OnPunched(Vector3 punchDirection, float punchForceForward, float punchForceUp);
}