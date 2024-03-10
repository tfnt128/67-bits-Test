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
    
    private Vector3 _currentObjectPos;

    public List<IStackable> stackedObjects = new List<IStackable>();

    public int MaxStackHeight {get => _maxStackHeight; set => _maxStackHeight = value; }


    private void Update()
    {
        if(stackedObjects.Count > 0)
            _playerController.PlayerAnimations.SetStacking(true);
        else
            _playerController.PlayerAnimations.SetStacking(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        IStackable stackable = other.GetComponent<IStackable>();

        if (stackable != null)
        {
            if (!stackable.CanStack)
            {
                StartCoroutine(DelayToStack(stackable));
                return;
            }

            if (stackedObjects.Count >= MaxStackHeight)
                return;

            RagdollCharacter ragdollCharacter = other.gameObject.GetComponentInParent<RagdollCharacter>();
            if (ragdollCharacter != null)
            {
                ragdollCharacter.OnlyRagdollOff();
                stackedObjects.Add(stackable);

                Vector3 newPos = _startTransform.position + Vector3.up * _stackOffset * stackedObjects.Count;
                other.gameObject.transform.position = newPos;
                other.gameObject.GetComponent<IStackable>().UpdateObjectPosition(stackedObjects.Count == 1 ? transform : stackedObjects[stackedObjects.Count - 2].GetGameObject.transform, true);
            }
        }
    }
    
    private IEnumerator DelayToStack(IStackable stackable)
    {
        yield return new WaitForSeconds(_timerBetweenPunchAndStack);
        stackable.CanStack = true;
    }
}
