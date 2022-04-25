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
    // Start is called before the first frame update
    void Start()
    {

    }

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
        if (Input.GetButtonDown("Jump"))
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
        
        //bullet knockback
        if (col.tag=="PBullet")
        {
            Vector2 difference = transform.position - col.transform.position;
            transform.position = new Vector2(transform.position.x + difference.x* kbmod, transform.position.y + difference.y);
        }
        //melee knockback
        if(col.tag == "surface")
        {
             
            
            Vector2 difference = transform.position - col.transform.position;
            rb.AddForce(new Vector2(transform.position.x + difference.x * kbmod, transform.position.y +difference.y*kbmod), ForceMode2D.Force);   
            //transform.position = new Vector2(transform.position.x + difference.x * kbmod,0);
            
            
        }
    }



}