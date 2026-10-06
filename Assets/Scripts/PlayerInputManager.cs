using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayersInputMng : MonoBehaviour
{
    private EventBus _inet;
    public void Init(EventBus totz)
    {
        _inet = totz;
    }

    public void OnMovePressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            EventBus.Trigger("Move", gameObject, context.ReadValue<Vector2>());
        }
        else
        {
            var zero = new Vector2(0, 0);
            EventBus.Trigger("Move", gameObject, zero);
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 lookinput = context.ReadValue<Vector2>();
        if (lookinput.sqrMagnitude >= 3)
        {   
            EventBus.Trigger("Look", gameObject, lookinput);
        }
        else
        {
            EventBus.Trigger("Look", gameObject, Vector2.zero);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
           
            EventBus.Trigger("Jump", gameObject);
        }
    }

    public void OnDance(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            EventBus.Trigger("Dance", game);
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
            EventBus.Trigger("Attack", gameObject, true);
        }
        if (context.canceled)
        {
            EventBus.Trigger("Attack", gameObject, false);
        }
    }
}