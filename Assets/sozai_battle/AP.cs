using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AP : MonoBehaviour
{

    GameObject image;

    void Start()
    {
        //Image��GameObject�Ƃ��Ď擾
        image = GameObject.Find("AP_Full");
    }

    //()�̒��g�͈����A���̂Ƃ��납�琔�l�𓾂�{}�̒��Ŏg��
    public void APFull(float current, int max)
    {
        current = 4;
        //Image�Ƃ����R���|�[�l���g��fillAmount���擾���đ��삷��
        image.GetComponent<Image>().fillAmount = current/max;
    }
}