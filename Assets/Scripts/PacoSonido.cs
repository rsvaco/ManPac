using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacoSonido : MonoBehaviour
{
    public AudioSource[] audios;
    private int rate = 20;
    private int current = 0;
    private int count = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.GetComponent<PacoMove>().moviendose)
        {
            count++;
            if (count % rate == 0)
            {
                print("a");
                audios[current].gameObject.SetActive(true);
                audios[audios.Length - current - 1].gameObject.SetActive(false);
                current = (current + 1) % audios.Length;
            }
        }
    }
}
