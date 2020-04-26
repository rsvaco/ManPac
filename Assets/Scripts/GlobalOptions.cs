using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalOptions : MonoBehaviour
{
    private static GlobalOptions instance = null;

    /* VARIABLES GLOBALES */

    // Colors
    public Color[] playerColors = {new Color(1f,1f,0f), new Color(1f,0f,0f), new Color(0f,1f,1f), new Color(1f,0f,0.5f) };
    public Color mainColor = new Color(0.2f,0f,1f), backColor = new Color(0f, 0f, 0f);
    public int numJugadores = 4;
    public int segundosMax = 2 * 60;

    /**********************/
    void Start() {
        if (instance == null) {
            DontDestroyOnLoad(gameObject);
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }
}