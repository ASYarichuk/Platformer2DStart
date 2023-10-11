using UnityEngine;

public class CoinRotator : MonoBehaviour
{
    private float _speedRotation = 200f;

    private void Update()
    {
        transform.Rotate(Vector3.up * _speedRotation * Time.deltaTime);
    }
}
