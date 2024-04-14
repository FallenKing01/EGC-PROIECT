using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    private Animator anim;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();    
    }

    public void TakeDamage(float _damage) { 
    
        currentHealth = Mathf.Clamp(currentHealth-_damage,0,startingHealth);

        if (currentHealth > 0)
        {
            //hurt
            anim.SetTrigger("hurt");
        }
        else {
            //die
            anim.SetTrigger("die");
            GetComponent<MovementScript>().enabled = false;

        }
   
    }

    private void Update()
    {
       if(Input.GetKeyUp(KeyCode.E))
        {
            TakeDamage(1);
        }
        
    }
}
