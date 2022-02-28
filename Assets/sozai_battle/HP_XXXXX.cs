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
    int life = 99;
    [SerializeField]
    int currentHP;
    int damage = 0;
    float life2 = 0f;
    static public float currentHP2 = 0f;

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
            HP_10000.SetActive(true);
            HP_1.GetComponent<Image>().sprite = keta[currentHP % 10];
            HP_10.GetComponent<Image>().sprite = keta[(currentHP / 10) % 10];
            HP_100.GetComponent<Image>().sprite = keta[(currentHP / 100) % 10];
            HP_1000.GetComponent<Image>().sprite = keta[(currentHP / 1000) % 10];
            HP_10000.GetComponent<Image>().sprite = keta[(currentHP / 10000) % 10];
        }
        else if (currentHP <= 9999 && currentHP >= 1000)
        {
            HP_10000.SetActive(false);
            HP_1000.SetActive(true);
            HP_100.SetActive(true);
            HP_10.SetActive(true);
            HP_1.GetComponent<Image>().sprite = keta[currentHP % 10];
            HP_10.GetComponent<Image>().sprite = keta[(currentHP / 10) % 10];
            HP_100.GetComponent<Image>().sprite = keta[(currentHP / 100) % 10];
            HP_1000.GetComponent<Image>().sprite = keta[(currentHP/ 1000) % 10];
        }
        else if (currentHP <= 999 && currentHP >= 100)
        {
            HP_10000.SetActive(false);
            HP_1000.SetActive(false);
            HP_100.SetActive(true);
            HP_10.SetActive(true);
            HP_1.GetComponent<Image>().sprite = keta[currentHP % 10];
            HP_10.GetComponent<Image>().sprite = keta[(currentHP / 10) % 10];
            HP_100.GetComponent<Image>().sprite = keta[(currentHP / 100) % 10];
        }
        else if (currentHP<= 99 && currentHP >= 10)
        {
            HP_10000.SetActive(false);
            HP_1000.SetActive(false);
            HP_100.SetActive(false);
            HP_10.SetActive(true);
            HP_1.GetComponent<Image>().sprite = keta[currentHP % 10];
            HP_10.GetComponent<Image>().sprite = keta[(currentHP / 10) % 10];
        }
        else if (currentHP <= 9 && currentHP>=0)
        {
            HP_10000.SetActive(false);
            HP_1000.SetActive(false);
            HP_100.SetActive(false);
            HP_10.SetActive(false);
            HP_1.GetComponent<Image>().sprite = keta[currentHP % 10];
        }
        else
        {
            HP_10000.SetActive(false);
            HP_1000.SetActive(false);
            HP_100.SetActive(false);
            HP_10.SetActive(false);
            HP_1.GetComponent<Image>().sprite = keta[0];
        }
        currentHP = currentHP - damage;
        currentHP2 = currentHP;

        hpsystem.GetComponent<Image>().fillAmount = currentHP2 / life2;

    }
}

