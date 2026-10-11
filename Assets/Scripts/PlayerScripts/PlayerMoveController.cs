using Unity.VisualScripting;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float _walkSpeed;

    [SerializeField] private Rigidbody _playerRB;

    [SerializeField] private AudioSource _playerFootsteps;

    [SerializeField] private PlayerAnimationController _playerAnimationController;

    [SerializeField] private float _jumpForce = 5f;

    [SerializeField] private Transform _legs;

    [SerializeField] private LayerMask _groundLayer;

    private bool _isGrounded = false;

    private float currentSpeed;

    private Vector3 _currentMoveVector;




    private void FixedUpdate()
    {
        Move();
    }



    private void Move()
    {
        if (_currentMoveVector.sqrMagnitude > 0.1f)
        {
           currentSpeed = _walkSpeed;
            if (!_playerFootsteps.isPlaying)
            {
                _playerFootsteps.Play();
            }
        }
        else
        {
            currentSpeed = 0;
            if (_playerFootsteps.isPlaying)
            {
                _playerFootsteps.Stop();
            }
        }

        Vector2 move = _currentMoveVector * _walkSpeed *    Time.fixedDeltaTime;

        _playerAnimationController.UpdateAnimation(currentSpeed);
        _playerRB.MovePosition(_playerRB.position + move);
    }

    public void OnMovePressed(Vector2 moveInput)
    {
        float _moveX = moveInput.x;

        _currentMoveVector = transform.right * _moveX;
    }

    public void OnJumpPressed()
    {
        
        if ( _isGrounded )
        {
            return;
        }

        //_playerRB.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

        _playerRB.linearVelocity = new Vector2(_playerRB.linearVelocity.x, _jumpForce);
    }


    public void SetGrounded(bool grounded)
    {
        _isGrounded = grounded;
        Debug.Log("Is Grounded: " + _isGrounded);
    }
}
