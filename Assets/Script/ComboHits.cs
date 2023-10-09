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
    public bool atacando = false;
    public Transform Attackpoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public float attackRate = 2f;

    public Player2 playerStats;
    public Player2 enemyStats;

    float nextAttackTime = 0f;
    public PlayerController pc;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            GetComponent<Movimento>().enabled = true;
            if (Input.GetKeyDown(pc.ButtonLowAttack))
            {
                SocoFraco();
                nextAttackTime = Time.time + 1f / attackRate;
            }
            if (Input.GetKeyDown(pc.ButtonHighAttack))
            {
                SocoForte();
                nextAttackTime = Time.time + 1f /attackRate;
            }
        }
    }

    void SocoForte()
    {
        GetComponent<Movimento>().enabled = false;
        animacao.SetTrigger("SocoForte");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(Attackpoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            PlayerController enemyController = enemy.GetComponent<PlayerController>();

            if (enemyController.PlayerID != pc.PlayerID)
            {
                int dano = (enemyController.GetComponent<Movimento>().isBlocking) ? 15 : 30;

                pc.GetAudioByName("highPunch").Play();

                enemy.GetComponent<Player2>().TakeDamage(dano);
                var enemyRB = enemy.GetComponent<Rigidbody2D>();
                enemyRB.AddForce(new Vector2(10f * enemyController.ImpulseDirection, 7f), ForceMode2D.Impulse);

                var enemyAnimator = enemy.GetComponent<Animator>();
                enemyAnimator.SetTrigger("Cair");
            }
        }
    }

    void SocoFraco()
    {
        GetComponent<Movimento>().enabled = false;
        animacao.SetTrigger("SocoFraco");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(Attackpoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            PlayerController enemyController = enemy.GetComponent<PlayerController>();

            int dano = (enemyController.GetComponent<Movimento>().isBlocking) ? 5 : 10;

            if (enemyController.PlayerID != pc.PlayerID)
            {
                enemy.GetComponent<Player2>().TakeDamage(dano);
                pc.GetAudioByName("lowPunch").Play();
            }
        }
    }

    void OnDrawGizmos()
    {
        if (Attackpoint != null)
            Gizmos.DrawWireSphere(Attackpoint.position, attackRange);
    }
}
