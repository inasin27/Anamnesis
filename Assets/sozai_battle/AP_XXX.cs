using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class AP_XXX : MonoBehaviour
{
    public Sprite[] keta;

    public GameObject AP_1;
    public GameObject AP_10;
    public GameObject AP_100;

    int AP = 100;
    [SerializeField]
    int currentAP;
    int waste=1;
    float AP2 = 0f;
    float currentAP2 = 0f;

    public GameObject apsystem;


    // Start is called before the first frame update
    void Start()
    {
        apsystem = GameObject.Find("AP_Full");
        currentAP = AP;
        AP2 = AP;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAP >= 100)
        {
            AP_1.GetComponent<Image>().sprite = keta[currentAP % 10];
            AP_10.GetComponent<Image>().sprite = keta[(currentAP / 10) % 10];
            AP_100.GetComponent<Image>().sprite = keta[(currentAP / 100) % 10];
        }
        else if (currentAP <= 99 && currentAP >= 10)
        {
            Destroy(AP_100.gameObject);
            AP_1.GetComponent<Image>().sprite = keta[currentAP % 10];
            AP_10.GetComponent<Image>().sprite = keta[(currentAP / 10) % 10];
        }
        else if (currentAP <= 9 && currentAP>=0)
        {
            Destroy(AP_100.gameObject);
            Destroy(AP_10.gameObject);
            AP_1.GetComponent<Image>().sprite = keta[currentAP % 10];
        }
        else
        {
            Destroy(AP_100.gameObject);
            Destroy(AP_10.gameObject);
            AP_1.GetComponent<Image>().sprite = keta[0];
        }
        currentAP = currentAP - waste;
        currentAP2 = currentAP;

        apsystem.GetComponent<Image>().fillAmount = (currentAP2 / AP2) * 0.25f ;
    }
}