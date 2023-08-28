using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacoes : MonoBehaviour
{
    public Animator animacao;
    public PlayerController pc;
    public Movimento movimento;

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
        if (movimento != null)
        {
            if (movimento.horizontal > 0f)
            {
                animacao.SetBool("AndarDireita", true);
            }
            else
            {
                animacao.SetBool("AndarDireita", false);
            }
        }
    }

    private void FazerAnimacaoEsquerda()
    {
        if (movimento != null)
        {
            if (movimento.horizontal < 0f)
            {
                animacao.SetBool("AndarEsquerda", true);
            }
            else
            {
                animacao.SetBool("AndarEsquerda", false);
            }
        }
    }

    private void AnimacaoPular()
    {
        if (movimento != null)
        {
            if (Input.GetKeyDown(pc.ButtonUp) && !movimento.isDashing && !movimento.isCrounch)
            {
                animacao.SetBool("Pulo", true);
            }
            else
            {
                animacao.SetBool("Pulo", false);
            }
        }
    }

    private void AnimacaoDashDireita()
    {
        if (movimento != null)
        {
            if (movimento.isDashing && movimento.lastKeyCode == pc.ButtonRight)
            {
                animacao.SetBool("DashDireita", true);
                animacao.SetBool("AndarDireita", false);
            }
            else
            {
                animacao.SetBool("DashDireita", false);
            }
        }
    }

    private void AnimacaoDashEsquerda()
    {
        if (movimento != null)
        {
            if (movimento.isDashing && movimento.lastKeyCode == pc.ButtonLeft)
            {
                animacao.SetBool("DashEsquerda", true);
                animacao.SetBool("AndarEsquerda", false);
            }
            else
            {
                animacao.SetBool("DashEsquerda", false);
            }
        }
    }

    private void Agachar()
    {
        if (movimento != null)
        {
            if (Input.GetKeyDown(pc.ButtonDown))
            {
                movimento.isCrounch = true;
                animacao.SetBool("Agachar", true);
            }
            else if (Input.GetKeyUp(pc.ButtonDown))
            {
                movimento.isCrounch = false;
                animacao.SetBool("Agachar", false);
            }
        }
    }
}
