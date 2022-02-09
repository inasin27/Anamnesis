using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AP : MonoBehaviour
{

    GameObject image;

    void Start()
    {
        //ImageをGameObjectとして取得
        image = GameObject.Find("AP_Full");
    }

    //()の中身は引数、他のところから数値を得て{}の中で使う
    public void APFull(float current, int max)
    {
        current = 4;
        //ImageというコンポーネントのfillAmountを取得して操作する
        image.GetComponent<Image>().fillAmount = current/max;
    }
}