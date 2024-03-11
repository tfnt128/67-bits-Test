using UnityEngine;

public class TraderAnimations : MonoBehaviour, ITraderAnimations
{ 
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void TradeAnimation()
    {
        _animator.SetTrigger("Trade");
    }

    public float GetAnimationDuration()
    {
        return _animator.GetCurrentAnimatorStateInfo(0).length;
    }
}
