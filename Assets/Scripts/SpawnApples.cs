using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnApples : MonoBehaviour
{
    [SerializeField] private Transform _mainPoint;
    [SerializeField] private Apple _target;

    private Transform[] _spawnPoints;

    private void Awake()
    {
        _spawnPoints = new Transform[_mainPoint.childCount];

        for (int i = 0; i < _mainPoint.childCount; i++)
        {
            _spawnPoints[i] = _mainPoint.GetChild(i);
        }
    }

    private void Start()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Instantiate(_target, _spawnPoints[i]);
        }
    }
}
