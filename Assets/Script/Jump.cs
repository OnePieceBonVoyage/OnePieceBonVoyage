using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] int jumpPower;
    public Transform CheckGround;
    public LayerMask GroundLayer;
    public Animator animacao;





    public bool isGrounded()
    {
        return Physics2D.OverlapCapsule(
            CheckGround.position,
            new Vector2(1.8f, 0.3f),
            CapsuleDirection2D.Horizontal,
            0,
            GroundLayer
        );
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Pular();
        AnimacaoPular();
        
    }

    
    public void Pular()
    {

        if (Input.GetButtonDown("Jump") && isGrounded() && !Movimento.isDashing && !Movimento.isCrounch )
        {
            animacao.SetBool("SocoFraco1", false);
            animacao.SetBool("SocoFraco2", false);
            jumpPower = 10;
            rb.gravityScale = 2;
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }

    private void AnimacaoPular()
    {
        animacao = gameObject.GetComponent<Animator>();
        if (Input.GetButtonDown("Jump") && !Movimento.isDashing && !Movimento.isCrounch)
        {
            animacao.SetBool("Pulo", true);
        }
        else
        {
            animacao.SetBool("Pulo", false);
        }
    }

    

    
}
