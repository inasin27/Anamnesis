using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara2_animation : MonoBehaviour
{
    //アニメーションをコンポーネント所得
    private Rigidbody myRigidbody;
    private float Rotate = 0f;
    private float velocityZ = 10f;
    private float velocityX = 10f;
    private float velocityY = 10f;
    Vector3 Chara;
    public GameObject Moon;
    private Rigidbody rb;


    // Use this for initialization
    void Start()
    {
        //アニメータコンポーネント所得
        this.myRigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        var rb = GetComponent<Rigidbody>();
        // 矢印上を押した時
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            Chara = gameObject.transform.eulerAngles;
            Chara.y = 0;
            gameObject.transform.eulerAngles = Chara;

            // 前に走る
            GetComponent<Animator>().SetTrigger("Run");
            //実際に動く
            this.myRigidbody.velocity = new Vector3(0, 0, this.velocityZ);
        }
        //矢印下を押した時
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            Chara = gameObject.transform.eulerAngles;
            Chara.y = 180;
            gameObject.transform.eulerAngles = Chara;

            // 前に走る
            GetComponent<Animator>().SetTrigger("Run");
            //実際に動く
            this.myRigidbody.velocity = new Vector3(0, 0, -this.velocityZ);
        }

        // 矢印左を押した時
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            Chara = gameObject.transform.eulerAngles;
            Chara.y = 270;
            gameObject.transform.eulerAngles = Chara;

            // 前に走る
            GetComponent<Animator>().SetTrigger("Run");
            //実際に動く
            this.myRigidbody.velocity = new Vector3(-velocityX, 0, 0);
        }
        // 矢印右を押した時
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            Chara = gameObject.transform.eulerAngles;
            Chara.y = 90;
            gameObject.transform.eulerAngles = Chara;

            // 前に走る
            GetComponent<Animator>().SetTrigger("Run");
            //実際に動く
            this.myRigidbody.velocity = new Vector3(velocityX, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //Aを押したら攻撃
            GetComponent<Animator>().SetTrigger("Attack");
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //Sを押したら攻撃
            GetComponent<Animator>().SetTrigger("Attack1-2");
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }
        else if(Input.GetKey(KeyCode.Z))
        {
            //Zを押したらスキル１を発動する
            GetComponent<Animator>().SetTrigger("Skill");
            Instantiate(Moon, new Vector3(0f, 0f, 0f),Quaternion.identity);
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            GetComponent<Animator>().SetTrigger("Stand");
            this.myRigidbody.velocity = new Vector3(0, 0, 0);
        }
        
    }
}
