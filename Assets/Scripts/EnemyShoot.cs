using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Vector3Variable _playerPos;

    [SerializeField] private float _rotationSpeed = 10f;
    
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.position, _playerPos.Value,_rotationSpeed * Time.deltaTime, 0));
    }
}
