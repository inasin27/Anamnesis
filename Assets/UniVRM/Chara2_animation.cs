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
    //Vector3 Chara;
    public GameObject MoonPrefab;
    //public GameObject Chara2;
    public GameObject Enemy;
    private Rigidbody rb;

    //����ap�̈���
    int skill1 = 0;


    // Use this for initialization
    void Start()
    {
        //�A�j���[�^�R���|�[�l���g����
        this.myRigidbody = GetComponent<Rigidbody>();
        
        //�擾
        //Chara2 = GameObject.Find( "Chara2");
        Enemy = GameObject.Find("Enemy1");
    }

    // Update is called once per frame
    void Update()
    {
        var rb = GetComponent<Rigidbody>();
        // �������������
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            //Chara = gameObject.transform.eulerAngles;
            //Chara.y = 0;
            //gameObject.transform.eulerAngles = Chara;
            this.transform.Rotate(new Vector3(0.0f, Mathf.DeltaAngle(transform.eulerAngles.y, 0f), 0.0f));

            // �O�ɑ���
            GetComponent<Animator>().SetTrigger("Run");
            //���ۂɓ���
            this.myRigidbody.velocity = new Vector3(0, 0, this.velocityZ);
        }
        //��󉺂���������
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            //Chara = gameObject.transform.eulerAngles;
            //Chara.y = 180;
            //gameObject.transform.eulerAngles = Chara;
            this.transform.Rotate(new Vector3(0.0f, Mathf.DeltaAngle(transform.eulerAngles.y, 180f), 0.0f));

            // �O�ɑ���
            GetComponent<Animator>().SetTrigger("Run");
            //���ۂɓ���
            this.myRigidbody.velocity = new Vector3(0, 0, -this.velocityZ);
        }

        // ��󍶂���������
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            //Chara = gameObject.transform.eulerAngles;
            //Chara.y = 270;
            //gameObject.transform.eulerAngles = Chara;
            this.transform.Rotate(new Vector3(0.0f, Mathf.DeltaAngle(transform.eulerAngles.y, 270f), 0.0f));

            // �O�ɑ���
            GetComponent<Animator>().SetTrigger("Run");
            //���ۂɓ���
            this.myRigidbody.velocity = new Vector3(-velocityX, 0, 0);
        }
        // ���E����������
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            //Chara = gameObject.transform.eulerAngles;
            //Chara.y = 90;
            //gameObject.transform.eulerAngles = Chara;
            this.transform.Rotate(new Vector3(0.0f, Mathf.DeltaAngle(transform.eulerAngles.y, 90f), 0.0f));

            // �O�ɑ���
            GetComponent<Animator>().SetTrigger("Run");
            //���ۂɓ���
            this.myRigidbody.velocity = new Vector3(velocityX, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            //A����������U��
            GetComponent<Animator>().SetTrigger("Attack");
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            //S����������U��
            GetComponent<Animator>().SetTrigger("Attack1-2");
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            //Z����������X�L���P�𔭓�����
            GetComponent<Animator>().SetTrigger("Skill");
            GameObject Moon = Instantiate(MoonPrefab);
            Moon.transform.position = this.transform.position + new Vector3(0f, 0f, 0f);
            Moon.transform.LookAt(Enemy.transform);
            this.transform.LookAt(Enemy.transform);
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            skill1 = 15;
        }
        else
        {
            GetComponent<Animator>().SetTrigger("Stand");
            this.myRigidbody.velocity = new Vector3(0, 0, 0);
        }

    }
    //�I�u�W�F�N�g�ƏՓ˂������A�I�u�W�F�N�g����������
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //��ő���L�����N�^�[���I�u�W�F�N�g�Ɠ����������̌v�Z�p
            Debug.Log("�G�ƏՓ˂���");
        }
    }


}