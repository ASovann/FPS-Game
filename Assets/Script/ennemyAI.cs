using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ennemyAI : MonoBehaviour
{

    //Distance entre le joueur et l'ennemi
    private float Distance;
    public playerWeapon weapon;
    public GameObject raycast;

    //Distance entre la position de base et l'ennemi
    private float DistanceBase;
    public float attackRange;
    private Vector3 basePosition;
    
    private int nbrAttack;

    //cible ennemy
    public Transform Target;

    // distance de poursuite
    public float chaseRange = 10;


    //cooldown attaque
    private float attackRepeatTime;
    public float attackTime;
    

    //dégats infligés
    public float TheDamage;

    //agent de navigation
    private UnityEngine.AI.NavMeshAgent agent;

    private AudioSource source;
    public AudioClip laserSound;

    //vie
    public float ennemyHealth;
    public bool isDead = false;
    



    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        attackRepeatTime = attackTime;
        basePosition = transform.position;
        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            //recherche du joueur

            if (Target != null)
            {
                //calcul de la distance joueur ennemi 
                Distance = Vector3.Distance(Target.position, transform.position);

                //calcul de la distance base ennemi 
                DistanceBase = Vector3.Distance(basePosition, transform.position);

                //ennemi éloigné
                if (Distance > chaseRange && DistanceBase <= 1)
                {
                    idle();

                }

                //ennemi proche mais pas a portée 
                if (Distance < chaseRange && Distance > attackRange)
                {
                    chase();

                }

                //ennemi proche a portée
                if (Distance < attackRange)
                {
                    attack();
                }

                //joueur échappé
                if (Distance > chaseRange && DistanceBase > 1)
                {
                    BackBase();
                }
            }
            if (ennemyHealth <= 0)
            {
                Dead();
            }
        }
        

    }

    //poursuite
    void chase()
    {
        //Anim.SetTrigger("Aiming");
        agent.destination = Target.position;
    }

    //attaque
    void attack()
    {
        //ne traverse pas le joueur
        agent.destination = transform.position;
        transform.LookAt(Target);
        switch (nbrAttack)
        {
            case 0:
                //Anim.SetTrigger("Attack");
                //Debug.Log("L'ennemi a envoyé " + TheDamage + " points de dégats");
                source.PlayOneShot(laserSound);
                StartCoroutine(AttackAnimation());
                nbrAttack++;
                break;
            default:
                attackRepeatTime -= Time.deltaTime;
                if (attackRepeatTime <= 0)
                {

                    //Anim.SetTrigger("Attack");
                    source.PlayOneShot(laserSound);
                    StartCoroutine(AttackAnimation());
                    //Debug.Log("L'ennemi a envoyé " + TheDamage + " points de dégats");
                    attackRepeatTime = attackTime;
                    nbrAttack++;
                }
                break;
        }
        
    }
    
    //idle
    void idle()
    {
        nbrAttack = 0;

    }

    //subit des dégats
    public void ApplyDamage(float TheDamage)
    {
        if (!isDead)
        {
            ennemyHealth -= TheDamage;

            print(gameObject.name + "à subit " + TheDamage + " points de dégats");

            
            
        }
    }
    public void BackBase()
    {
        
        nbrAttack = 0;
        agent.destination = basePosition;
    }
    public void Dead()
    {
        
        isDead = true;
        
        Destroy(gameObject);
        
    } 
  
    IEnumerator AttackAnimation()
    {
        GameObject laser = Instantiate(weapon.amnunitionGO, raycast.transform.position, raycast.transform.rotation);
        laser.GetComponent<Rigidbody>().AddForce(transform.forward * weapon.bulletSpeed);

        yield return null;
    }

}
