using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacdot : MonoBehaviour
{
    [SerializeField]
    private GameObject gameController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(gameObject);
            gameController.GetComponent<GameController>().addScore();
        }
    }

    
}
