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

    /**
     * Captura o pressionamento da tecla "UP" referente ao jogador
     * se a tecla for pressionada, permitir a animação do pulo.
     */
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

    /**
     * Capturar o pressionamento da tecla "Down" referente ao jogador
     * se a tecla for pressionada, o personagem irá agachar.
     */
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
