using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacoes : MonoBehaviour
{
    public Animator animacao;

    // Update is called once per frame
    void Update()
    {
        AnimacaoPular();

        FazerAnimacaoDireita();
        FazerAnimacaoEsquerda();

        AnimacaoDashDireita();
        AnimacaoDashEsquerda();

        Agachar();
    }

    private void FazerAnimacaoDireita()
    {
        if (Movimento.horizontal > 0f)
        {
            animacao.SetBool("AndarDireita", true);
        }
        else
        {
            animacao.SetBool("AndarDireita", false);
        }
    }

    private void FazerAnimacaoEsquerda()
    {
        if (Movimento.horizontal < 0f)
        {
            animacao.SetBool("AndarEsquerda", true);
        }
        else
        {
            animacao.SetBool("AndarEsquerda", false);
        }
    }

    private void AnimacaoPular()
    {
        animacao = gameObject.GetComponent<Animator>();

        if (Input.GetKeyDown(KeyCode.W) && !Movimento.isDashing && !Movimento.isCrounch)
        {
            animacao.SetBool("Pulo", true);
        }
        else
        {
            animacao.SetBool("Pulo", false);
        }
    }

    private void AnimacaoDashDireita()
    {
        if (Movimento.isDashing == true && Movimento.lastKeyCode == KeyCode.D)
        {
            animacao.SetBool("DashDireita", true);
            animacao.SetBool("AndarDireita", false);
        }
        else
        {
            animacao.SetBool("DashDireita", false);
        }
    }

    private void AnimacaoDashEsquerda()
    {
        if (Movimento.isDashing == true && Movimento.lastKeyCode == KeyCode.A)
        {
            animacao.SetBool("DashEsquerda", true);
            animacao.SetBool("AndarEsquerda", false);
        }
        else
        {
            animacao.SetBool("DashEsquerda", false);
        }
    }

    private void Agachar()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Movimento.isCrounch = true;
            animacao.SetBool("Agachar", true);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            Movimento.isCrounch = false;
            animacao.SetBool("Agachar", false);
        }
    }
}
