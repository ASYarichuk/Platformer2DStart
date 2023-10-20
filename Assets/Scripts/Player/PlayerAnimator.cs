using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private readonly string _nameAnimationAttack = "Attaking";
    private readonly string _nameAnimationGrounded = "IsGrounded";
    private readonly string _nameAnimationWalking = "Walking";
    private readonly string _nameTagGround = "Ground";

    private bool _isGrounded;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (_isGrounded)
        {
            _animator.SetBool(_nameAnimationGrounded, true);
        }
        else
        {
            _animator.SetBool(_nameAnimationGrounded, false);
        }

        CheckInput();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            _animator.SetBool(_nameAnimationAttack, true);
        }

        if (collision.gameObject.tag == _nameTagGround)
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            _animator.SetBool(_nameAnimationAttack, false);
        }

        if (collision.gameObject.tag == _nameTagGround)
        {
            _isGrounded = false;
        }
    }

    private void CheckInput()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _animator.SetBool(_nameAnimationWalking, true);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            _animator.SetBool(_nameAnimationWalking, false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _animator.SetBool(_nameAnimationWalking, true);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            _animator.SetBool(_nameAnimationWalking, false);
        }
    }
}
