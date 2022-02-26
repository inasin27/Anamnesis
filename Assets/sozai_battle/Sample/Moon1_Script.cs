using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon1_Script : MonoBehaviour
{
    public GameObject Enemy;
    float speed=0.5f;

    // Start is called before the first frame update
    void Start()
    {
        Enemy=GameObject.Find("Enemy1");    
    }

    // Update is called once per frame
    void Update()
    {
        //Œü‚¢‚Ä‚¢‚é•ûŒü‚ÖˆÚ“®
        //this.GetComponent<Rigidbody>().AddForce(this.transform.forward * 1f, ForceMode.Force);
        this.transform.position = Vector3.MoveTowards(transform.position, Enemy.transform.position, speed);
    }
}
