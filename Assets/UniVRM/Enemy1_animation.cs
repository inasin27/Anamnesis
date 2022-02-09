using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1_animation : MonoBehaviour
{
    int u;
    //アニメーションをコンポーネント所得
    private Rigidbody rb;
    private float Rotate = 0f;
    private float velocityZ = 10f;
    private float velocityX = 10f;
    private float times = 0f;

    private void Start()
    { 
        u =0;
    }
    private void Update()
    {
        var rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePosition;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        //攻撃行動
        if ((u >= 0) && (u <= 9))
        {
            GetComponent<Animator>().SetTrigger("Attack");
            u = 40;
        }
        //魔法攻撃行動
        else if ((u >= 10) && (u <= 19))
        {
            GetComponent<Animator>().SetTrigger("Attack2");
            u = 40;

        }
        //Idle状態に戻る
        else if ((u >= 20) && (u <= 29))
        {
            GetComponent<Animator>().SetTrigger("Idle");
            u = Random.Range(1, 50);
        }
        //操作キャラの所まで移動
        else if ((u >= 30) && (u <= 39))
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            GetComponent<Animator>().SetTrigger("Walk");
            rb.velocity = new Vector3(0, 0, this.velocityZ);
            u = 40;
        }
        else if (u == 40)
        {
            GetComponent<Animator>().SetTrigger("Idle");
            times += Time.deltaTime;
            if (times >= 3)
            {
                times = 0;
                u = Random.Range(1,50);
            }
        }
        else
        {
            u = 20;
        }
    }
}