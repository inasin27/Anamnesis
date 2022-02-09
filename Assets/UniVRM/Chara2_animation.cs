using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara2_animation : MonoBehaviour
{
    //�A�j���[�V�������R���|�[�l���g����
    private Rigidbody myRigidbody;
    private float Rotate = 0f;
    private float velocityZ = 10f;
    private float velocityX = 10f;
    private float velocityY = 10f;
    Vector3 Chara;

    // Use this for initialization
    void Start()
    {
        //�A�j���[�^�R���|�[�l���g����
        this.myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // �������������
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Chara = gameObject.transform.eulerAngles;
            Chara.y = 0;
            gameObject.transform.eulerAngles = Chara;

            // �O�ɑ���
            GetComponent<Animator>().SetTrigger("Run");
            //���ۂɓ���
            this.myRigidbody.velocity = new Vector3(0, 0, this.velocityZ);
        }
        //��󉺂���������
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Chara = gameObject.transform.eulerAngles;
            Chara.y = 180;
            gameObject.transform.eulerAngles = Chara;

            // �O�ɑ���
            GetComponent<Animator>().SetTrigger("Run");
            //���ۂɓ���
            this.myRigidbody.velocity = new Vector3(0, 0, -this.velocityZ);
        }

        // ��󍶂���������
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Chara = gameObject.transform.eulerAngles;
            Chara.y = 270;
            gameObject.transform.eulerAngles = Chara;

            // �O�ɑ���
            GetComponent<Animator>().SetTrigger("Run");
            //���ۂɓ���
            this.myRigidbody.velocity = new Vector3(-velocityX, 0, 0);
        }
        // ���E����������
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Chara = gameObject.transform.eulerAngles;
            Chara.y = 90;
            gameObject.transform.eulerAngles = Chara;

            // �O�ɑ���
            GetComponent<Animator>().SetTrigger("Run");
            //���ۂɓ���
            this.myRigidbody.velocity = new Vector3(velocityX, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //A����������U��
            GetComponent<Animator>().SetTrigger("Attack");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //D����������U��
            GetComponent<Animator>().SetTrigger("Attack1-2");
        }
        else
        {
            GetComponent<Animator>().SetTrigger("Stand");
            this.myRigidbody.velocity = new Vector3(0, 0, 0);
        }
    }
}
