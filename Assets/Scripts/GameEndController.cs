using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameEndController : MonoBehaviour
{

    public bool show = false;
    private bool processed = false;
    public GameObject child;
    private GameController gameController;
    public TextMeshProUGUI[] scoreboard;
    public int[] ranking = { 0, -1, -1, -1 };

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        child.SetActive(show);
        if (!show && processed) processed = false;
        if (show && !processed)
        {
            if (gameController.score[1] > gameController.score[0]) { ranking[0] = 1; ranking[1] = 0; }
            else { ranking[1] = 1; ranking[0] = 0; }

            if (gameController.score[2] > gameController.score[ranking[0]])
            {
                ranking[2] = ranking[1]; ranking[1] = ranking[0]; ranking[0] = 2;
            }
            else if (gameController.score[2] > gameController.score[ranking[1]])
            {
                ranking[2] = ranking[1]; ranking[1] = 2;
            }
            else ranking[2] = 2;

            if (gameController.score[3] > gameController.score[ranking[0]])
            {
                ranking[3] = ranking[2]; ranking[2] = ranking[1]; ranking[1] = ranking[0]; ranking[0] = 3;
            }
            else if (gameController.score[3] > gameController.score[ranking[1]])
            {
                ranking[3] = ranking[2]; ranking[2] = ranking[1]; ranking[1] = 3;
            }
            else if (gameController.score[3] > gameController.score[ranking[1]])
            {
                ranking[3] = ranking[2]; ranking[2] = 3;
            }
            else ranking[3] = 3;

            for (int i = 0; i < 4; i++)
            {
                if (ranking[i] < gameController.numJugadores)
                {
                    scoreboard[i].text = (i+1) + " - P" + (ranking[i] + 1) + " - " + gameController.score[ranking[i]];
                    scoreboard[i].color = gameController.colors[ranking[i]];
                }
                else
                    scoreboard[i].color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            }

            processed = true;
            Debug.Log("PROCESSED");
        }
    }
}
