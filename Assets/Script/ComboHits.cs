using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboHits : MonoBehaviour
{
    public Animator animacao;
    public int noOffClicks = 0;
    float lastClickedTime = 0;
    public float maxComboDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        animacao= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastClickedTime > maxComboDelay)
        {
            noOffClicks = 0;
            animacao.SetBool("SocoFraco1", false);
            animacao.SetBool("SocoFraco2", false);
            
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            lastClickedTime= Time.time;
            noOffClicks++;
            if(noOffClicks == 1)
            {
                animacao.SetBool("SocoFraco1", true);
                float travar = Time.time; 
            }
            
            
            noOffClicks= Mathf.Clamp(noOffClicks,0,3);
        }
    }

    public void return1()
    {
        if(noOffClicks == 2) 
        {
            animacao.SetBool("SocoFraco2", true);
        }
        else
        {
            animacao.SetBool("SocoFraco1", false);
            
            noOffClicks = 0;
        }
    }

    public void return2()
    {
        animacao.SetBool("SocoFraco1", false);
        animacao.SetBool("SocoFraco2", false);
        noOffClicks = 0;
    }
}
