using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private RectTransform HealthBarFill;

    private LaserScript weapon;

    [SerializeField]
    private Text nbrAmmunition;

    [SerializeField]
    private Text nbrMagazine;

    private player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
        weapon = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<LaserScript>();
    }

    // Update is called once per frame
    void Update()
    {
        setHealthAmount(player.GetHealthPercent());
        setAmmoAmount(weapon.weapon.nbrAmnunition);
        setMagazineAmount(weapon.nbrMagazine);
    }
    
    

    public void setHealthAmount(float _amount)
    {
        HealthBarFill.localScale = new Vector3(1f, _amount, 1f);
    }
    
    public void setAmmoAmount(int _amount)
    {
        nbrAmmunition.text = _amount.ToString();
    }

    public void setMagazineAmount(int _amount)
    {
        nbrMagazine.text = _amount.ToString();
    }
}
