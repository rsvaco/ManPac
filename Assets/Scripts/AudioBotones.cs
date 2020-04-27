using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBotones : MonoBehaviour
{
    private static AudioBotones instance = null;

    public void sonar() {
        gameObject.GetComponent<AudioSource>().Play();
    }

    void Start()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
