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

    public void TakeDamage(float _amount)
    {
        currentHealth -= _amount;
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
