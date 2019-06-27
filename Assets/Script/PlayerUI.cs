using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private RectTransform HealthBarFill;
    [SerializeField]
    private RectTransform EnergyBarFill;
    [SerializeField]
    private Text textTime;
    [SerializeField]
    private InputField cheatcode;
    [SerializeField]
    private GameObject cheat;
    [SerializeField]
    private Text textCheatCode;

    private LaserScript weapon;
    private abilities ability;

    [SerializeField]
    private Text nbrAmmunition;

    [SerializeField]
    private Text nbrMagazine;

    private player player;

    private bool isCheating = false;

    private string codeEntered;
    private bool codeExec = false;



    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
        weapon = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<LaserScript>();
    }

    // Update is called once per frame
    void Update()
    {
        textTime.text = Time.time.ToString();
        setHealthAmount(player.GetHealthPercent());
        setEnergyAmount(player.GetEnergyPercent());
        setAmmoAmount(weapon.weapon.nbrAmnunition);
        setMagazineAmount(weapon.nbrMagazine);
        
        
        switch(isCheating)
        {
            case false:
                if (Input.GetButtonDown("Submit"))
                {
                    Time.timeScale = 0f;
                    isCheating = true;
                    cheat.SetActive(true);
                    cheatcode.ActivateInputField();

                }
                break;
            case true:
                if (Input.GetButtonDown("Submit"))
                {
                    codeEntered = cheatcode.text;
                    Time.timeScale = 1f;
                    isCheating = false;
                    cheat.SetActive(false);
                }
                break;
        }

        if(codeEntered == "iamanoob")
        {
            textCheatCode.text = "Cheat Code Activated";
            Destroy(textCheatCode, 1);
            codeExec = true;
        }
        if(codeExec)
        {
            player.currentHealth = 100;
        }
    }
    
    

    public void setHealthAmount(float _amount)
    {
        HealthBarFill.localScale = new Vector3(1f, _amount, 1f);
    }
    public void setEnergyAmount(float _amount)
    {
        EnergyBarFill.localScale = new Vector3(1f, _amount, 1f);
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
