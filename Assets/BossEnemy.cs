using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour, IDamageable
{
    public int healthPoints { get; set; }

    private void Start()
    {
        healthPoints = 100;
    }

    public void takeDamage(int hitPoints)
    {
        healthPoints -= hitPoints;
    }

    private void Update()
    {
        if (healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
