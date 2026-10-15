using System;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{ 
    private EventBoost _inet;

    [SerializeField] private Transform _legs;

    [SerializeField] private LayerMask _groundLayer;

    [SerializeField] private PlayerMoveController _playerMoveController;

    private float _timer = 0f;

    private float _checkDelay = 0.2f;

    private float _checkDistance = 0.2f;

    private bool _isGrounded = false;


    private void FixedUpdate()
    {
        _timer += Time.fixedDeltaTime;
        
        if(_timer >= _checkDelay)
        {
            CheckForGround();
            _timer = 0;
        }

        CheckForGround();
    }

    private void OnEnable()
    {
       _inet = GameManager.Instance.Inet;
       _inet._OnMoveCallBack += OnMovePressed;
       _inet._OnJump += OnJumpPressed;
    }

    private void OnDisable()
    {
        _inet._OnMoveCallBack -= OnMovePressed;
        _inet._OnJump -= OnJumpPressed;
    }

    private void OnMovePressed(Vector2 moveInput)
    {
        _playerMoveController.OnMovePressed(moveInput);
    }

    private void OnLookPressed(Vector2 look)
    {
        _playerMoveController.OnMovePressed(look);
    }

    public void OnJumpPressed()
    {
        _playerMoveController.OnJumpPressed();
    }

    private void CheckForGround()
    {
        bool Hit = Physics2D.Raycast(_legs.position, Vector2.down, _checkDistance, _groundLayer);

        if (Hit != _isGrounded)
        {
           _isGrounded = Hit;
        }
        else
        {
            if(_isGrounded)
            {
                _isGrounded = false;
            }
        }
    }

    private void NotifyGrounded()
    {
        _playerMoveController.SetGrounded(_isGrounded);
    }
}
