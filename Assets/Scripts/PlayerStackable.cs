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
    [SerializeField] private GameObject _stackableCharacterPrefab;
    
    private List<GameObject> _stackedObjects = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        IStackable stackable = other.GetComponent<IStackable>();

        if (stackable != null && !stackable.CanStack)
        {
            StartCoroutine(DelayCanStack(stackable));
            return;
        }
        
        if (_stackedObjects.Count < _maxStackHeight)
        {
            stackable.OnStacked(_startTransform, _stackOffset, _stackableCharacterPrefab);
            _stackedObjects.Add(other.gameObject);
        }
        
        if (_stackedObjects.Count > 0)
            _playerController.PlayerAnimations.SetStacking(true);
    }

    private IEnumerator DelayCanStack(IStackable stackable)
    {
        yield return new WaitForSeconds(_timerBetweenPunchAndStack);
        stackable.CanStack = true;
    }
}
