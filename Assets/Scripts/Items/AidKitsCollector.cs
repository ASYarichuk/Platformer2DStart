using UnityEngine;

public class AidKitCollector : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private int amountHealthInAidKit = 2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<AidKit>())
        {
            _player.TakeAidKit(amountHealthInAidKit);
            Destroy(other.gameObject);
        }
    }
}
