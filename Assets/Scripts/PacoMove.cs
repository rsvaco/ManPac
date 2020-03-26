using UnityEngine;
using System.Collections;

public class PacoMove : MonoBehaviour
{
    private Animator anim;
    public float speed = 0.4f;
    Vector2 dest = Vector2.zero;
    public int playerNumber = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
        dest = transform.position;
    }

    bool valid(Vector2 dir)
    {
        // Cast Line from 'next to Pac-Man' to 'Pac-Man'
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }

    void FixedUpdate()
    {
        // Move closer to Destination
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);
        // Check for Input if not moving
        if ((Vector2)transform.position == dest)
        {
            if (Input.GetAxisRaw("player"+playerNumber+"_vertical") > 0 && valid(Vector2.up))
            {
                dest = (Vector2)transform.position + Vector2.up;
                anim.SetInteger("dirY", 1);
                anim.SetInteger("dirX", 0);
            }

            if (Input.GetAxisRaw("player"+playerNumber+"_horizontal") > 0 && valid(Vector2.right))
            {
                dest = (Vector2)transform.position + Vector2.right;
                anim.SetInteger("dirY", 0);
                anim.SetInteger("dirX", 1);
            }


            if (Input.GetAxisRaw("player"+playerNumber+"_vertical") < 0 && valid(-Vector2.up))
            {
                dest = (Vector2)transform.position - Vector2.up;
                anim.SetInteger("dirY", -1);
                anim.SetInteger("dirX", 0);
            }


            if (Input.GetAxisRaw("player"+playerNumber+"_horizontal") < 0 && valid(-Vector2.right))
            {
                dest = (Vector2)transform.position - Vector2.right;
                anim.SetInteger("dirY", 0);
                anim.SetInteger("dirX", -1);
            }

        }
    }
}