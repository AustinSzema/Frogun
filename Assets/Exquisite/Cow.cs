using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour, IDamageable
{
    [SerializeField] private float _healthPoints = 1f;

    [SerializeField] private ParticleSystem _explosionParticles;

    [SerializeField] private GameObject _cowVisual;


    public void takeDamage(float hitPoints)
    {
        _healthPoints -= hitPoints;
        if (_healthPoints <= 0f)
        {
            Explode();
        }
    }

    void Explode()
    {
        _explosionParticles.Play();
        _cowVisual.SetActive(false);
    }
}