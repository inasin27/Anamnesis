using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    //最大HP、半端な数にした
    int HP = 99999;
    [SerializeField]
    int currentHP;
    //ダメージ引数
    int damage = 99;
    //最大HPの引数
    float HP2 = 0f;
    //現在HPの更新用の引数
    float currentHP2 = 0f;

    public GameObject ensystem;


    // Start is called before the first frame update
    void Start()
    {
        ensystem = GameObject.Find("EnemyHP");
        currentHP = HP;
        HP2 = HP;
    }
    // Update is called once per frame
    void Update()
    {

        currentHP = currentHP - damage;
        currentHP2 = currentHP;

        ensystem.GetComponent<Image>().fillAmount = currentHP2 / HP2;
    }
}

