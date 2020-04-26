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

    public GameObject[] scoreObject;
    private int[] score = { 0, 0, 0, 0 };
    public Color foregroudColor, backgroundColor;
    public Tilemap foregroundTileMap, backgroundTileMap;
    private GlobalOptions globalOptions;


    // Start is called before the first frame update
    void Start()
    {

        if (useGlobalOptionsColors)
        {
            globalOptions = GameObject.Find("GlobalOptions").GetComponent<GlobalOptions>();
            for (int i = 0; i < 4; i++)
            {
                colors[i] = globalOptions.playerColors[i];
                foregroudColor = globalOptions.mainColor;
                backgroundColor = globalOptions.backColor;
                numJugadores = globalOptions.numJugadores;
            }
        }


        for (int i = 0; i < numJugadores; i++)
        {
            GameObject paco = Instantiate(pacoPrefab, spawns[i].transform.position, Quaternion.identity);
            paco.GetComponent<SpriteRenderer>().color = colors[i];
            paco.GetComponent<PacoMove>().playerNumber = i+1;
            paco.GetComponent<Paco>().equipo = i;
            GameObject fant = Instantiate(fantasmaPrefab, spawnsFantasmas[i].transform.position, Quaternion.identity);
            fant.GetComponent<SpriteRenderer>().color = colors[i];
            fant.GetComponent<Fantasma>().numero = i;
            fant.GetComponent<Fantasma>().equipo = i;
            scoreObject[i].GetComponent<TextMeshProUGUI>().color = colors[i];
        }

        foregroundTileMap.color = foregroudColor;
        backgroundTileMap.color = backgroundColor;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore(int equipo)
    {
        score[equipo]++;
        if(score[equipo] < 10)
        {
            scoreObject[equipo].GetComponent<TextMeshProUGUI>().text = "00" + score[equipo].ToString();

        }
        else if(score[equipo] < 100)
        {
            scoreObject[equipo].GetComponent<TextMeshProUGUI>().text = "0" + score[equipo].ToString();
        }
        else
        {
            scoreObject[equipo].GetComponent<TextMeshProUGUI>().text = score[equipo].ToString();
        }        
    }
}
