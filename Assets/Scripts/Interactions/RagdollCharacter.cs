using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RagdollCharacter : MonoBehaviour, IPunchable
{
    private CapsuleCollider _collider;
    private Animator _animator;
    private Collider[] _ragdollColliders;
    private Rigidbody[] _limbRigidbodyBodies;
    private void Start()
    {
        _collider = GetComponent<CapsuleCollider>();
        _animator = GetComponentInChildren<Animator>();
        
        GetRagdollColliders();
        RagdollOff();
    }

    public bool CanStack { get; set; }

    public void OnPunched(Vector3 punchDirection, float punchForceForward, float punchForceUp)
    {
        RagdollOn();
        Vector3 vforce = punchDirection * punchForceForward + (Vector3.up * punchForceUp);
        foreach (Rigidbody rb in _limbRigidbodyBodies)
            rb.AddForceAtPosition(vforce, transform.position, ForceMode.Impulse);
    }
    
    private void GetRagdollColliders()
    {
        _ragdollColliders = GetComponentsInChildren<Collider>();
        _limbRigidbodyBodies = GetComponentsInChildren<Rigidbody>();
    }
    
   private void RagdollOn()
    {
        SetRagdollEnabled(true);
        SetKinematic(false);
        SetAnimatorEnabled(false);
        SetMainColliderEnabled(false);
    }

    public void RagdollOff()
    {
        SetRagdollEnabled(false);
        SetKinematic(true);
        SetAnimatorEnabled(true);
        SetMainColliderEnabled(true);
    }
    
    public void OnlyRagdollOff()
    {
        SetRagdollEnabled(false);
        SetKinematic(true);
    }

    private void SetRagdollEnabled(bool enabled)
    {
        foreach (var col in _ragdollColliders)
            col.enabled = enabled;
    }

    private void SetKinematic(bool kinematic)
    {
        foreach (var rb in _limbRigidbodyBodies)
            rb.isKinematic = kinematic;
    }

    private void SetAnimatorEnabled(bool enabled)
    {
        _animator.enabled = enabled;
    }

    private void SetMainColliderEnabled(bool enabled)
    {
        _collider.enabled = enabled;
    }
}