using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStackable : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Transform _startTransform;
    [SerializeField] private int _maxStackHeight = 3;
    [SerializeField] private float _stackOffset = 0.75f;
    [SerializeField] private float _timerBetweenPunchAndStack = 1f;

    private List<IStackable> _stackedObjects = new List<IStackable>();

    public int MaxStackHeight { get => _maxStackHeight; set => _maxStackHeight = value; }

    private void Update()
    {
        _playerController.PlayerAnimations.SetStacking(_stackedObjects.Count > 0);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        IStackable stackable = other.GetComponent<IStackable>();
        
        if(stackable == null)
            return;
        
        if (!stackable.CanStack)
        { 
            StartCoroutine(DelayToStack(stackable)); 
            return;
        }

        if (_stackedObjects.Count >= MaxStackHeight) 
            return;

        RagdollCharacter ragdollCharacter = other.gameObject.GetComponentInParent<RagdollCharacter>();
        if (ragdollCharacter != null)
        {
            ragdollCharacter.OnlyRagdollOff();
            _stackedObjects.Add(stackable);

            Vector3 newPos = _startTransform.position + Vector3.up * _stackOffset * _stackedObjects.Count;
            other.gameObject.transform.position = newPos;
            other.gameObject.GetComponent<IStackable>().UpdateObjectPosition(_stackedObjects.Count == 1 ? transform : _stackedObjects[_stackedObjects.Count - 2].GetGameObject.transform, true);
        }
        
    }

    public List<IStackable> GetStackedObject()
    {
        return _stackedObjects;
    }
    
    private IEnumerator DelayToStack(IStackable stackable)
    {
        yield return new WaitForSeconds(_timerBetweenPunchAndStack);
        stackable.CanStack = true;
    }
}
