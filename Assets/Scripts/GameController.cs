using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Tilemaps;

public class GameController : MonoBehaviour
{
    public Color[] colors;
    public bool useGlobalOptionsColors = false;

    [RangeAttribute(0, 4)]
    public int numJugadores;

    public GameObject[] spawns;
    public GameObject[] spawnsFantasmas;

    public GameObject pacoPrefab;
    public GameObject fantasmaPrefab;

    public GameObject scoreObject;
    private int score = 0;
    public Color foregroudColor, backgroundColor;
    public Tilemap foregroundTileMap, backgroundTileMap;
    private GlobalOptions globalOptions;


    // Start is called before the first frame update
    void Start()
    {
        globalOptions = GameObject.Find("GlobalOptions").GetComponent<GlobalOptions>();

        if (useGlobalOptionsColors) for (int i = 0; i < 4; i++) {
                colors[i] = globalOptions.playerColors[i];
                foregroudColor = globalOptions.mainColor;
                backgroundColor = globalOptions.backColor;
        }


        for (int i = 0; i < numJugadores; i++)
        {
            GameObject paco = Instantiate(pacoPrefab, spawns[i].transform.position, Quaternion.identity);
            paco.GetComponent<SpriteRenderer>().color = colors[i];
            paco.GetComponent<PacoMove>().playerNumber = i+1;
            GameObject fant = Instantiate(fantasmaPrefab, spawnsFantasmas[i].transform.position, Quaternion.identity);
            fant.GetComponent<SpriteRenderer>().color = colors[i];
            fant.GetComponent<Fantasma>().numero = i;
        }

        foregroundTileMap.color = foregroudColor;
        backgroundTileMap.color = backgroundColor;

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
