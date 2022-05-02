using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogerMove : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb;
    public float jforce;
    public float kbmod;
    public Camera cam;
    Vector2 mousepos;
    Vector2 movement;
    public bool inair = false;

    // Update is called once per frame
    void Update()
    {
        //move input
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //mouse input
       // mousepos = cam.ScreenToWorldPoint(Input.mousePosition);

        transform.position += new Vector3(h, 0, 0) * Time.deltaTime * speed;
      
        
        //jump
        if (Input.GetButtonDown("Jump") && inair == false)
        {
            rb.AddForce(new Vector2(0, jforce), ForceMode2D.Impulse);
        }







    }


    private void FixedUpdate()
    {
       /* rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        Vector2 lookDir = mousepos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg ;
        rb.rotation = angle;*/
    }




    

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        //melee knockback
        if(col.tag == "surface")
        {
             
            
            Vector2 difference = transform.position - col.transform.position;
            rb.AddForce(new Vector2(transform.position.x + difference.x * kbmod, transform.position.y +difference.y*kbmod), ForceMode2D.Force);   
            //transform.position = new Vector2(transform.position.x + difference.x * kbmod,0);
            
        }

        if (col.tag == "Death")
        {
            Destroy(this.gameObject);
        }

        if (col.tag == "enemy")
        {
            Destroy(this.gameObject);
        }

    }

    //check if we are on ground or not

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ground is layer 3
        if(collision.gameObject.layer == 3)
        {
            inair = false;
        }

        

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //ground is layer 3
        if (collision.gameObject.layer == 3)
        {
            inair = true;
        }
    }
}