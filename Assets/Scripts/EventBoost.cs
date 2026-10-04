using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class EventBoost : MonoBehaviour
{
    public  event Action<Vector2> _OnMoveCallBack;

    public  event Action<Vector2> _OnLookCallBack;

    public  event Action  _OnJump;

    public  event Action  _OnDance;

    public event Action<bool> _OnShoot;

    public event Action<bool> _OnSprint;

    public event Action<ButtonType> _OnButtonClick;

    public void TriggerButtonClick(ButtonType buttonType)
    {
        _OnButtonClick?.Invoke(buttonType);
    }

    public void TriggerMove(Vector2 Kostya)
    {
        _OnMoveCallBack?.Invoke(Kostya);
    }

    public void TriggerLook(Vector2 Lesha)
    {
        _OnLookCallBack?.Invoke(Lesha);
    }

    public void TriggerJump()
    {
        _OnJump?.Invoke();
    }

    public void TriggerDance()
    {
        _OnDance?.Invoke();
    }

    public void TriggerShoot(bool isshooting)
    {
        _OnShoot?.Invoke(isshooting);
    }

    public void TriggerSprint(bool isrunning)
    {
        _OnSprint?.Invoke(isrunning);
    }
}
