using System.Collections.Generic;
using UnityEngine;

public class CoinsCreator : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform _pointsCreationCoins;

    [SerializeField] private int _amountCoinsOnMap;

    private List<Transform> _points;

    private void Awake()
    {
        CreateCoins();
    }

    private void CreateCoins()
    {
        _points = new List<Transform>();

        for (int i = 0; i < _pointsCreationCoins.childCount; i++)
        {
            _points.Add(_pointsCreationCoins.GetChild(i));
        }

        if (_amountCoinsOnMap > _points.Count)
        {
            _amountCoinsOnMap = _points.Count;
        }

        for (int j = 0; j < _amountCoinsOnMap; j++)
        {
            int currentPosition = Random.Range(0, _points.Count);

            Instantiate(_coinPrefab, new Vector3(_points[currentPosition].position.x,
                        _points[currentPosition].position.y, 0), Quaternion.identity);

            _points.Remove(_points[currentPosition]);
        }
    }
}
