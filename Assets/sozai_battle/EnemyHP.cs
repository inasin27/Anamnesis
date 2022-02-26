using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    //最大HP、半端な数にした
    int HP = 999;
    [SerializeField]
    int currentHP;
    //ダメージ引数
    public int Edamage =0;
    //最大HPの引数
    float HP2 = 0f;
    //現在HPの更新用の引数
    float currentHP2 = 0f;

    public GameObject ensystem;

    //ダメージ計算用にEnemy1_animationからダメージ数所得
    public Enemy1_animation Enemy1;


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
        //ダメージ計算用にEnemy1_animationからダメージ数所得
        //Edamage = Enemy1.E1damage;


        currentHP = currentHP - Edamage;
        currentHP2 = currentHP;

        //if(Enemy1.E1damage>=0)
        {
            //Enemy1.E1damage = 0;
        }

        ensystem.GetComponent<Image>().fillAmount = currentHP2 / HP2;
    }
}

