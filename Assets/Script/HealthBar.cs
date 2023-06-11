using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;

        slider.value = health;

        fill.color = gradient.Evaluate(1f);

    }

    public void SetHealth(float novaVida)
    {
        float vidaAtual = slider.value;
        float duracaoAnimacao = 0.5f;

        StartCoroutine(AnimarVida(vidaAtual, novaVida, duracaoAnimacao));
    }

    public IEnumerator AnimarVida(float valorInicial, float valorFinal, float duracao)
    {
        float tempoPassado = 0f;

        while (tempoPassado < duracao)
        {
            float vidaInterpolada = Mathf.Lerp(valorInicial, valorFinal, tempoPassado / duracao);
            slider.value = vidaInterpolada;
	    fill.color = gradient.Evaluate(slider.normalizedValue);
            yield return null;

            tempoPassado += Time.deltaTime;
        }

        slider.value = valorFinal;
    }
}
