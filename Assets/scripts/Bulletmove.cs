using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletmove : MonoBehaviour
{

    public float speed = 20;
    public Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
