using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _path;

    [SerializeField] private float _speed;
    [SerializeField] private float _seeDistance = 5f;
    [SerializeField] private float _attackDistance = 0.3f;

    private Player _target;

    private Transform[] _points;

    private int _currentPoint;

    private bool _harassment = false;

    private void Awake()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }

        _target = FindObjectOfType<Player>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Vector3.Distance(transform.position, _target.transform.position) < _seeDistance)
        {
            if (Vector3.Distance(transform.position, _target.transform.position) > _attackDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
            }
        }
        else
        {
            Transform target = _points[_currentPoint];

            if (_harassment == false)
            {
                if (transform.position == target.position)
                {
                    _currentPoint++;

                    if (_currentPoint >= _points.Length)
                    {
                        _currentPoint = 0;
                    }
                }
            }

            transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        }
    }
}
