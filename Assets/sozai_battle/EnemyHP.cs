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
    static public int currentHP2 = 0;

    public GameObject ensystem;
    public GameObject Enemy;
    private bool isEnd = false;
    private GameObject Text;
    public GameObject Chara;
    [SerializeField]
    public GameObject Ex;

    // Start is called before the first frame update
    void Start()
    {
        ensystem = GameObject.Find("EnemyHP");
        currentHP = HP;
        HP2 = HP;
        Enemy = GameObject.Find("Enemy1");
        this.Text = GameObject.Find("CLEARText");
    }
    // Update is called once per frame
    void Update()
    {
        Edamage = Enemy1_animation.E1damage;

        currentHP = currentHP - Edamage;
        currentHP2 = currentHP;

        if(Enemy1_animation.E1damage>=0)
        {
            Enemy1_animation.E1damage = 0;
        }
        ensystem.GetComponent<Image>().fillAmount = currentHP2 / HP2;

        if(currentHP2<=0)
        {
            Destroy(Enemy);
            isEnd = true;
            Chara.GetComponent<Chara2_animation>().enabled = false;
            Chara.GetComponent<Animator>().SetTrigger("Stand");
            Instantiate(Ex,Enemy.transform.position,Quaternion.identity);
            this.Text.GetComponent<Text>().text = "Game Clear";
        }
    }

}

