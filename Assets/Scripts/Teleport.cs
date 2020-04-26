using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public Vector2 objective = Vector2.zero;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PacoMove>().teleporting = true;
            collision.gameObject.GetComponent<PacoMove>().dest = objective;
            collision.gameObject.transform.position = new Vector3(objective.x, objective.y, collision.gameObject.transform.position.z);
            collision.gameObject.GetComponent<PacoMove>().teleporting = false;
        }

    }
}
