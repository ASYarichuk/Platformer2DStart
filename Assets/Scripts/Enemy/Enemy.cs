using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 3;
    [SerializeField] private int _damage = 1;

    private Player _player;

    private void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.gameObject.GetComponent<Player>())
        {
            _player = enemy.gameObject.GetComponent<Player>();
            StartCoroutine(CauseDamage());
        }
    }

    private void OnCollisionExit2D(Collision2D enemy)
    {
        if (enemy.gameObject.GetComponent<Player>())
        {
            StopCoroutine(CauseDamage());
            _player = null;
        }
    }

    private IEnumerator CauseDamage()
    {
        while (_player != null)
        {
            _player.TakeDamage(_damage);
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
}
