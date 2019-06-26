using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public AudioClip laserSound;
    public AudioClip reloadingSound;
    private AudioSource source;
    LineRenderer line;
    Light lux;
    public playerWeapon weapon;
    public int nbrMagazine = 0;


    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.GetComponentInParent<AudioSource>();
        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = false;
        lux = gameObject.GetComponent<Light>();
        lux.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && weapon.nbrAmnunition >= 1)
        {
            source.PlayOneShot(laserSound);
            StopCoroutine(FireLaser());
            StartCoroutine(FireLaser());
            StartCoroutine(laser());
            
        }
        if(weapon.nbrAmnunition <= 0 && nbrMagazine >= 0)
        {
            weapon.nbrAmnunition = weapon.nbrAmmunitionMagazine;
            source.PlayOneShot(reloadingSound);

            --nbrMagazine;
        }


    }

    IEnumerator FireLaser()
    {
        //line.enabled = true;
        lux.enabled = true;
         
        while(Input.GetButton("Fire1"))
        {
            //line.material.mainTextureOffset = new Vector2(0, Time.time);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            line.SetPosition(0, ray.origin);
            if(Physics.Raycast(ray, out hit, 100))
            {
                line.SetPosition(1, hit.point);
                if(hit.rigidbody)
                {

                }
            }
            else
            {
                line.SetPosition(1, ray.GetPoint(100));
            }
        

            yield return null;
        }
        //line.enabled = false;
        lux.enabled = false;
    }

    IEnumerator laser()
    {
        
        GameObject laserShoot = Instantiate(weapon.amnunitionGO, gameObject.transform.position, gameObject.transform.rotation);
        laserShoot.GetComponent<Rigidbody>().AddForce(transform.forward * weapon.bulletSpeed);
        weapon.nbrAmnunition -= 1;
        yield return null;

    }
}
