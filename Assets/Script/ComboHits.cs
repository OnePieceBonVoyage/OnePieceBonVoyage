using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboHits : MonoBehaviour
{

    public Animator animacao;

    public Transform Attackpoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SocoFraco();
        }
    }

    void SocoFraco()
    {
        animacao.SetTrigger("SocoFraco");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(Attackpoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Player2>().TakeDamage(2);
        }
    }

    void OnDrawGizmos()
    {
        if (Attackpoint == null)
            return;

        Gizmos.DrawWireSphere(Attackpoint.position, attackRange);
    }

}
