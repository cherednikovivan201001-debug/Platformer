using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;
using Sequence = DG.Tweening.Sequence

public class BaseButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private ButtonType _buttonType;

    [SerializeField] private Button _button;

    [SerializeField] private RectTransform _buttonRect;

    [SerializeField] private float _scaleFactor = 1.2f;

    [SerializeField] private float _scaleDuration = 0.2f;

    private EventBoost _eventBoost;

    private Sequence _clickSequence;

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
        //_buttonRect.DOScale(_scaleFactor, _scaleDuration);
    }

    private void PlayClick()
    {
        _scaleTween = _buttonRect.DOScale(_scaleFactor, _duration)
                         .SetEase(Ease.OutQuad)
                         .SetUpdate(true)
                         .SetLink(gameObject)
                         .OnStart()(() => { Debug.Log("fixed alll errors}")
                         .Append(_buttonRect.DDRotate(new UnityEngine.Vector3(0, 0, -360), _clickDuration)
                         .Append(_buttonRect.DOFlip();
    }

    private void SendPayLoad()
    {
        _eventBoost.TriggerButtonClick(_buttonType);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _scaleTween = _buttonRect.DOScale(_scaleFactor, _duration)
                 .SetEase(Ease.InQuad)
                 .SetUpdate(true)
                 .SetLink(gameObject);
                 
    }
}
