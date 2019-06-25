using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;

    public int currentHealth;

    public void TakeDamage(int _amount)
    {
        currentHealth -= _amount;
        Debug.Log("you take: " + _amount);
    }
}
