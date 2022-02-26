using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class HP_XXXXX : MonoBehaviour
{
    //insectorで桁設定できる。画像を入れると表示される
    public Sprite[] keta;
    public GameObject HP_1;
    public GameObject HP_10;
    public GameObject HP_100;
    public GameObject HP_1000;
    public GameObject HP_10000;

    //最大HP、半端な数にした
    int life = 999;
    [SerializeField]
    int currentHP;
    int damage=0;
    float life2 = 0f;
    float currentHP2 = 0f;

    public GameObject hpsystem;

    // Start is called before the first frame update
    void Start()
    {
        hpsystem = GameObject.Find("HP");
        currentHP = life;
        life2 = life;
    }
    // Update is called once per frame
    void Update()
    {
        if (currentHP <= 99999 && currentHP>=10000)
        {
            HP_1.GetComponent<Image>().sprite = keta[currentHP % 10];
            HP_10.GetComponent<Image>().sprite = keta[(currentHP / 10) % 10];
            HP_100.GetComponent<Image>().sprite = keta[(currentHP / 100) % 10];
            HP_1000.GetComponent<Image>().sprite = keta[(currentHP / 1000) % 10];
            HP_10000.GetComponent<Image>().sprite = keta[(currentHP / 10000) % 10];
        }
        else if (currentHP <= 9999 && currentHP >= 1000)
        {
            Destroy(HP_10000.gameObject);
            HP_1.GetComponent<Image>().sprite = keta[currentHP % 10];
            HP_10.GetComponent<Image>().sprite = keta[(currentHP / 10) % 10];
            HP_100.GetComponent<Image>().sprite = keta[(currentHP / 100) % 10];
            HP_1000.GetComponent<Image>().sprite = keta[(currentHP/ 1000) % 10];
        }
        else if (currentHP <= 999 && currentHP >= 100)
        {
            Destroy(HP_10000.gameObject);
            Destroy(HP_1000.gameObject);
            HP_1.GetComponent<Image>().sprite = keta[currentHP % 10];
            HP_10.GetComponent<Image>().sprite = keta[(currentHP / 10) % 10];
            HP_100.GetComponent<Image>().sprite = keta[(currentHP / 100) % 10];
        }
        else if (currentHP<= 99 && currentHP >= 10)
        {
            Destroy(HP_10000.gameObject);
            Destroy(HP_1000.gameObject);
            Destroy(HP_100.gameObject);
            HP_1.GetComponent<Image>().sprite = keta[currentHP % 10];
            HP_10.GetComponent<Image>().sprite = keta[(currentHP / 10) % 10];
        }
        else if (currentHP <= 9 && currentHP>=0)
        {
            Destroy(HP_10000.gameObject);
            Destroy(HP_1000.gameObject);
            Destroy(HP_100.gameObject);
            Destroy(HP_10.gameObject);
            HP_1.GetComponent<Image>().sprite = keta[currentHP % 10];
        }
        else
        {
            Destroy(HP_10000.gameObject);
            Destroy(HP_1000.gameObject);
            Destroy(HP_100.gameObject);
            Destroy(HP_10.gameObject);
            HP_1.GetComponent<Image>().sprite = keta[0];
        }
        currentHP = currentHP - damage;
        currentHP2 = currentHP;

        hpsystem.GetComponent<Image>().fillAmount = currentHP2 / life2;
    }
}

