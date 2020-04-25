using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacdot : MonoBehaviour
{
    private GameController gameController;

    void Start() 
    {
             gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("COLISIÓN");
        if(collision.tag == "Player")
        {
            Destroy(gameObject);
            gameController.addScore();
        }
    }
 
    
}
