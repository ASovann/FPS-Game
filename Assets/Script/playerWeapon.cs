using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class playerWeapon 
{
    public string gunName = "Laser Gun";
    public float damage = 10f;
    public float range = 100f;
    public GameObject amnunitionGO;
    public float bulletSpeed;
    public int nbrAmnunition = 30;
    public int nbrAmmunitionMagazine = 30;

}
