using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private PlayerController _controller;
    
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool("IsMoving", _controller.IsMoving);
    }

    public void Punch()
    {
        _animator.SetTrigger("Punch");
    }

    public void SetStacking(bool value)
    {
        _animator.SetBool("IsStacking", value);
    }

}
