using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Magnetic : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _hitClip;
    [SerializeField] private ParticleSystem _dustParticles;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<IDamageable>() != null && other.gameObject.GetComponent<PlayerController>() == null)
        {
            Debug.Log(other.gameObject.name);
            other.gameObject.GetComponent<IDamageable>().takeDamage(1);
            _audioSource.pitch = Random.Range(0.5f, 1.5f);
            _audioSource.PlayOneShot(_hitClip);
            //_dustParticles.transform.position = other.contacts[0].point;
            //_dustParticles.Play();
        }
    }


    private void Update()
    {
        if (transform.position.y < 0f)
        {
            transform.position = new Vector3(transform.position.x, 30f, transform.position.z);
        }
    }
    
    
}


