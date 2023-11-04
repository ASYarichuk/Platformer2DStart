using System.Collections;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private int _damage = 1;

    private Player _player;

    private void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.gameObject.TryGetComponent(out Player player))
        {
            _player = player;
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
        var waitForOneSecond = new WaitForSeconds(1.0f);

        while (_player != null)
        {
            _player.TakeDamage(_damage);
            yield return waitForOneSecond;
        }
    }
}
