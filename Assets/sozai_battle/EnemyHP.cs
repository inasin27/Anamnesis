using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    //ç≈ëÂHPÅAîºí[Ç»êîÇ…ÇµÇΩ
    int HP = 99999;
    [SerializeField]
    int currentHP;
    int damage = 99;
    float HP2 = 0f;
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

