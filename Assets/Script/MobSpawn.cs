using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject Mob;

    private int min = 1;
    private int max = 1;
    private int randomNbr;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Mob, gameObject.transform.position, gameObject.transform.rotation);
    }
    
}
