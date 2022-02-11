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

    // Start is called before the first frame update
    void Start()
    {
        int life =100;

        if (life >= 100)
        {
            AP_1.GetComponent<Image>().sprite = keta[life % 10];
            AP_10.GetComponent<Image>().sprite = keta[(life / 10) % 10];
            AP_100.GetComponent<Image>().sprite = keta[(life / 100) % 10];
        }
        else if (life <= 99 && life>=10)
        {
            Destroy(AP_100.gameObject);
            AP_1.GetComponent<Image>().sprite = keta[life % 10];
            AP_10.GetComponent<Image>().sprite = keta[(life / 10) % 10];
        }
        else if (life <= 9)
        {
            Destroy(AP_100.gameObject);
            Destroy(AP_10.gameObject);
            AP_1.GetComponent<Image>().sprite = keta[life % 10];
        }
        else
        {
            Destroy(AP_100.gameObject);
            Destroy(AP_10.gameObject);
            AP_1.GetComponent<Image>().sprite = keta[life % 0];
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}