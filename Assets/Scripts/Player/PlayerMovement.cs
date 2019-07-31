using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _horizontalSpeed;

    [SerializeField]
    private float _jumpForce;

    [SerializeField]
    private GroundCheck _groundCheck;

    [SerializeField]
    private SideCheck _leftCheck;

    [SerializeField]
    private SideCheck _rightCheck;



    private Rigidbody2D _playerRigidbody;
    private int _movingDirection; //1 == right, -1 == left
    private bool _isJumping;
    private bool _isHoldingJumpButton;
    private float _standardHorizontalSpeed;

    private void Start()
    {
        _playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
        _movingDirection = 0;
        _standardHorizontalSpeed = _horizontalSpeed;
    }


    private void Update()
    {
        Debug.Log(_movingDirection);
        if (Input.GetKey(KeyCode.A))
            OnMovingLeft();
        if (Input.GetKey(KeyCode.D))
            OnMovingRight();
        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            OnReleaseMovement();
        if (Input.GetKeyDown(KeyCode.W))
            OnJumping();
        if (Input.GetKey(KeyCode.W))
        {
            OnHoldingJumpButton();
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            OnReleaseJumpButton();
        }
    }

    private void FixedUpdate()
    {
        _playerRigidbody.AddForce(Vector2.right * _movingDirection * _horizontalSpeed, ForceMode2D.Impulse);
        if (!_groundCheck.GetIsGrounded())
            return;
        
        if (_isJumping) //jumping
        {
            _horizontalSpeed /= 2;
            _playerRigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    public void OnJumping()
    {
        _isJumping |= _groundCheck.GetIsGrounded();
    }

    public void OnMovingLeft()
    {
        _movingDirection = -1;
        OnBreak();
    }

    public void OnMovingRight()
    {
        _movingDirection = 1;
        OnBreak();
    }

    public void OnReleaseMovement()
    {
        _movingDirection = 0;
        OnBreak();
    }

    public void OnBreak()
    {
        if (_movingDirection <= 0 && _playerRigidbody.velocity.x >= 0 && _groundCheck.GetIsGrounded())
        {
            _playerRigidbody.velocity = new Vector2(0, _playerRigidbody.velocity.y);
        }
        else if(_movingDirection >= 0 && _playerRigidbody.velocity.x <= 0 && _groundCheck.GetIsGrounded())
        {
            _playerRigidbody.velocity = new Vector2(0, _playerRigidbody.velocity.y);
        }
    }

    public void OnGrounded()
    {
        _isJumping = false;
        _horizontalSpeed = _standardHorizontalSpeed;
    }

    public void OnHoldingJumpButton()
    {
        _isHoldingJumpButton = true;
    }

    public void OnReleaseJumpButton()
    {
        _isHoldingJumpButton = false;
    }

    public bool IsHoldingJumpButton()
    {
        return _isHoldingJumpButton;
    }
}
