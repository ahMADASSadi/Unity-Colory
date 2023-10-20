
using UnityEngine;

public class PlayerControllerLevel1 : MonoBehaviour
{
    [SerializeField] private int maxJumpValue;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask ground;
    public bool isGrounded;
    public Rigidbody2D _rigidbody2D;
    int _maxJump;
    private int HighScore = 20;

    void Start()
    {
        _maxJump = maxJumpValue;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);

        if (Input.GetMouseButtonDown(0) && _maxJump > 0)
        {
            _maxJump--;
            Jump();
        }
        else if (Input.GetMouseButtonDown(0) && _maxJump == 0 && isGrounded)
        {
            Jump();
        }

        if (isGrounded)
        {
            _maxJump = maxJumpValue;
        }
    }

    void Jump()
    {
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.AddForce(new Vector2(x: 0, y: jumpSpeed));
    }
}