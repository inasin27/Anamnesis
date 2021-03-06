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
    //Vector3 Chara;
    public GameObject MoonPrefab;
    //public GameObject Chara2;
    public GameObject Enemy;
    private Rigidbody rb;

    //攻撃用のエフェクト達宣言
    public GameObject Skill1;
    public GameObject Skill2;
    public GameObject Skill3;
    
    //消費apの引数
    static public int skill = 0;
    bool time;
    float times;
    float timee;

    // Use this for initialization
    void Start()
    {
        //アニメータコンポーネント所得
        this.myRigidbody = GetComponent<Rigidbody>();
        
        //取得
        //Chara2 = GameObject.Find( "Chara2");
        Enemy = GameObject.Find("Enemy1");
    }

    // Update is called once per frame
    void Update()
    {
        var rb = GetComponent<Rigidbody>();
        // 矢印上を押した時
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            //Chara = gameObject.transform.eulerAngles;
            //Chara.y = 0;
            //gameObject.transform.eulerAngles = Chara;
            this.transform.Rotate(new Vector3(0.0f, Mathf.DeltaAngle(transform.eulerAngles.y, 0f), 0.0f));

            // 前に走る
            GetComponent<Animator>().SetTrigger("Run");
            //実際に動く
            this.myRigidbody.velocity = new Vector3(0, 0, this.velocityZ);
        }
        //矢印下を押した時
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            //Chara = gameObject.transform.eulerAngles;
            //Chara.y = 180;
            //gameObject.transform.eulerAngles = Chara;
            this.transform.Rotate(new Vector3(0.0f, Mathf.DeltaAngle(transform.eulerAngles.y, 180f), 0.0f));

            // 前に走る
            GetComponent<Animator>().SetTrigger("Run");
            //実際に動く
            this.myRigidbody.velocity = new Vector3(0, 0, -this.velocityZ);
        }

        // 矢印左を押した時
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            //Chara = gameObject.transform.eulerAngles;
            //Chara.y = 270;
            //gameObject.transform.eulerAngles = Chara;
            this.transform.Rotate(new Vector3(0.0f, Mathf.DeltaAngle(transform.eulerAngles.y, 270f), 0.0f));

            // 前に走る
            GetComponent<Animator>().SetTrigger("Run");
            //実際に動く
            this.myRigidbody.velocity = new Vector3(-velocityX, 0, 0);
        }
        // 矢印右を押した時
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            //Chara = gameObject.transform.eulerAngles;
            //Chara.y = 90;
            //gameObject.transform.eulerAngles = Chara;
            this.transform.Rotate(new Vector3(0.0f, Mathf.DeltaAngle(transform.eulerAngles.y, 90f), 0.0f));

            // 前に走る
            GetComponent<Animator>().SetTrigger("Run");
            //実際に動く
            this.myRigidbody.velocity = new Vector3(velocityX, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            //Aを押したら攻撃
            if (AP_XXX.currentAP2 >= 2)
            {
                GetComponent<Animator>().SetTrigger("Attack");
                Instantiate(Skill1, this.transform.position, Quaternion.identity);
                Skill1.transform.position = this.transform.position + new Vector3(0f, 0f, 0f);
                Skill1.transform.LookAt(Enemy.transform);
                this.transform.LookAt(Enemy.transform);
                rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
                skill = 2;
                AP_XXX.AP3 = 0;
                time = !time;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            //Sを押したら攻撃
            GetComponent<Animator>().SetTrigger("Attack1-2");
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            Instantiate(Skill2, this.transform.position, Quaternion.identity);
            Skill2.transform.position = this.transform.position + new Vector3(0f, 0f, 0f);
            Skill2.transform.LookAt(Enemy.transform);
            this.transform.LookAt(Enemy.transform);
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            skill = 3;
            AP_XXX.AP3 = 0;
            time = !time;
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            //Zを押したらスキル１を発動する
            if (AP_XXX.currentAP2 >= 11)
            {
                GetComponent<Animator>().SetTrigger("Skill");
                GameObject Moon = Instantiate(MoonPrefab);
                Moon.transform.position = this.transform.position + new Vector3(0f, 0f, 0f);
                Moon.transform.LookAt(Enemy.transform);
                this.transform.LookAt(Enemy.transform);
                rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
                skill = 11;
                AP_XXX.AP3 = 0;
                time = !time;
            }
        }
        else
        {
            GetComponent<Animator>().SetTrigger("Stand");
            this.myRigidbody.velocity = new Vector3(0, 0, 0);
        }
        if (time)
        {
            times = Time.time;
        }
        else
        {
            timee = Time.time - times;
        }
        if (timee >= 2)
        {
            AP_XXX.AP3 = 1;
        }
        if (HP_XXXXX.currentHP2 <= 0)
        {
            GetComponent<Animator>().SetTrigger("Die");
            this.myRigidbody.velocity = new Vector3(0, 0, 0);
            this.enabled = false;
        }


    }
    //オブジェクトと衝突した時、オブジェクトを消す条件
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //後で操作キャラクターがオブジェクトと当たった時の計算用
            Debug.Log("敵と衝突した");
        }
    }


}