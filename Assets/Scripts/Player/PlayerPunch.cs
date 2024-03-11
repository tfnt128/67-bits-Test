using System;
using UnityEngine;

public class PlayerPunch : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private float _punchForceForward = 30f;
    [SerializeField] private float _punchForceUp = 20;

    private void OnCollisionEnter(Collision other)
    {
        IPunchable punchableObj = other.collider.GetComponent<IPunchable>();

        if (punchableObj != null)
        {
            _playerController.PlayerAnimations.Punch();
            punchableObj.OnPunched(transform.forward.normalized, _punchForceForward, _punchForceUp);
        }
    }
}

