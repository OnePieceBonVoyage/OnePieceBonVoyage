using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float direction;
    public LayerMask enemyLayers;
    public PlayerController author;
    public Transform attackPoint;

    void Start()
    {
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(direction * 30, 0f), ForceMode2D.Force);
    }

    // Update is called once per frame
    void Update()
    {
        ApplyDamage();
    }

    void ApplyDamage()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, 0.5f, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            PlayerController enemyController = enemy.GetComponent<PlayerController>();

            if (enemyController.PlayerID != author.PlayerID)
            {
                int dano = (enemyController.GetComponent<Movimento>().isBlocking) ? 15 : 30;

                enemy.GetComponent<Player2>().TakeDamage(dano);
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}
