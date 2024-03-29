using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    //Variaveis de movimento
    public float horizontal;
    private float speed = 5f;
    private bool isFacingRight = true;
    public Animator animacao; 

    //Agachar variaveis
    public bool isCrounch = false;

    public bool isDashing;

    private float doubleTapTime;
    public KeyCode lastKeyCode;

    //defender
    public bool isBlocking = false;

    public Transform CheckGround;
    public LayerMask GroundLayer;

    [SerializeField] private Rigidbody2D rb;

    public PlayerController pc;

    // Update is called once per frame
    void Update()
    {
        if (!isCrounch && !isBlocking && !isDashing)
            horizontal = Input.GetAxisRaw(pc.HorizontalKey);

        animacao = gameObject.GetComponent<Animator>();

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
        if (Input.GetKeyDown(pc.ButtonGuard))
        {
            isBlocking = true;
            animacao.SetBool("Defender", true);
        }
        else if (Input.GetKeyUp(pc.ButtonGuard))
        {
            isBlocking = false;
            animacao.SetBool("Defender", false);
        }
    }
}
