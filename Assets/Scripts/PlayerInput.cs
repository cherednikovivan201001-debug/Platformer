using UnityEngine;
using System;
using static UnityEngine.InputSystem.InputAction;   

public class PlayerInput : MonoBehaviour
{
    private EventBoost _eventBoost;

    public void Init(EventBoost eventBoost)
    {
        _eventBoost = eventBoost;
    }

    public void onMovePressed(CallbackContext context)
    {
        if (context.performed)
        {
            _eventBoost.TriggerMove(context.ReadValue<Vector2>());
        }
        else
        {
            var zero = new Vector2(0, 0);
            _eventBoost.TriggerMove(zero);
        }
    }

    public void OnLook(CallbackContext context)
    {
        Vector2 lookInput = context.ReadValue<Vector2>();
        
        if(lookInput.sqrMagnitude >= 3)
        {
            _eventBoost.TriggerLook(context.ReadValue<Vector2>());
        }
        else
        {
            Vector2 zero = new Vector2(0, 0);
            _eventBoost.TriggerLook(zero); 
        }

            //Debug.Log(context.ReadValue<Vector2>());
    }


    public void TriggerDance(CallbackContext ctx)
    {
        if (ctx.performed)
        {
            _eventBoost?.TriggerDance();
        }
    }

    public void TriggerShoot(CallbackContext ctx)
    {
        if (ctx.started)
        {
            _eventBoost?.TriggerShoot(true);
        }
        if (ctx.canceled)
        {
            _eventBoost?.TriggerShoot(false);
        }

    }
}
    