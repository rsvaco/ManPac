using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjustarVolumen : MonoBehaviour
{
    private GlobalOptions globalOptions;

    // Start is called before the first frame update
    void Start()
    {
        globalOptions = GameObject.Find("GlobalOptions").GetComponent<GlobalOptions>();

        AudioSource[] sources = (AudioSource[]) Object.FindObjectsOfType<AudioSource>();
        foreach (AudioSource s in sources) {
            s.volume = globalOptions.effectsVolume;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
