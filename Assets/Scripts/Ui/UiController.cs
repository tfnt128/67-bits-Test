using TMPro;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentMoneyText;
    [SerializeField] private TextMeshProUGUI _stackHeightTexts;
    
    private AllEventsData _allEventsData;
    private PlayerStorage _playerStorage;
    
    void Start()
    {
        _allEventsData = TradeEventHolder.GetAllEventsSettings();
        _playerStorage = TradeEventHolder.GetPlayerStorage();
    }

    private void Update()
    {
        _stackHeightTexts.text =_allEventsData.playerStackable.GetStackedObject().Count + "/"
            + _allEventsData.playerStackable.MaxStackHeight;
        
        _currentMoneyText.text = _playerStorage.Money.ToString();
    }
}
