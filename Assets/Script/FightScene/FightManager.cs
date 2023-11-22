using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightManager : MonoBehaviour
{
    public Player2 Player1;
    public Player2 Player2;
    public SpriteRenderer StageBackground;
    public SpriteRenderer TextKO;
    public CameraFollow cameraFollow;

    public static bool IsFinished = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Player2.currentHealth <= 0)
        {
            Player1.Winner();
            Player2.Die();

            Debug.Log("Vitória do player 1");

            
            Destroy(Player1.GetComponent<Movimento>());
            Destroy(Player1.GetComponent<Animacoes>());
            Destroy(Player1.GetComponent<Jump>());
            Destroy(Player1.GetComponent<ComboHits>());

            Destroy(Player2.GetComponent<Movimento>());
            Destroy(Player2.GetComponent<Animacoes>());
            Destroy(Player2.GetComponent<Jump>());
            Destroy(Player2.GetComponent<ComboHits>());

            DisplayKO();
            this.StageBackground.color = Color.black;
            this.enabled = false;

            StartCoroutine(ReturnMenu());
        }
        else if (Player1.currentHealth <= 0)
        {
            Player2.Winner();
            Player1.Die();

            Debug.Log("Vitória do player 2");


            Destroy(Player1.GetComponent<Movimento>());
            Destroy(Player1.GetComponent<Animacoes>());
            Destroy(Player1.GetComponent<Jump>());
            Destroy(Player1.GetComponent<ComboHits>());

            Destroy(Player2.GetComponent<Movimento>());
            Destroy(Player2.GetComponent<Animacoes>());
            Destroy(Player2.GetComponent<Jump>());
            Destroy(Player2.GetComponent<ComboHits>());

            DisplayKO();
            this.StageBackground.color = Color.black;
            this.enabled = false;

            StartCoroutine(ReturnMenu());
        }
    }

    public IEnumerator ReturnMenu()
    {
        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("MainMenuScene");
    }

    public async void DisplayKO()
    {
        await Task.Delay(1000);

        this.TextKO.enabled = true;

        Vector3 middlePoint = new Vector3(cameraFollow.cameraLeftEdge + (cameraFollow.cameraWidth / 2), cameraFollow.middlePoint.y, 0f);

        middlePoint.y = +1f;

        this.TextKO.transform.position = middlePoint;
    }
}
