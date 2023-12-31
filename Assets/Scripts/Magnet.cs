using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Magnet : MonoBehaviour
{
    private List<Rigidbody> _magneticObjects = new List<Rigidbody>();


    [SerializeField] private Transform _footPosition;

    [SerializeField] private Transform _handPosition;

    [SerializeField] private Transform _explodePosition;

    
    [SerializeField]
    private GameObject _cubePrefab;



    [SerializeField] private GameObject _attractImage;
    [SerializeField] private GameObject _repelImage;
    [SerializeField] private GameObject _defaultImage;



    [SerializeField] private GameObject _attractParticlesRoot;
    [SerializeField] private GameObject _repelParticlesRoot;
    [SerializeField] private ParticleSystem _repelParticles;
    [SerializeField] private GameObject _gravityParticlesRoot;
    [SerializeField] private ParticleSystem _gravityParticles;
    private void Start()
    {
        /*for (int i = 0; i < 100; i++)
        {
            GameObject cube = Instantiate(_cubePrefab, transform.position + new Vector3(Random.Range(-100f, 100f), Random.Range(-100f, 100f), Random.Range(-100f, 100f)), Quaternion.identity);
            _magneticObjects.Add(cube.GetComponent<Rigidbody>());
            
        }*/
        
        Magnetic[] magneticObjects = GameObject.FindObjectsOfType<Magnetic>();

        // Do something with each object that has the Magnetic script
        foreach (Magnetic magneticObject in magneticObjects)
        {
            // Perform actions on each object, for example:
            _magneticObjects.Add(magneticObject.GetComponent<Rigidbody>());
        }
        

    }

    private bool _activateMagnet = false;
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position = _footPosition.position;
        }
        else
        {
            transform.position = _handPosition.position;
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            _activateMagnet = true;
            transform.position = _handPosition.position;
            _repelImage.SetActive(false);
            _attractImage.SetActive(true);
            _defaultImage.SetActive(false);
            _attractParticlesRoot.SetActive(true);
        }
        if(Input.GetMouseButtonUp(1))
        {
            _activateMagnet = false;
            /*foreach (Rigidbody rb in _magneticObjects)
            {
                transform.position = _explodePosition.position;
                rb.AddExplosionForce(20000f, transform.position, 100f, 0.0F);
            }*/
            _repelImage.SetActive(false);
            _attractImage.SetActive(false);
            _defaultImage.SetActive(true);
            _attractParticlesRoot.SetActive(false);

        }

        if (Input.GetMouseButton(1) && Input.GetMouseButtonDown(0))
        {
            foreach (Rigidbody rb in _magneticObjects)
            {
                _attractImage.SetActive(false);
                _repelImage.SetActive(true);
                _defaultImage.SetActive(false);
                _attractParticlesRoot.SetActive(false);
                _repelParticlesRoot.SetActive(true);
                _repelParticles.Clear();
                _repelParticles.Play();
                rb.AddForce(transform.forward * 5000f);
                _activateMagnet = false;
            }
        }
        
        
        if (Input.GetMouseButton(1) && Input.GetMouseButtonDown(2))
        {
            foreach (Rigidbody rb in _magneticObjects)
            {
                _attractImage.SetActive(false);
                _repelImage.SetActive(true);
                _defaultImage.SetActive(false);
                _attractParticlesRoot.SetActive(false);
                _gravityParticlesRoot.SetActive(true);
                _gravityParticles.Clear();
                _gravityParticles.Play();
                
                rb.AddForce(Vector3.down * 5000f);
                
                _activateMagnet = false;
            }
        }



        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_activateMagnet)
        {
            foreach (Rigidbody obj in _magneticObjects )
            {
                obj.velocity = Vector3.zero;
                obj.position = Vector3.MoveTowards(obj.transform.position, transform.position, Time.deltaTime * 50f);

                /*// Calculate the direction from the current position to the target position
                Vector3 direction = (transform.position - obj.position).normalized;

                // Set the velocity of the Rigidbody in the calculated direction
                obj.velocity = Time.fixedDeltaTime * 2000f * direction;*/
            }
            
        }
    }
}
