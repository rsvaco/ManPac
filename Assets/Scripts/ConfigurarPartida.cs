using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfigurarPartida : MonoBehaviour
{
    public int segundosMax = 6000;

    //mantener mismo orden
    public GameObject[] listaImagenes;
    public int[] listaImagenesOrdenDeCarga;


    private int numJugadores = 1;
    private int segundosTotal = 120;
    private int mapaSeleccionado = 0;

    public TextMeshProUGUI text_jugadores, text_segundos;
    public GameObject img_mapa;

    public void addSegundos(int cantidad) {
        segundosTotal = Mathf.Min(segundosMax, segundosTotal + cantidad);
        updateSegundos();
    }

    public void quitarSegundos(int cantidad)
    {
        segundosTotal = Mathf.Max(30, segundosTotal - cantidad);
        updateSegundos();
    }

    private void updateSegundos() {
        int minutos = (int)Mathf.Floor(segundosTotal / 60);
        int segundos = segundosTotal % 60;
        string stringSegundos = "00" + segundos;
        stringSegundos = stringSegundos.Substring(stringSegundos.Length - 2);
        text_segundos.text = "" + minutos + ":" + stringSegundos;
    }

    public void siguienteMapa() {
        if (mapaSeleccionado == listaImagenes.Length - 1) {
            mapaSeleccionado = 0;
        }
        else
        {
            mapaSeleccionado++;
        }
        updateMapa();
    }

    public void anteriorMapa() {
        if (mapaSeleccionado == 0)
        {
            mapaSeleccionado = listaImagenes.Length - 1;
        }
        else {
            mapaSeleccionado--;
        }
        updateMapa();
    }

    private void updateMapa() {
        for (int i = 0; i < listaImagenes.Length; i++) {
            if (i == mapaSeleccionado)
            {
                listaImagenes[i].SetActive(true);
            }
            else {
                listaImagenes[i].SetActive(false);
            }
        }
    }

    public void addJugadores(int cantidad)
    {
        numJugadores = Mathf.Min(4, numJugadores + cantidad);
        text_jugadores.text = numJugadores.ToString();
    }

    public void quitarJugadores(int cantidad)
    {
        numJugadores = Mathf.Max(1, numJugadores - cantidad);
        text_jugadores.text = numJugadores.ToString();
    }


    void Start()
    {
        text_jugadores.text = numJugadores.ToString();
        updateSegundos();
        updateMapa();
    }


}
