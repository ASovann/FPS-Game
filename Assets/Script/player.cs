using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100;

    public float currentHealth;

    public void TakeDamage(float _amount)
    {
        currentHealth -= _amount;
        Debug.Log("you take: " + _amount);
    }
}
