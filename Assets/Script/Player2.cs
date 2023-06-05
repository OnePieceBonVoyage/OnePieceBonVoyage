using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : MonoBehaviour
{
    public Animator animacao;
    public int maxHealth = 100;
    public static int currentHealth;
    public HealthBar healthBar;
    public AudioSource FightMusic;
    
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animacao.SetTrigger("Dano");
        
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        Debug.Log("Enemy died!");

        animacao.SetBool("Morreu", true);

        FightMusic.Stop();
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;

    }

}
