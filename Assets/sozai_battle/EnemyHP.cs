using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    //�ő�HP�A���[�Ȑ��ɂ���
    int HP = 999;
    [SerializeField]
    int currentHP;
    //�_���[�W����
    public int Edamage =0;
    //�ő�HP�̈���
    float HP2 = 0f;
    //����HP�̍X�V�p�̈���
    static public int currentHP2 = 0;

    public GameObject ensystem;
    public GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        ensystem = GameObject.Find("EnemyHP");
        currentHP = HP;
        HP2 = HP;
        Enemy = GameObject.Find("Enemy1");

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
        }
    }

}

