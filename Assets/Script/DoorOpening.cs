using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private Animator anim;
    private float Distance;
    [SerializeField]
    private float distanceToOpen;
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioClip sound;
    private int nbr;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance(player.transform.position, gameObject.transform.position);

        if(Distance <= distanceToOpen)
        {
            switch(nbr)
            {
                case 0:
                    source.PlayOneShot(sound);
                    nbr++;
                    break;

            }
            
            anim.SetBool("Open", true);
        }
    }
}
