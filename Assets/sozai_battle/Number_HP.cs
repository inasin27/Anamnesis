using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Number_HP : MonoBehaviour
{
    GameObject image;

    void Start()
    {
        //Image��GameObject�Ƃ��Ď擾
        image = GameObject.Find("HP");
    }

    //()�̒��g�͈����A���̂Ƃ��납�琔�l�𓾂�{}�̒��Ŏg��
    public void HPDown(float current, int max)
    {
        //Image�Ƃ����R���|�[�l���g��fillAmount���擾���đ��삷��
        image.GetComponent<Image>().fillAmount = current / max;
    }
}
