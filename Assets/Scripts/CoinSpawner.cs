using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefabCoin;
    private float _startPosX = 16f;
    private float _startPosY = 0.10f;
    private float _stepX = 30f;
    private float _currentPosX;
    private float _levelLength = 230f;

    private void Start() {
        _currentPosX = _startPosX;
        while (true) {
            if (_currentPosX >= _levelLength) {
                break;
            }
            Instantiate(_prefabCoin, new Vector3(_currentPosX, _startPosY, 0), Quaternion.identity);
            _currentPosX += _stepX;
        }
    }
}
