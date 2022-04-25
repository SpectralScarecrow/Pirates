using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public float offset;
    public Transform shootpoint;
    public GameObject bullet;
    //public Linerenderer aim;


    // Update is called once per frame
    void Update()
    {
        //aiming
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz + offset);
        
        //shooting
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        //melee
        RaycastHit2D swordrange = Physics2D.Raycast(shootpoint.position, Vector2.right);
        Debug.DrawRay(shootpoint.position, Vector2.right, Color.green);

        /*
         *
            */

    }


    private void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }


}
