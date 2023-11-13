using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Rigidbody2D nuvensRb;
    public Rigidbody2D sunnyRb;

    public AudioSource bgmMusic;
    // Start is called before the first frame update
    void Start()
    {
        nuvensRb.AddForce(new Vector2(5f, 0));
        StartCoroutine(CoupDeBurst());
        bgmMusic.volume = OptionManager.volume / 100f;
    }

    IEnumerator CoupDeBurst()
    {
        yield return new WaitForSeconds(10);

        sunnyRb.AddForce(new Vector2(-20f, 20f), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("ExitScene");
    }

    public void LoadAceScene()
    {
        SceneManager.LoadScene("CharSelect");
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene("OptionsScene");
    }
}