using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : MonoBehaviour
{
    public Animator animacao;
    public int maxHealth = 100;
    public int currentHealth;
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
    }

    public void Winner()
    {
        animacao.SetTrigger("Ganhou");
    }

    public void Die()
    {
        animacao.SetTrigger("Morreu");
    }
}
