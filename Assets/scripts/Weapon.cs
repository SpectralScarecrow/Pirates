using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    //range variables
    public float offset;
    public Transform shootpoint;
    public GameObject bullet;
    private GameObject root;

    //recoil
    [SerializeField]
    private float recoilMod;
    //ammo
    public float bulletCount;
    public float bulletCountMax;

    //melee variables
    public float t2a; //melee attack cooldown
    public float sta; //reset value for cooldown
    public Transform attackpos;
    public LayerMask targettype;
    public Vector2 meleerange;
    private int dmg =1;

    //public Linerenderer aim;

    private void Start()
    {
        root = transform.root.gameObject;
    }

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
            if(bulletCount > 0)
            {
                Shoot();
            }
        }

        //melee
        if (t2a <= 0)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                Collider2D[] enemiestodamage = Physics2D.OverlapBoxAll(attackpos.position, meleerange, targettype);
                for (int i = 0; i < enemiestodamage.Length; i++)
                {
                    enemiestodamage[i].GetComponent<Enemy>().TakeDamage(dmg);
                }
            }
        }
        /*
         *RaycastHit2D swordrange = Physics2D.Raycast(shootpoint.position, Vector2.right);
        Debug.DrawRay(shootpoint.position, Vector2.right*2, Color.green);

            */

    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackpos.position, meleerange);
    }

    private void Shoot()
    {
        //aiming
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        bulletCount--;
        Instantiate(bullet, transform.position, transform.rotation);

        if (root.GetComponent<RogerMove>().inair == true)
        {
            root.GetComponent<Rigidbody2D>().AddForce(-difference * recoilMod, ForceMode2D.Impulse);
        }
    }

    


}
