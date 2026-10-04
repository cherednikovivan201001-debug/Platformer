using UnityEngine;
using UnityEngine.UI;

public class BaseButton : MonoBehaviour
{
    [SerializeField] private ButtonType _buttonType;

    [SerializeField] private Button _button;

    private EventBoost _eventBoost;

    private void OnEnable()
    {
        _eventBoost = GameManager.Instance.Inet;
        
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        
    }

    private void OnClick()
    {
     _eventBoost.TriggerButtonClick(_buttonType);
    }
}
