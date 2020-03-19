using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Color[] colors;

    [RangeAttribute(0, 4)]
    public int numJugadores;

    public GameObject[] spawns;
    public GameObject[] spawnsFantasmas;

    public GameObject pacoPrefab;
    public GameObject fantasmaPrefab;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numJugadores; i++)
        {
            GameObject paco = Instantiate(pacoPrefab, spawns[i].transform.position, Quaternion.identity);
            //paco.GetComponent<SpriteRenderer>().color = colors[i];
            GameObject fant = Instantiate(fantasmaPrefab, spawnsFantasmas[i].transform.position, Quaternion.identity);
            //fant.GetComponent<SpriteRenderer>().color = colors[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
