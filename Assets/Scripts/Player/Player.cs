using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 10;
    [SerializeField] private int _damage = 2;

    private int _maxHealth = 10;

    private Enemy _enemy;

    private Animator _animator;

    private readonly string _nameAnimationAttack = "Attaking";

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.gameObject.GetComponent<Enemy>())
        {
            _enemy = enemy.gameObject.GetComponent<Enemy>();
            StartCoroutine(CauseDamage());
            _animator.SetBool(_nameAnimationAttack, true);
        }
    }

    private void OnCollisionExit2D(Collision2D enemy)
    {
        if (enemy.gameObject.GetComponent<Enemy>())
        {
            StopCoroutine(CauseDamage());
            _enemy = null;
            _animator.SetBool(_nameAnimationAttack, false);
        }
    }

    private IEnumerator CauseDamage()
    {
        while (_enemy != null)
        {
            _enemy.TakeDamage(_damage);
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeAidKit(int amountHealth)
    {
        if (_health + amountHealth >= _maxHealth)
        {
            _health = _maxHealth;
        }
        else
        {
            _health += amountHealth;
        }
    }
}
