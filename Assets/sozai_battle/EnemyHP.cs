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
    float currentHP2 = 0f;

    public GameObject ensystem;

    //�_���[�W�v�Z�p��Enemy1_animation����_���[�W������
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
        //�_���[�W�v�Z�p��Enemy1_animation����_���[�W������
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

