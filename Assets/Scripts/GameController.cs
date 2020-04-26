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
    public int[] vidas = { 3, 3, 3, 3 };
    public int[] score = { 0, 0, 0, 0 };
    public Color foregroudColor, backgroundColor;
    public Tilemap foregroundTileMap, backgroundTileMap;
    private GlobalOptions globalOptions;
    private GameObject[] pacos = new GameObject[4];
    private int tiempoMax;
    private int tiempoRestante;
    private int elapsed = 0;

    public GameObject timer;


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
                tiempoMax = globalOptions.segundosMax;
                tiempoRestante = tiempoMax;
            }
        }


        for (int i = 0; i < numJugadores; i++)
        {
            pacos[i] = Instantiate(pacoPrefab, spawns[i].transform.position, Quaternion.identity);
            pacos[i].GetComponent<SpriteRenderer>().color = colors[i];
            pacos[i].GetComponent<PacoMove>().playerNumber = i+1;
            pacos[i].GetComponent<PacoMove>().spawn = spawns[i].transform.position;
            pacos[i].GetComponent<Paco>().equipo = i;
            GameObject fant = Instantiate(fantasmaPrefab, spawnsFantasmas[i].transform.position, Quaternion.identity);
            fant.GetComponent<SpriteRenderer>().color = colors[i];
            fant.GetComponent<Fantasma>().numero = i;
            fant.GetComponent<Fantasma>().equipo = i;
            scoreObject[i].GetComponent<InterfaceController>().playerColor = colors[i];
        }

        foregroundTileMap.color = foregroudColor;
        backgroundTileMap.color = backgroundColor;

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < numJugadores; i++) {
            InterfaceController tmp = scoreObject[i].GetComponent<InterfaceController>();
            tmp.score = score[i];
            scoreObject[i].GetComponent<InterfaceController>().lives = vidas[i];
        }

        //timer
        elapsed = (int) Time.time;
        tiempoRestante = Mathf.Max(tiempoMax - elapsed, 0);
        if (tiempoRestante == 0) {
            fin();
        }

        timer.GetComponent<TextMeshProUGUI>().text = formatearTiempo(tiempoRestante);
    }

    private string formatearTiempo(int segundosTotal)
    {
        int minutos = (int)Mathf.Floor(segundosTotal / 60);
        int segundos = segundosTotal % 60;
        string stringSegundos = "00" + segundos;
        stringSegundos = stringSegundos.Substring(stringSegundos.Length - 2);
        string text = "" + minutos + ":" + stringSegundos;
        return text;
    }

    private bool fin() {

        return true;
    }

    public void addScore(int equipo)
    {
        score[equipo]++;
    }

    public void pacoMuerto(int equipo) // Abono pa mi huerto.
    {
        vidas[equipo]--;
        if (vidas[equipo] != 0) pacos[equipo].GetComponent<PacoMove>().respawn();
        else GameObject.Destroy(pacos[equipo]);

        //comprobar si queda algun equipo vivo
        //si no, terminar partida
        bool todosMuertos = true;
        foreach (int v in vidas) {
            if (v > 0) { todosMuertos = false; }
        }
        if (todosMuertos) { fin(); }
    }

}
