using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class HP_Damage : MonoBehaviour
{
    public Sprite[] keta;

    public GameObject HP_1;
    public GameObject HP_10;
    public GameObject HP_100;
    public GameObject HP_1000;
    public GameObject HP_10000;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            
            //currentHP -= collision.gameObject.GetComponent<Enemy1_animation>().attack;
        }
        if(HP_XXXXX.currentHP2<=0)
        {
            GetComponent<Animator>().SetTrigger("Die");
        }
    }
}
