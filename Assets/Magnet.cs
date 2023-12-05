using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Magnet : MonoBehaviour
{
    private List<Rigidbody> _magneticObjects = new List<Rigidbody>();


    [SerializeField]
    private GameObject _cubePrefab;
        
    private void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            GameObject cube = Instantiate(_cubePrefab, transform.position + new Vector3(Random.Range(-100f, 100f), Random.Range(-100f, 100f), Random.Range(-100f, 100f)), Quaternion.identity);
            _magneticObjects.Add(cube.GetComponent<Rigidbody>());
        }
    }

    private bool _activateMagnet = false;
    
    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            _activateMagnet = true;
        }
        else
        {
            _activateMagnet = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_activateMagnet)
        {
            foreach (Rigidbody obj in _magneticObjects )
            {
                obj.position = Vector3.MoveTowards(obj.transform.position, transform.position, Time.deltaTime * 50f);
            }
            
        }
    }
}
