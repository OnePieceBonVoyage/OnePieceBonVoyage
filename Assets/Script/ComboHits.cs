using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class ComboHits : MonoBehaviour
{

    public Animator animacao;
    public static bool atacando = false;
    public Transform Attackpoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public float attackRate = 2f;
    float nextAttackTime = 0f;
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            GetComponent<Movimento>().enabled= true;
            if (Input.GetKeyDown(KeyCode.T))
            {
                SocoFraco();
                nextAttackTime = Time.time + 1f / attackRate;
            }
            
        }

        if (Player2.currentHealth <= 0 )
        {
            Winner();
        }

        
    }

    void SocoFraco()
    {
        GetComponent<Movimento>().enabled = false;
        animacao.SetTrigger("SocoFraco");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(Attackpoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Player2>().TakeDamage(10);
        }

        
    }

    void OnDrawGizmos()
    {
        if (Attackpoint == null)
            return;

        Gizmos.DrawWireSphere(Attackpoint.position, attackRange);
    }

    void Winner()
    {
        animacao.SetTrigger("Ganhou");
        Destroy(GetComponent<Movimento>());
        Destroy(GetComponent<Jump>());
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

    }
}
