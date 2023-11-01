using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class FightResolver : MonoBehaviour
{
    public GameObject Luffy;
    public GameObject Zoro;
    public GameObject Ace;

    public static GameObject player1;
    public static GameObject player2;

    public HealthBar healthBarP1;
    public HealthBar healthBarP2;

    public SpecialBar specialBarP1;
    public SpecialBar specialBarP2;

    public GameObject P1Position;
    public GameObject P2Position;

    public GameObject AudiosP1;
    public GameObject AudiosP2;

    public GameObject GetPlayerByName(string name)
    {
        switch (name)
        {
            case "luffy":
                return Luffy;

            case "zoro":
                return Zoro;

            case "ace":
                return Ace;

            default:
                throw new Exception("Não está encontrando personagem");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        var p1 = GetPlayerByName(CharacterSelect.p1);
        var p2 = GetPlayerByName(CharacterSelect.p2);

        p1.transform.position = P1Position.transform.position;
        p2.transform.position = P2Position.transform.position;

        p1.GetComponent<PlayerController>().IsPlayerOne = true;
        p2.GetComponent<PlayerController>().IsPlayerOne = false;

        player1 = Instantiate(p1);
        player2 = Instantiate(p2);

        var ap = ComponentUtil.GetComponentOfObject<AjustarPosicao>("AjustarPosicao");
        var cf = ComponentUtil.GetComponentOfObject<CameraFollow>("Main Camera");
        var fm = ComponentUtil.GetComponentOfObject<FightManager>("FightManager");

        player1.GetComponent<ComboHits>().specialBar = specialBarP1;
        player2.GetComponent<ComboHits>().specialBar = specialBarP2;

        ap.player1 = player1.transform;
        ap.player2 = player2.transform;

        cf.target1 = player1.transform;
        cf.target2 = player2.transform;

        fm.Player1 = player1.GetComponent<Player2>();
        fm.Player2 = player2.GetComponent<Player2>();

        player1.GetComponent<ComboHits>().enemyStats = player2.GetComponent<Player2>();
        player2.GetComponent<ComboHits>().enemyStats = player1.GetComponent<Player2>();

        player1.GetComponent<Player2>().healthBar = healthBarP1;
        player2.GetComponent<Player2>().healthBar = healthBarP2;

        var pc1 = player1.GetComponent<PlayerController>();
        var pc2 = player2.GetComponent<PlayerController>();

        pc1.Audios = AudiosP1;
        pc2.Audios = AudiosP2;

        LoadPlayerKeys(ref pc1, true);
        LoadPlayerKeys(ref pc2, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void LoadPlayerKeys(ref PlayerController player, bool IsPlayerOne)
    {
        if (IsPlayerOne)
        {
            player.HorizontalKey = "Horizontal";

            player.ButtonUp = KeyCode.W;
            player.ButtonDown = KeyCode.S;
            player.ButtonLeft = KeyCode.A;
            player.ButtonRight = KeyCode.D;

            player.ButtonLowAttack = KeyCode.R;
            player.ButtonHighAttack = KeyCode.T;
            player.ButtonSpecialAttack = KeyCode.U;

            player.ButtonGuard = KeyCode.Y;
        }
        else
        {
            player.HorizontalKey = "Horizontal2";

            player.ButtonUp = KeyCode.UpArrow;
            player.ButtonDown = KeyCode.DownArrow;
            player.ButtonLeft = KeyCode.LeftArrow;
            player.ButtonRight = KeyCode.RightArrow;

            player.ButtonLowAttack = KeyCode.Keypad1;
            player.ButtonHighAttack = KeyCode.Keypad2;
            player.ButtonSpecialAttack = KeyCode.Keypad4;

            player.ButtonGuard = KeyCode.Keypad3;
        }
    }
}
