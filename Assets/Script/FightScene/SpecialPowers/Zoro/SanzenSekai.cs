using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanzenSekai : MonoBehaviour
{
    public PlayerController pc;
    public ComboHits ch;

    private Animator animacao;

    // Start is called before the first frame update
    void Start()
    {
        animacao = GetComponent<Animator>();
    }


    private bool jaAtacou = false;
    void Update()
    {
        if (Input.GetKeyDown(pc.ButtonSpecialAttack) && ch.canMakeSpecial)
        {
            SanzenSekaiGirar();
            ch.nextAttackTime = Time.time + 3f / 1f;
            ch.specialCooldown = 10f;
        }

        VerificaCorte();
    }

    void VerificaCorte()
    {
        animacao = GetComponent<Animator>();

        AnimatorStateInfo stateInfo = animacao.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("Corte") && !jaAtacou)
        {
            StartCoroutine(SanzenSekaiEspecial());
            StartCoroutine(AguardarDash());
        }
    }

    public void SanzenSekaiGirar()
    {
        animacao.SetTrigger("SanzenSekai");
    }

    public IEnumerator AguardarDash()
    {
        yield return new WaitForSeconds(.6f);
        pc.GetComponent<Rigidbody2D>().AddForce(new Vector2(50f * pc.ImpulseDirection, 0f), ForceMode2D.Impulse);
    }

    public IEnumerator SanzenSekaiEspecial()
    {
        animacao.SetTrigger("SanzenSekai");

        animacao.GetComponent<Movimento>().enabled = false;

        jaAtacou = true;
        yield return new WaitForSeconds(.8f);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(ch.Attackpoint.position, ch.attackRange * 2f, ch.enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            PlayerController enemyController = enemy.GetComponent<PlayerController>();

            if (enemyController.PlayerID != pc.PlayerID)
            {
                int dano = (enemyController.GetComponent<Movimento>().isBlocking) ? 15 : 30;

                pc.GetAudioByName("highPunch").Play();

                enemy.GetComponent<Player2>().TakeDamage(dano);
                enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(3f * pc.ImpulseDirection, 0f), ForceMode2D.Impulse);

                var enemyAnimator = enemy.GetComponent<Animator>();
                enemyAnimator.SetTrigger("Cair");
            }
        }

        yield return new WaitForSeconds(2f);
        jaAtacou = false;
    }
}
