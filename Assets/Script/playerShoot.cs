using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{
    public playerWeapon weapon;


    [SerializeField]
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        if(cam == null)
        {
            Debug.LogError("Pas de camera renforcé");
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
