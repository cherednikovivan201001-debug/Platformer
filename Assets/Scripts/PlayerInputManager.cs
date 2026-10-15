using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayersInputMng : MonoBehaviour
{


    private EventBoost _inet;
    public void Init(EventBoost totz)
    {
        _inet = totz;
    }

    public void OnMovePressed(InputAction.CallbackContext context)
    {
        _inet.TriggerMove(context.ReadValue<Vector2>());
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _inet.TriggerLook(context.ReadValue<Vector2>());
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _inet.TriggerJump();
        }
    }

    public void OnDance(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _inet.TriggerDance();
        }
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _inet.TriggerSprint(true);
        }
        if (context.canceled)
        {
            _inet.TriggerSprint(false);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _inet.TriggerAttack(true);
        }
        if (context.canceled)
        {
            _inet.TriggerAttack(false);
        }
    }



}