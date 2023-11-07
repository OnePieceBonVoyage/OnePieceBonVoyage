using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElephantGun : MonoBehaviour
{
    public PlayerController pc;
    public ComboHits ch;
    
    private Animator animacao;

    // Start is called before the first frame update
    void Start()
    {
        animacao = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pc.ButtonSpecialAttack) && ch.canMakeSpecial)
        {
            StartCoroutine(SocoEspecial());
            ch.nextAttackTime = Time.time + 3f / 1f;
            ch.specialCooldown = 10f;
        }
    }

    public IEnumerator SocoEspecial()
    {
        animacao.SetTrigger("SocoEspecial");

        GetComponent<Movimento>().enabled = false;

        yield return new WaitForSeconds(.5f);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(ch.Attackpoint.position, ch.attackRange * 2f, ch.enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            PlayerController enemyController = enemy.GetComponent<PlayerController>();

            if (enemyController.PlayerID != pc.PlayerID)
            {
                int dano = (enemyController.GetComponent<Movimento>().isBlocking) ? 15 : 30;

                pc.GetAudioByName("highPunch").Play();

                enemy.GetComponent<Player2>().TakeDamage(dano);
                var enemyRB = enemy.GetComponent<Rigidbody2D>();
                enemyRB.AddForce(new Vector2(20f * enemyController.ImpulseDirection, 0f), ForceMode2D.Impulse);

                var enemyAnimator = enemy.GetComponent<Animator>();
                enemyAnimator.SetTrigger("Cair");
            }
        }
    }
}
