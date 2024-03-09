using System;
using UnityEngine;

public class PlayerPunch : MonoBehaviour
{
    [SerializeField] private float _punchForceForward = 30f;
    [SerializeField] private float _punchForceUp = 20;
    [SerializeField] private PlayerController _playerController;
    
    private void OnCollisionEnter(Collision other)
    {
        IPunchable punchableObj = other.collider.GetComponent<IPunchable>();
        
        Vector3 punchDirection = transform.forward.normalized;
        Vector3 vforce = punchDirection * _punchForceForward + (Vector3.up * _punchForceUp);
        

        if (punchableObj != null)
        {
            _playerController.PlayerAnimations.Punch();
            punchableObj.OnPunched(vforce, this);
        }
    }
}

