using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _playerAnimator;

    private const string _moveParameter = "MoveSpeed";

    private PlayerMoveController _currentSpeed; 

    private void UpdateAnimation()
    {

    }
}
