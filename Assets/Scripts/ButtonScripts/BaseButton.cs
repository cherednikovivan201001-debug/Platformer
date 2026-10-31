using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class BaseButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private ButtonType _buttonType;

    [SerializeField] private Button _button;

    [SerializeField] private RectTransform _buttonRect;

    [SerializeField] private float _scaleFactor = 1.2f;

    [SerializeField] private float _scaleDuration = 0.2f;

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

    public void OnPointerEnter(PointerEventData eventData)
    {
        _buttonRect.DOScale(_scaleFactor, _scaleDuration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _buttonRect.DOScale(1f, _scaleDuration);
    }
}
