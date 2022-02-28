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
    public GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = GameObject.Find("Enemy1");
        EHP_D10000.SetActive(false);
        EHP_D1000.SetActive(false);
        EHP_D100.SetActive(false);
        EHP_D10.SetActive(false);
        EHP_D1.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        EHP_D10000.transform.position = Enemy.transform.position + new Vector3(2, 2, 0);
        EHP_D1000.transform.position = Enemy.transform.position + new Vector3(1, 2, 0);
        EHP_D100.transform.position = Enemy.transform.position + new Vector3(0,2, 0);
        EHP_D10.transform.position = Enemy.transform.position + new Vector3(-1, 2, 0);
        EHP_D1.transform.position = Enemy.transform.position + new Vector3(-2, 2, 0);

        if (Enemy1_animation.E1damage <= 99999 && Enemy1_animation.E1damage >= 10000)
        {
            EHP_D10000.SetActive(true);
            EHP_D1000.SetActive(true);
            EHP_D100.SetActive(true);
            EHP_D10.SetActive(true);
            EHP_D1.SetActive(true);
            EHP_D1.GetComponent<Image>().sprite = keta[EnemyHP.currentHP2 % 10];
            EHP_D10.GetComponent<Image>().sprite = keta[(EnemyHP.currentHP2 / 10) % 10];
            EHP_D100.GetComponent<Image>().sprite = keta[(EnemyHP.currentHP2 / 100) % 10];
            EHP_D1000.GetComponent<Image>().sprite = keta[(EnemyHP.currentHP2 / 1000) % 10];
            EHP_D10000.GetComponent<Image>().sprite = keta[(EnemyHP.currentHP2 / 10000) % 10];
            time += 1;
            if (time>= 10)
            {
                EHP_D10000.SetActive(false);
                EHP_D1000.SetActive(false);
                EHP_D100.SetActive(false);
                EHP_D10.SetActive(false);
                EHP_D1.SetActive(false);
            }
        }
        else if (Enemy1_animation.E1damage <= 9999 && Enemy1_animation.E1damage >= 1000)
        {
            EHP_D1000.SetActive(true);
            EHP_D100.SetActive(true);
            EHP_D10.SetActive(true);
            EHP_D1.SetActive(true);
            EHP_D1.GetComponent<Image>().sprite = keta[EnemyHP.currentHP2 % 10];
            EHP_D10.GetComponent<Image>().sprite = keta[(EnemyHP.currentHP2 / 10) % 10];
            EHP_D100.GetComponent<Image>().sprite = keta[(EnemyHP.currentHP2 / 100) % 10];
            EHP_D1000.GetComponent<Image>().sprite = keta[(EnemyHP.currentHP2 / 1000) % 10];
            time += 1;
            if (time >= 10)
            {
                EHP_D1000.SetActive(false);
                EHP_D100.SetActive(false);
                EHP_D10.SetActive(false);
                EHP_D1.SetActive(false);
            }
        }
        else if (Enemy1_animation.E1damage <= 999 && Enemy1_animation.E1damage >= 100)
        {
            EHP_D100.SetActive(true);
            EHP_D10.SetActive(true);
            EHP_D1.SetActive(true);
            EHP_D1.GetComponent<Image>().sprite = keta[EnemyHP.currentHP2 % 10];
            EHP_D10.GetComponent<Image>().sprite = keta[(EnemyHP.currentHP2 / 10) % 10];
            EHP_D100.GetComponent<Image>().sprite = keta[(EnemyHP.currentHP2 / 100) % 10];
            time += 1;
            if (time >= 10)
            {
                EHP_D100.SetActive(false);
                EHP_D10.SetActive(false);
                EHP_D1.SetActive(false);
            }
        }
        else if (Enemy1_animation.E1damage <= 99 && Enemy1_animation.E1damage >= 10)
        {
            EHP_D10.SetActive(true);
            EHP_D1.SetActive(true);
            EHP_D1.GetComponent<Image>().sprite = keta[EnemyHP.currentHP2 % 10];
            EHP_D10.GetComponent<Image>().sprite = keta[(EnemyHP.currentHP2 / 10) % 10];
            time +=1;
            if (time >= 10)
            {
                EHP_D10.SetActive(false);
                EHP_D1.SetActive(false);
            }
        }
        else if (Enemy1_animation.E1damage <= 9 && Enemy1_animation.E1damage >= 1)
        {
            EHP_D1.SetActive(true);
            EHP_D1.GetComponent<Image>().sprite = keta[EnemyHP.currentHP2 % 10];
            time += 1; 
            if (time >= 10)
            {
                EHP_D1.SetActive(false);
            }
        }
    }
}

