using UnityEngine;

public class CoinsCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<CoinRotator>())
        {
            Destroy(other.gameObject);
        }
    }
}
