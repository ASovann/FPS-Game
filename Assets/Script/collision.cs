using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    public Transform sparks;
    public Transform impactBullet;
    private GameObject _player;
    private GameObject _enemy;
    private float damage;
    
    void OnCollisionEnter(Collision col)
    {
        ContactPoint contact = col.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        
        if (col.gameObject.tag == "Player")
        {
            
            Debug.Log("you take damage");
            
            damage = _enemy.GetComponent<ennemyAI>().weapon.damage;
           
            
            _player.GetComponent<player>().TakeDamage(damage);

            Destroy(gameObject);


        }
        if(col.gameObject.tag == "Enemy")
        {
            Instantiate(sparks, pos, rot);
            if(col.gameObject)
            {
                damage = _player.GetComponentInChildren<LaserScript>().weapon.damage;

                col.gameObject.GetComponent<ennemyAI>().ApplyDamage(damage);
            }

            Destroy(gameObject);

        }
        
        if(col.gameObject.tag != "Player" )
        {
            if (col.gameObject.tag != "Enemy")
            {
                Instantiate(sparks, pos, rot);
                Instantiate(impactBullet, pos, rot);
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
