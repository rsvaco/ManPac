using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantasma : MonoBehaviour
{
    public int equipo;
    public int numero;
    private Transform[] waypoints;
    int cur = 0;
    public float speed = 0.3f;

    private void Start()
    {
        setWaypoints();
    }

    void setWaypoints()
    {
        Transform wfan = GameObject.Find("Fantasma" + numero).GetComponent<Transform>();
        int wnum = wfan.childCount;
        waypoints = new Transform[wnum];
        for (int i = 0; i < wnum; ++i)
        {
            waypoints[i] = wfan.GetChild(i);
        }          
    }

    void FixedUpdate()
    {
        if (transform.position != waypoints[cur].position)
        {
            Vector2 p = Vector2.MoveTowards(transform.position, waypoints[cur].position, speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        else cur = (cur + 1) % waypoints.Length;

        Vector2 dir = waypoints[cur].position - transform.position;
        this.GetComponent<Animator>().SetFloat("dirX", dir.x);
        this.GetComponent<Animator>().SetFloat("dirY", dir.y);
    }
    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.tag == "Player")
        {
            if (co.gameObject.GetComponent<Paco>().equipo == equipo) return;
            Destroy(co.gameObject);
            co.GetComponent<Animator>().SetBool("muerte", true);
        }            
    }
}
