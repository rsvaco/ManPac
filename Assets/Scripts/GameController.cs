using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public Color[] colors;

    [RangeAttribute(0, 4)]
    public int numJugadores;

    public GameObject[] spawns;
    public GameObject[] spawnsFantasmas;

    public GameObject pacoPrefab;
    public GameObject fantasmaPrefab;

    public GameObject scoreObject;
    private int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numJugadores; i++)
        {
            GameObject paco = Instantiate(pacoPrefab, spawns[i].transform.position, Quaternion.identity);
            paco.GetComponent<SpriteRenderer>().color = colors[i];
            paco.GetComponent<PacoMove>().playerNumber = i+1;
            GameObject fant = Instantiate(fantasmaPrefab, spawnsFantasmas[i].transform.position, Quaternion.identity);
            fant.GetComponent<SpriteRenderer>().color = colors[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore()
    {
        score++;
        if(score < 10)
        {
            scoreObject.GetComponent<TextMeshProUGUI>().text = "00" + score.ToString();

        }
        else if(score < 100)
        {
            scoreObject.GetComponent<TextMeshProUGUI>().text = "0" + score.ToString();
        }
        else
        {
            scoreObject.GetComponent<TextMeshProUGUI>().text = score.ToString();
        }        
    }
}
