using System.Collections.Generic;
using UnityEngine;

public class AidKitCreator : MonoBehaviour
{
    [SerializeField] private AidKit _aidKitPrefab;
    [SerializeField] private Transform _pointsCreationAidKit;

    [SerializeField] private int _amountAidKitsOnMap;

    private List<Transform> _points;

    private void Awake()
    {
        CreateCoins();
    }

    private void CreateCoins()
    {
        _points = new List<Transform>();

        for (int i = 0; i < _pointsCreationAidKit.childCount; i++)
        {
            _points.Add(_pointsCreationAidKit.GetChild(i));
        }

        if (_amountAidKitsOnMap > _points.Count)
        {
            _amountAidKitsOnMap = _points.Count;
        }

        for (int j = 0; j < _amountAidKitsOnMap; j++)
        {
            int currentPosition = Random.Range(0, _points.Count);

            Instantiate(_aidKitPrefab, new Vector3(_points[currentPosition].position.x,
                        _points[currentPosition].position.y, 0), Quaternion.identity);

            _points.Remove(_points[currentPosition]);
        }
    }
}
