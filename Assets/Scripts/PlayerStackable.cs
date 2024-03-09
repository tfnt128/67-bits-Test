using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStackable : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Transform _startTransform;
    [SerializeField] private int _maxStackHeight = 3;
    [SerializeField] private float _stackOffset = 0.5f;
    [SerializeField] private float _timerBetweenPunchAndStack = 2f;

    private List<GameObject> _stackedObjects = new List<GameObject>();
    
    private Vector3 _currentObjectPos;

    private void OnTriggerEnter(Collider other)
    {
        IStackable stackable = other.GetComponent<IStackable>();

        if (stackable != null && !stackable.CanStack)
        {
            StartCoroutine(DelayCanStack(stackable));
            return;
        }

        if (_stackedObjects.Count >= _maxStackHeight)
            return;
        
        _playerController.PlayerAnimations.SetStacking(true);
        
        RagdollCharacter ragdollCharacter = other.gameObject.GetComponentInParent<RagdollCharacter>();
        if (ragdollCharacter != null)
        {
            ragdollCharacter.OnlyRagdollOff();
            _stackedObjects.Add(other.gameObject);

            Vector3 newPos = _startTransform.position + Vector3.up * _stackOffset * _stackedObjects.Count;
            other.gameObject.transform.position = newPos;
            other.gameObject.GetComponent<IStackable>().UpdateObjectPosition(_stackedObjects.Count == 1 ? transform : _stackedObjects[_stackedObjects.Count - 2].transform, true);
        }
    }
    

    private IEnumerator DelayCanStack(IStackable stackable)
    {
        yield return new WaitForSeconds(_timerBetweenPunchAndStack);
        stackable.CanStack = true;
    }
}
