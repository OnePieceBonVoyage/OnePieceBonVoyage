using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string PlayerID;

    public string HorizontalKey;

    public KeyCode ButtonUp;
    public KeyCode ButtonDown;
    public KeyCode ButtonLeft;
    public KeyCode ButtonRight;

    public KeyCode ButtonLowAttack;
    public KeyCode ButtonHighAttack;

    public KeyCode ButtonGuard;

    public bool IsPlayerOne;
    
    public float ImpulseDirection;

    public void Start()
    {
        ImpulseDirection = IsPlayerOne ? -1f : 1f;
    }
}