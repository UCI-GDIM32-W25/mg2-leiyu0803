using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private float _speed;
    void Update()
    {
        _transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }
}
