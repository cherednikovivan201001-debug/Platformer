using System;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float _walkSpeed;

    [SerializeField] private Rigidbody _playerRB;

    [SerializeField] private Animator _playerAnimator;

    [SerializeField] private Transform _legs;

    [SerializeField] private CheckDistance _checkDistance;

    [SerializeField] private LayerMask _groundLayer;

    [SerializeField] private PlayerMoveController _playerMoveController;

    [SerializeField] private AudioSource _playerFootsteps;

    [SerializeField] private float _jumpForce = 5f;

    private float _currentSpeed = 0;

    private Vector3 startPosition;

    private float _targetLookY;

    private bool _isGrounded = true;

    private float _moveX = 0;

    private float _moveZ = 0;

    private float _timer;

    private void OnEnable()
    {
        PlayerInput._onMoveCallback += OnMovePressed;

        PlayerInput._onLookCallback += OnLookPressed;

        PlayerInput._OnShoot += OnAttack;

        startPosition = transform.position;

        PlayerInput._OnJump += OnJumpPressed;
    }

    private void OnDisable()
    {
        PlayerInput._onLookCallback -= (OnLookPressed);

        PlayerInput._onMoveCallback -= (OnMovePressed);

        PlayerInput._OnShoot -= OnAttack;

        PlayerInput._OnJump -= (OnJumpPressed);
    }

    private void OnAttack(bool t)
    {
        Debug.Log($"Attack: {t}");
        _atckController.OnShootPerformed(t);
    }

    private void OnMovePressed(Vector2 moveInput)
    {
        Debug.Log(moveInput);

        _moveX = moveInput.x;

        _moveZ = moveInput.y;
    }

    private void OnLookPressed(Vector2 look)
    {
        _targetLookY = look.x;
    }


    private void FixedUpdate()
    {
        _timer += Time.fixedDeltaTime;

        if (_timer >= _checkDelay)
        {
            CheckForGround();

            _timer = 0;
        }

        
    }
    public void OnMovePressed()
    {

    }

    public void OnJumpPressed()
    {
       _playerMoveController.OnJumpPressed();
    }

    private void CheckForGround()
    {
        if (Physics2D.Raycast(_legs.position, Vector2.down, _checkDistance, _groundLayer))
        {
            if (!_isGrounded)
            {
               _isGrounded = true;
            }
        }
        else
        {
            if( _isGrounded )
            {
                _isGrounded = false;
            }
        }
    }

    private void NotifyGrounded()
    {
        _playerMoveController;
    }
}
