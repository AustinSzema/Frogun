using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomainExpansion : MonoBehaviour
{
    [SerializeField] private float _expansionSpeed = 2f;

    private bool _expandDomain = false;

    [SerializeField] private float _domainSizeValue = 200f;
    private Vector3 _domainSize = Vector3.one;

    private Vector3 _originalSize = Vector3.one;

    [SerializeField] private MeshRenderer _meshRenderer;

    [SerializeField] private ParticleSystem _domainParticles;
    
    private void Start()
    {
        _domainSize = new Vector3(_domainSizeValue, _domainSizeValue, _domainSizeValue);
        _originalSize = transform.localScale;
        _meshRenderer.enabled = false;
        _domainParticles.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && _expandDomain == false)
        {
            _meshRenderer.enabled = true;
            transform.localScale = _originalSize;
            _expandDomain = true;
            
            _domainParticles.Play();
            
        }

        if (_expandDomain)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, _domainSize, Time.deltaTime * _expansionSpeed);
        }

        if (Vector3.Distance(transform.localScale, _domainSize) <= 10f)
        {
            StartCoroutine(ShrinkDomain(0.01f));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.GetComponent<IDamageable>() != null && other.gameObject.GetComponent<PlayerController>() == null)
        {
            other.gameObject.GetComponent<IDamageable>().takeDamage(1);
        }
    }

    /*private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.GetComponent<IDamageable>() != null && other.gameObject.GetComponent<PlayerController>() == null)
        {
            other.gameObject.GetComponent<IDamageable>().takeDamage(1);
        }
    }*/

    private IEnumerator ShrinkDomain(float waitTime)
    {
        transform.localScale = _originalSize;
        _expandDomain = false;
        _meshRenderer.enabled = false;
        _domainParticles.Stop();
        yield return new WaitForSeconds(waitTime);
    }
    
}