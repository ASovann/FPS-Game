using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPack : MonoBehaviour
{
    [SerializeField]
    private float AmountEnergyRestored = 10;
    private AudioSource source;
    public AudioClip sound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, 2, 0);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (col.gameObject.GetComponent<player>().currentEnergy <= col.gameObject.GetComponent<player>().maxEnergy - 1)
            {
                source = col.gameObject.GetComponent<AudioSource>();
                source.PlayOneShot(sound);
                col.gameObject.GetComponent<player>().currentEnergy += AmountEnergyRestored;
                Destroy(gameObject);
            }
        }
    }
}
