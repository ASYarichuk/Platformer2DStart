using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2D;

    private bool _isGrounded;

    private readonly string _nameTagGround = "Ground";

    private readonly Vector3 _lookingToRight = new (1, 1, 1);
    private readonly Vector3 _lookingToLeft = new (-1, 1, 1);

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        HandleInput();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _nameTagGround)
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _nameTagGround)
        {
            _isGrounded = false;
        }
    }

    private void HandleInput()
    {
        float moveInput = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.D))
        {
            _rigidbody2D.velocity = new Vector2(moveInput * _speed, _rigidbody2D.velocity.y);
            transform.localScale = _lookingToRight;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody2D.velocity = new Vector2(moveInput * _speed, _rigidbody2D.velocity.y);
            transform.localScale = _lookingToLeft;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
        }
    }
}
