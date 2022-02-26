using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class EHP_Damage : MonoBehaviour
{
    //insectorÇ≈åÖê›íËÇ≈Ç´ÇÈÅBâÊëúÇì¸ÇÍÇÈÇ∆ï\é¶Ç≥ÇÍÇÈ
    public Sprite[] keta;
    public GameObject EHP_D1;
    public GameObject EHP_D10;
    public GameObject EHP_D100;
    public GameObject EHP_D1000;
    public GameObject EHP_D10000;

    private float time;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (EnemyHP.currentHP2 <= 99999 && EnemyHP.currentHP2 >= 10000)
        {
            EHP_D1.GetComponent<Image>().sprite = keta[EnemyHP.currentHP2 % 10];
            EHP_D10.GetComponent<Image>().sprite = keta[(EnemyHP.currentHP2 / 10) % 10];
            EHP_D100.GetComponent<Image>().sprite = keta[(EnemyHP.currentHP2 / 100) % 10];
            EHP_D1000.GetComponent<Image>().sprite = keta[(EnemyHP.currentHP2 / 1000) % 10];
            EHP_D10000.GetComponent<Image>().sprite = keta[(EnemyHP.currentHP2 / 10000) % 10];
            time = Time.time;
            if (Time.time >= 1)
            {
                Destroy(EHP_D10000.gameObject);
                Destroy(EHP_D1000.gameObject);
                Destroy(EHP_D100.gameObject);
                Destroy(EHP_D10.gameObject);
                Destroy(EHP_D1.gameObject);
            }
        }
        else if (EnemyHP.currentHP2 <= 9999 && EnemyHP.currentHP2 >= 1000)
        {
            EHP_D1.GetComponent<Image>().sprite = keta[EnemyHP.currentHP2 % 10];
            EHP_D10.GetComponent<Image>().sprite = keta[(EnemyHP.currentHP2 / 10) % 10];
            EHP_D100.GetComponent<Image>().sprite = keta[(EnemyHP.currentHP2 / 100) % 10];
            EHP_D1000.GetComponent<Image>().sprite = keta[(EnemyHP.currentHP2 / 1000) % 10];
            time = Time.time;
            if (Time.time >= 1)
            {
                Destroy(EHP_D10000.gameObject);
                Destroy(EHP_D1000.gameObject);
                Destroy(EHP_D100.gameObject);
                Destroy(EHP_D10.gameObject);
                Destroy(EHP_D1.gameObject);
            }
        }
        else if (EnemyHP.currentHP2 <= 999 && EnemyHP.currentHP2 >= 100)
        {
            EHP_D1.GetComponent<Image>().sprite = keta[EnemyHP.currentHP2 % 10];
            EHP_D10.GetComponent<Image>().sprite = keta[(EnemyHP.currentHP2 / 10) % 10];
            EHP_D100.GetComponent<Image>().sprite = keta[(EnemyHP.currentHP2 / 100) % 10];
            time = Time.time;
            if (Time.time >= 1)
            {
                Destroy(EHP_D10000.gameObject);
                Destroy(EHP_D1000.gameObject);
                Destroy(EHP_D100.gameObject);
                Destroy(EHP_D10.gameObject);
                Destroy(EHP_D1.gameObject);
            }
        }
        else if (EnemyHP.currentHP2 <= 99 && EnemyHP.currentHP2 >= 10)
        {
            EHP_D1.GetComponent<Image>().sprite = keta[EnemyHP.currentHP2 % 10];
            EHP_D10.GetComponent<Image>().sprite = keta[(EnemyHP.currentHP2 / 10) % 10];
            time = Time.time;
            if (Time.time >= 1)
            {
                Destroy(EHP_D10000.gameObject);
                Destroy(EHP_D1000.gameObject);
                Destroy(EHP_D100.gameObject);
                Destroy(EHP_D10.gameObject);
                Destroy(EHP_D1.gameObject);
            }
        }
        else if (EnemyHP.currentHP2 <= 9 && EnemyHP.currentHP2 >= 0)
        {
            EHP_D1.GetComponent<Image>().sprite = keta[EnemyHP.currentHP2 % 10];
            time = Time.time;
            if (Time.time >= 1)
            {
                Destroy(EHP_D10000.gameObject);
                Destroy(EHP_D1000.gameObject);
                Destroy(EHP_D100.gameObject);
                Destroy(EHP_D10.gameObject);
                Destroy(EHP_D1.gameObject);
            }
        }
        else
        {
            EHP_D1.GetComponent<Image>().sprite = keta[0];
            time = Time.time;
            if (Time.time >= 1)
            {
                Destroy(EHP_D10000.gameObject);
                Destroy(EHP_D1000.gameObject);
                Destroy(EHP_D100.gameObject);
                Destroy(EHP_D10.gameObject);
                Destroy(EHP_D1.gameObject);
            }
        }
    }
}

