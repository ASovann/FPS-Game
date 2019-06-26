using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abilities : MonoBehaviour
{
    [SerializeField]
    private GameObject ShieldGO;

    private player player;

    private GameObject ability;
    private AudioSource source;
    [SerializeField]
    private AudioClip shieldSound;
    public float shieldTime;
    private float memoryHealth;
    public float EnergyConsume = 50;



    // Start is called before the first frame update
    void Start()
    {
        source = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        player = gameObject.GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {

        
        if (Input.GetButtonDown("Fire2") && !ability)
        {
            if (player.currentEnergy >= EnergyConsume)
            {
                
                source.PlayOneShot(shieldSound);
                ability = Instantiate(ShieldGO, gameObject.transform);
                memoryHealth = player.currentHealth;
                player.UseEnergy(EnergyConsume);
            }
        }
        if(ability)
        {
            player.currentHealth = memoryHealth;
            ability.transform.position = gameObject.transform.position;
            Destroy(ability, shieldTime);
        }

    }
}
