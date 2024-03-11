using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilTrade : MonoBehaviour
{
    [SerializeField] private float _durationOffsetToTradeAgain;
    
    private TradeEvent _tradeEvent;
    private Collider _tradeArea;
    private ITraderAnimations _animations;
    private bool _isTrading = false;

    private void Start()
    {
        _tradeEvent = TradeEventHolder.GetTradeEvent();
        _tradeArea = GetComponent<Collider>();
        _animations = GetComponentInChildren<ITraderAnimations>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStackable player = other.GetComponent<PlayerStackable>();
            if (player != null && player.GetStackedObject().Count > 0 && !_isTrading)
            {
                _animations.TradeAnimation();
                ExecuteTrade(player.GetStackedObject());
            }
        }
    }

    private void ExecuteTrade(List<IStackable> stackedObjects)
    {
        _isTrading = true;

        List<GameObject> objectsToDestroy = new List<GameObject>();

        foreach (var obj in stackedObjects)
        {
            obj.RemoveStackedObject();
            obj.GetGameObject.transform.position = _tradeArea.transform.position;
            objectsToDestroy.Add(obj.GetGameObject);
            _tradeEvent.NotifyTrade(TradeEvent.TradeType.HumanToMoney);
        }

        stackedObjects.Clear();

        foreach (var obj in objectsToDestroy)
        {
            StartCoroutine(StartTrade(obj));
        }

        objectsToDestroy.Clear();
    }

    private IEnumerator StartTrade(GameObject obj)
    {
        yield return new WaitForSeconds(3f);
        Destroy(obj);

        yield return new WaitForSeconds(_animations.GetAnimationDuration() - _durationOffsetToTradeAgain);
        _isTrading = false;
    }
}