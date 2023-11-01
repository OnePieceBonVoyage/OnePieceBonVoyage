using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxSpecial(float special)
    {
        slider.maxValue = Mathf.Abs(special - 10f) * 10;

        slider.value = Mathf.Abs(special - 10f) * 10;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetSpecial(float newSpecialStatus)
    {
        float currentSpecial = slider.value;
        float duracaoAnimacao = 0.5f;

        StartCoroutine(AnimarVida(currentSpecial, newSpecialStatus, duracaoAnimacao));
    }

    public IEnumerator AnimarVida(float valorInicial, float valorFinal, float duracao)
    {
        float tempoPassado = 0f;

        while (tempoPassado < duracao)
        {
            float smoothedSpecial = Mathf.Lerp(valorInicial, valorFinal, tempoPassado / duracao);
            slider.value = smoothedSpecial;
            fill.color = gradient.Evaluate(slider.normalizedValue);
            yield return null;

            tempoPassado += Time.deltaTime;
        }

        slider.value = valorFinal;
    }
}
