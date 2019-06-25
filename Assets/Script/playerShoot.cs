using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{
    public playerWeapon weapon;

    public ennemyAI ennemy;

    public GameObject Raycast;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;

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
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        
    }

    void Shoot()
    {
        //RaycastHit _hit;
        //if(Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapon.range, mask))
        //{

        //    Debug.Log("objet: " + _hit.collider.name);
        //}

        
    }
}
