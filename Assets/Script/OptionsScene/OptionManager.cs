using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    public Slider slider;
    private float volText = 0;

    public Text volumeLabel1;
    public Text volumeLabel2;

    public static float volume = 50f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        volText = Mathf.Round(slider.value * 100);

        volumeLabel1.text = $"Volume: {volText}";
        volumeLabel2.text = $"Volume: {volText}";

        volume = slider.value;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenuScene");
        }
    }
}
