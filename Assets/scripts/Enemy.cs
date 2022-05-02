using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public bool mustPatrol;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
            if(health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
    void Patrol()
    {
        rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);
    }
    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        speed *= -1;
    }

    public void TakeDamage(int damage)
    {
        health-= damage;
    }



    private void OnTriggerEnter2D(Collider2D col)
    {

        //melee knockback
        if (col.tag == "eswitch")
        {
            Flip();
        }
        if (col.tag == "Death")
        {
            Destroy(this.gameObject);
        }

        if (col.tag == "Pbullet")
        {
            TakeDamage(1);
        }


    }

}
