using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100;
  
    public float currentHealth;
    public Vector3 originPos;

    public float GetHealthPercent()
    {
        return (float)currentHealth / maxHealth;
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
    void Start()
    {
        originPos = gameObject.transform.position;
        currentHealth = maxHealth;
    }
    void death()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    void Update()
    {
        if(currentHealth <= 0)
        {
            death();
        }
    }


}
