using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GameController: MonoBehaviour
{
    [SerializeField] private TMP_Text _Score;
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private float _lowestSpawnInterval;
    [SerializeField] private float _highestSpawnInterval;
    [SerializeField] private float _lowestGroupSpawnInterval;
    [SerializeField] private float _highestGroupSpawnInterval;
    [SerializeField] private int _lowestGroupSpawnCount;
    [SerializeField] private int _highestGroupSpawnCount;
    [SerializeField] private float _groupSpawnChance;
    private float _spawnColdown;
    private int _score;
    public void Score()
    {
        _score++;
        _Score.text = "Score : " + _score;
    }
    void Update()
    {
        _spawnColdown -= Time.deltaTime;
        if (_spawnColdown <= 0)
        {
            if (Random.Range(0f, 1f) < _groupSpawnChance)
            {
                int count = Random.Range(_lowestGroupSpawnCount, _highestGroupSpawnCount);
                float xPos = 0;
                for (int i = 0; i < count; i++)
                {
                    Instantiate(_coinPrefab, new Vector3(15 + xPos, 13, 0), Quaternion.identity);
                    xPos += Random.Range(_lowestGroupSpawnInterval, _highestGroupSpawnInterval) * 3;
                }
            } 
            else Instantiate(_coinPrefab, new Vector3(15, 13, 0), Quaternion.identity);
            _spawnColdown = Random.Range(_lowestSpawnInterval, _highestSpawnInterval);
        }
    }
}
