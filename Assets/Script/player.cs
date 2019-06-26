using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float maxHealth = 100;
    public float maxEnergy = 100;

    private float resetEnergyTime;
    public float EnergyTIme;

    public float currentEnergy;
    public float currentHealth;
    public Vector3 originPos;

    public float GetHealthPercent()
    {
        return (float)currentHealth / maxHealth;
    }
    public float GetEnergyPercent()
    {
        return (float)currentEnergy / maxEnergy;
    }
    public void TakeDamage(float _amount)
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
        else
        {
            currentHealth -= _amount;
        }
        Debug.Log("you take: " + _amount);
    }
    public void UseEnergy(float _amount)
    {
        currentEnergy -= _amount;
    }
    void Start()
    {
        originPos = gameObject.transform.position;
        currentHealth = maxHealth;
        currentEnergy = maxEnergy;
        resetEnergyTime = EnergyTIme;
    }
    void death()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    void Update()
    {
        resetEnergyTime -= Time.deltaTime;
        if(currentHealth <= 0)
        {
            death();
        }
        if(resetEnergyTime <= 0)
        {
            currentEnergy++;
            resetEnergyTime = EnergyTIme;
        }
        if(currentEnergy >= maxEnergy)
        {
            currentEnergy = maxEnergy;
        }
    }


}
