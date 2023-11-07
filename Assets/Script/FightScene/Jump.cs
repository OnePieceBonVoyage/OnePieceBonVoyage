using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] int jumpPower;
    public Transform CheckGround;
    public LayerMask GroundLayer;
    public Animator animacao;
    public PlayerController pc;
    private Movimento movimento;

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

        if (isGrounded() && !Input.GetKeyDown(pc.ButtonUp))
        {
            animacao.SetBool("Pulo", false);
        }
    }
    public void Pular()
    {
        movimento = GetComponent<Movimento>();
        if (Input.GetKeyDown(pc.ButtonUp) && isGrounded() && !movimento.isDashing && !movimento.isCrounch && !movimento.isBlocking)
        {
            pc.GetAudioByName("jump").Play();
            jumpPower = 13;
            rb.gravityScale = 2;
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }
}
