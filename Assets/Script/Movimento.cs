using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    
    //Variaveis de movimento
    public static float horizontal;
    private float speed = 5f;
    private bool isFacingRight = true;
    public Animator animacao; 

    //Agachar variaveis
    public static bool isCrounch = false;
    private float vertical;

    //Variaveis de Dash
    private float dashDistance = 8f;
    public static bool isDashing;

    private float doubleTapTime;
    public static KeyCode lastKeyCode;

    //defender
    public static bool isBlocking = false;

    public Transform CheckGround;
    public LayerMask GroundLayer;

    [SerializeField] private Rigidbody2D rb;


    // Update is called once per frame
    void Update()
    {
        if (!isCrounch && !isBlocking && !isDashing)
            horizontal = Input.GetAxisRaw("Horizontal");

        vertical = Input.GetAxisRaw("Vertical");
        animacao = gameObject.GetComponent<Animator>();

        DarDashDireita();
        DarDashEsquerda();
        Defender();
    }

    private void FixedUpdate()
    {
        if (!isDashing)
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void DarDashEsquerda()
    {
        //Dashing Left/Esquerda Teclado
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (doubleTapTime > Time.time && lastKeyCode == KeyCode.A && isGrounded() && !isCrounch && !isBlocking)
            {
                StartCoroutine(dash(-1f));
            }
            else
            {
                doubleTapTime = Time.time + 0.5f;
            }
            lastKeyCode = KeyCode.A;
        }
    }

    private void DarDashDireita()
    {
        //Dashin Right/Direita Teclado
        if (Input.GetKeyDown(KeyCode.D))
        {

            if (doubleTapTime > Time.time && lastKeyCode == KeyCode.D && isGrounded() && !isCrounch && !isBlocking)
            {
                StartCoroutine(dash(1f));
            }
            else
            {
                doubleTapTime = Time.time + 0.5f;
            }
            lastKeyCode = KeyCode.D;
        }
    }
    //Tentar fazer uma funçao para quando dar double tap fazer a animacao

    IEnumerator dash(float direcao)
    {
        isDashing = true;

        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(new Vector2(dashDistance * direcao, 0f), ForceMode2D.Impulse);
        float gravity = rb.gravityScale;
        rb.gravityScale = 0;
        rb.gravityScale = gravity;
        yield return new WaitForSeconds(0.5f);
        isDashing = false;

    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCapsule(
            CheckGround.position,
            new Vector2(1.8f, 0.3f),
            CapsuleDirection2D.Horizontal,
            0,
            GroundLayer
        );
    }

    public void Defender()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            isBlocking= true;
            animacao.SetBool("Defender", true);
        }
        else if (Input.GetKeyUp(KeyCode.G))
        {
            isBlocking= false;
            animacao.SetBool("Defender", false);
        }
    }
}
