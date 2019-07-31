using UnityEngine;

public class PlayerPhysicModifier : MonoBehaviour
{
    [SerializeField]
    private float _fallingGravityMultiplier;

    [SerializeField]
    private float _lowJumpGravityMultiplier;

    [SerializeField]
    private GroundCheck _groundCheck;



    private PlayerMovement _playerMovement;
    private Rigidbody2D _playerRigidbody;
    private float _currentGravityScale;

    private void Start()
    {
        _playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
        _playerMovement = gameObject.GetComponent<PlayerMovement>();
        _currentGravityScale = _playerRigidbody.gravityScale;
    }

    private void FixedUpdate()
    {
        if (_playerRigidbody.velocity.y < 0 && !_groundCheck.GetIsGrounded())
            _playerRigidbody.gravityScale = _fallingGravityMultiplier;

        else if(_playerRigidbody.velocity.y > 0 && !_playerMovement.IsHoldingJumpButton() && !_groundCheck.GetIsGrounded())
            _playerRigidbody.gravityScale = _lowJumpGravityMultiplier;

        else if(_groundCheck.GetIsGrounded())
            _playerRigidbody.gravityScale = _currentGravityScale;
    }

}
