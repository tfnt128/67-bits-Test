using UnityEngine;

public class StackableObject : MonoBehaviour, IStackable
{
    [SerializeField] private GameObject _firstParent;

    private bool _canStack = false;
    
    public bool CanStack { get => _canStack; set => _canStack = value; }

    public void OnStacked(Transform parent, float stackOffset, GameObject prefab)
    {
        if(!_canStack)
            return;
        
        GameObject prefabReference = Instantiate(prefab);
        Vector3 newPos = parent.position + Vector3.up * stackOffset * parent.childCount;
        prefabReference.transform.SetParent(parent);
        prefabReference.transform.position = newPos;
        Destroy(_firstParent);
    }
}
