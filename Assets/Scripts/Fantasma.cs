using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Fantasma : MonoBehaviour
{
    public int equipo;
    public int numero;
    
    int cur = 0;
    public float speed = 0.3f;

    private void Start()
    {
        setWaypoints();

    }

    void setWaypoints()
    {
        GameObject[] arrayWaypoints = GameObject.Find("GameController").GetComponent<GameController>().waypoints;
        

        int[] cards = Enumerable.Range(0, arrayWaypoints.Length).ToArray();
        var shuffledcards = cards.OrderBy(a => Guid.NewGuid()).ToList();
        
        Transform[] waypoints = new Transform[arrayWaypoints.Length];

        for (int i = 0; i < arrayWaypoints.Length; ++i)
        {
            waypoints[i] = arrayWaypoints[shuffledcards[i]].transform;
        }
        print("alla voy");
        gameObject.GetComponent<Patrol>().targets = waypoints;

    }

    void FixedUpdate()
    {/*
        if (transform.position != waypoints[cur].position)
        {
            Vector2 p = Vector2.MoveTowards(transform.position, waypoints[cur].position, speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        else cur = (cur + 1) % waypoints.Length;

        Vector2 dir = waypoints[cur].position - transform.position;
        this.GetComponent<Animator>().SetFloat("dirX", dir.x);
        this.GetComponent<Animator>().SetFloat("dirY", dir.y);*/
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.tag == "Player")
        {
            if (co.gameObject.GetComponent<Paco>().equipo == equipo) return;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().pacoMuerto(co.gameObject.GetComponent<Paco>().equipo);
        }            
    }
}
