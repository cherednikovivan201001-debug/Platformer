using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _playerAnimator;

    [SerializeField] private Animator _animator;

    private const string _moveParameter = "MoveSpeed";

    private PlayerMoveController _currentSpeed;

    public void UpdateAnimation(float currentSpeed)
    {
        _animator.SetFloat("Speed", currentSpeed);
    }
    private void UpdateAnimation()
    {

    }
}
