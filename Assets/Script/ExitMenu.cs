using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitForExit());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator waitForExit()
    {
        yield return new WaitForSeconds(6);

        // Editor
        UnityEditor.EditorApplication.isPlaying = false;


        // Compilado
        // Application.Quit();
    }
}
