using Unity.VisualScripting;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float _walkSpeed;

    [SerializeField] private Rigidbody _playerRB;

    [SerializeField] private AudioSource _playerFootsteps;

    [SerializeField] private PlayerMoveController _playerMoveController;

    [SerializeField] private float _jumpForce = 5f;

    [SerializeField] private Transform _legs;

    [SerializeField] private LayerMask _groundLayer;

    protected bool _isGrounded = false;

    private const string _groundTag = "Ground";

    private float _currentSpeed = 5f;

    private Vector3 _currentMoveVector;




    private void FixedUpdate()
    {
        Move();
    }



    private void Move()
    {
        if (_currentMoveVector.sqrMagnitude > 0.1f)
        {
           _currentSpeed = _walkSpeed;
            if (!_playerFootsteps.isPlaying)
            {
                _playerFootsteps.Play();
            }
        }
        else
        {
            _currentSpeed = 0;
            if (_playerFootsteps.isPlaying)
            {
                _playerFootsteps.Stop();
            }
        }

        Vector2 move = _currentMoveVector * _walkSpeed *    Time.fixedDeltaTime;



    }

    public void OnMovePressed(Vector2 moveInput)
    {
        float _moveX = moveInput.x;

        float _moveY = moveInput.y;

        _currentMoveVector = transform.right * _moveX + transform.up * _moveY;
    }

    public void OnJumpPressed()
    {
        Debug.Log("Jump Pressed");
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
