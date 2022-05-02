using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //action time variables
    public float orgtime;
    public float standardtime;
    public float variabletime;
    public bool mixup;
    //prefabs
    public GameObject bossbullet;
    public Transform bossrange;
    //damage variables
    public int bstr;
    public int bhp;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   /*private int Randomizer(int max)
    {
        int rannum = Randomizer.Range(1, max + 1);
    }

    //randomly decide on a courseof action.
    void Chooser()
    {
        /*actions are: 
         *Jump back
         shootgun
         swing sword
         dash forward
        int choice = Randomizer(4);



    }
*/

}
