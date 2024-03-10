using System.Collections;
using UnityEngine;

public class StackableObject : MonoBehaviour, IStackable
{
    [SerializeField] private float followSpeed;
    
    private bool _canStack = false;
    public GameObject GetGameObject => gameObject;
    public bool CanStack { get => _canStack; set => _canStack = value; }

    public void UpdateObjectPosition(Transform followedObject, bool isFollowStart)
    {
        StartCoroutine( StartFollowingToLastObjectPosition(followedObject, isFollowStart));
    }

    public void RemoveStackedObject()
    {
        _canStack = false;
    }

    IEnumerator StartFollowingToLastObjectPosition(Transform followedObject, bool isFollowStart)
    {
        while (isFollowStart && _canStack)
        {
            yield return new WaitForEndOfFrame();
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, followedObject.position.x, followSpeed * Time.deltaTime),
                transform.position.y,
                Mathf.Lerp(transform.position.z, followedObject.position.z, followSpeed * Time.deltaTime));
        }
    }
}