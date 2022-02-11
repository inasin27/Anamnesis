using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class HP_XXXXX : MonoBehaviour
{
    public Sprite[] keta;

    public GameObject HP_1;
    public GameObject HP_10;
    public GameObject HP_100;
    public GameObject HP_1000;
    public GameObject HP_10000;

    //ç≈ëÂHPÅAîºí[Ç»êîÇ…ÇµÇΩ
    [SerializeField]
    int life = 99999;
    //åªç›ÇÃHP
    [SerializeField]
    float currentHP;
    GameObject hpsystem;

    // Start is called before the first frame update
    void Start()
    {
        hpsystem = GameObject.Find("Number_HP");

    }
    // Update is called once per frame
    void Update()
    {
        if (life >= 99999)
        {
            HP_1.GetComponent<Image>().sprite = keta[life % 10];
            HP_10.GetComponent<Image>().sprite = keta[(life / 10) % 10];
            HP_100.GetComponent<Image>().sprite = keta[(life / 100) % 10];
            HP_1000.GetComponent<Image>().sprite = keta[(life / 1000) % 10];
            HP_10000.GetComponent<Image>().sprite = keta[(life / 10000) % 10];
        }
        else if (life <= 9999 && life >= 1000)
        {
            Destroy(HP_10000.gameObject);
            HP_1.GetComponent<Image>().sprite = keta[life % 10];
            HP_10.GetComponent<Image>().sprite = keta[(life / 10) % 10];
            HP_100.GetComponent<Image>().sprite = keta[(life / 100) % 10];
            HP_1000.GetComponent<Image>().sprite = keta[(life / 1000) % 10];
        }
        else if (life <= 999 && life >= 100)
        {
            Destroy(HP_10000.gameObject);
            Destroy(HP_1000.gameObject);
            HP_1.GetComponent<Image>().sprite = keta[life % 10];
            HP_10.GetComponent<Image>().sprite = keta[(life / 10) % 10];
            HP_100.GetComponent<Image>().sprite = keta[(life / 100) % 10];
        }
        else if (life <= 99 && life >= 10)
        {
            Destroy(HP_10000.gameObject);
            Destroy(HP_1000.gameObject);
            Destroy(HP_100.gameObject);
            HP_1.GetComponent<Image>().sprite = keta[life % 10];
            HP_10.GetComponent<Image>().sprite = keta[(life / 10) % 10];
        }
        else if (life <= 9)
        {
            Destroy(HP_10000.gameObject);
            Destroy(HP_1000.gameObject);
            Destroy(HP_100.gameObject);
            Destroy(HP_10.gameObject);
            HP_1.GetComponent<Image>().sprite = keta[life % 10];
        }
        else
        {
            Destroy(HP_10000.gameObject);
            Destroy(HP_1000.gameObject);
            Destroy(HP_100.gameObject);
            Destroy(HP_10.gameObject);
            HP_1.GetComponent<Image>().sprite = keta[life % 0];
        }
        hpsystem.GetComponent<Number_HP>().HPDown(currentHP, life);
    }

    void FixedUpdate()
    {
        //currentHPÇ™0à»è„Ç»ÇÁTrue
        if (0 <= currentHP)
        {
            //maxHPÇ©ÇÁïbêîÅiÅ~10ÅjÇà¯Ç¢ÇΩêîÇ™currentHP
            currentHP =life - Time.time * 10;
        }
    }

}