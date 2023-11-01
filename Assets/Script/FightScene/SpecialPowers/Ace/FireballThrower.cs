using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballThrower : MonoBehaviour
{
    public PlayerController pc;
    public ComboHits ch;
    public GameObject fireballPrefab;

    private Animator animacao;

    // Start is called before the first frame update
    void Start()
    {
        animacao = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pc.ButtonSpecialAttack) && ch.canMakeSpecial)
        {
            ShootFireball();
            ch.nextAttackTime = Time.time + 1f / ch.attackRate;
            ch.specialCooldown = 10f;
        }
    }

    void ShootFireball()
    {
        animacao.SetTrigger("Power");
        fireballPrefab.GetComponent<Fireball>().author = pc;
        fireballPrefab.GetComponent<Fireball>().direction = 1f;
        Vector3 fireballPosition = transform.position;
        fireballPosition.y += 1.5f;
        Instantiate(fireballPrefab, fireballPosition, Quaternion.identity);
    }
}
