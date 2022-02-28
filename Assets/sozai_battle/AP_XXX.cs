using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class AP_XXX : MonoBehaviour
{
    public Sprite[] keta;

    public GameObject AP_1;
    public GameObject AP_10;
    public GameObject AP_100;

    int AP = 100;
    [SerializeField]
    static public int currentAP;
    int AP2 = 0;
    static public int AP3=1;
    static public float currentAP2 = 0f;

    int skill;

    public GameObject apsystem;


    // Start is called before the first frame update
    void Start()
    {
        apsystem = GameObject.Find("AP_Full");
        currentAP = AP;
        AP2 = AP;
    }

    // Update is called once per frame
    void Update()
    {
        currentAP = currentAP + AP3;
        if (currentAP>= 100)
        {
            currentAP = 100;
            AP_100.SetActive(true);
            AP_1.GetComponent<Image>().sprite = keta[currentAP % 10];
            AP_10.GetComponent<Image>().sprite = keta[(currentAP / 10) % 10];
            AP_100.GetComponent<Image>().sprite = keta[(currentAP / 100) % 10];
        }
        else if (currentAP <= 99 && currentAP >= 10)
        {
            AP_100.SetActive(false);
            AP_10.SetActive(true);
            AP_1.GetComponent<Image>().sprite = keta[currentAP % 10];
            AP_10.GetComponent<Image>().sprite = keta[(currentAP / 10) % 10];
        }
        else if (currentAP <= 9 && currentAP>=0)
        {
            AP_100.SetActive(false);
            AP_10.SetActive(false);
            AP_1.GetComponent<Image>().sprite = keta[currentAP % 10];
        }
        else
        {
            AP_100.SetActive(false);
            AP_10.SetActive(false);
            AP_1.GetComponent<Image>().sprite = keta[0];
        }
        if (currentAP>=Chara2_animation.skill)
        {
            currentAP = currentAP - Chara2_animation.skill;
            currentAP2 = currentAP;
        }
        if(Chara2_animation.skill>=0)
        {
            Chara2_animation.skill = 0;
        }

        apsystem.GetComponent<Image>().fillAmount = (currentAP2 / AP2) * 0.25f ;
    }


    //スキルを使用した時、APバーと数値が増減するようにする
    public void APEnable()
    {
        GameObject.Find("Chara2").GetComponent<Chara2_animation>();

    }
}