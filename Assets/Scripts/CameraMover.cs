using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _camera;

    [SerializeField] private float _followingCameraToPlayer;

    private void Update()
    {
        _camera.position = new Vector3(transform.position.x, transform.position.y
            + _followingCameraToPlayer, _camera.position.z);
    }
}
