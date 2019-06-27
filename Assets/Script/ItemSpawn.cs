using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{

    [SerializeField]
    private GameObject[] Items;

    // Start is called before the first frame update
    void Start()
    {
        int randomObject = Random.Range(0, Items.Length);
        Instantiate(Items[randomObject], gameObject.transform.position, gameObject.transform.rotation);
    }

}
