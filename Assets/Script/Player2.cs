using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public Animator animacao;
    public int maxHealth = 100;
    public static int currentHealth;  
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animacao.SetTrigger("Dano");

        if(currentHealth <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        Debug.Log("Enemy died!");

        animacao.SetBool("Morreu", true);

        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;

    }

}
