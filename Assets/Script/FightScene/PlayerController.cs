using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public KeyCode ButtonSpecialAttack;

    public KeyCode ButtonGuard;

    public bool IsPlayerOne;
    
    public float ImpulseDirection;
    public bool FlipNeeded;

    public GameObject Audios;

    public void Start()
    {
        ImpulseDirection = IsPlayerOne ? 1f : -1f;
    }

    public AudioSource GetAudioByName(string audioName)
    {
        List<AudioSource> audios = Audios.GetComponentsInChildren<AudioSource>().ToList();
        var audio = audios.Find(a => a.name == audioName);

        audio.volume = OptionManager.volume;

        return audio;
    }
}