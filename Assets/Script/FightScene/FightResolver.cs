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

    public GameObject P1Position;
    public GameObject P2Position;

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

        player1 = Instantiate(p1);
        player2 = Instantiate(p2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
