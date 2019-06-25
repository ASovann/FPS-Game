using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    private GameObject _player;
    private GameObject _enemy;
    
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            
            Debug.Log("you take damage");
            
            float damage = _enemy.GetComponent<ennemyAI>().weapon.damage;
            _player.GetComponent<player>().TakeDamage(damage);

            Destroy(gameObject);


        }
        if(col.gameObject.tag == "Enemy")
        {
            float damage = _player.GetComponentInChildren<LaserScript>().weapon.damage;
            _enemy.GetComponent<ennemyAI>().ApplyDamage(damage);

            Destroy(gameObject);

        }
        
        if(col.gameObject.tag != "Player" )
        {
            if (col.gameObject.tag != "Enemy")
            {
                Destroy(gameObject);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _enemy = GameObject.FindGameObjectWithTag("Enemy");

        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
