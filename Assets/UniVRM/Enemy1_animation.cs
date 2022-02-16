using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class Enemy1_animation : MonoBehaviour
{
    //敵の行動を引数uで決めている
    int u;
    //アニメーションをコンポーネント所得
    private Rigidbody rb;
    private float Rotate = 0f;
    private float velocityZ = 10f;
    private float velocityX = 10f;
    private float times = 0f;
    private int attack = 0;
    
    //操作キャラの位置を引数targetにして追いかける
    [SerializeField]
    public GameObject target;
    private NavMeshAgent agent;
    private Animator animator;
    //敵と操作キャラの距離
    private float aD = 0.5f;
    private float fD = 1f;

    int start = 0;
    int end = 10;
    List<int> num = new List<int>();

    private void Start()
    { 
        u =5;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        target = GameObject.Find("Chara2");
    }
    private void Update()
    {
        //動作検証用。終わったら消すように！

        for (int i = start; i <= end; i++)
        {
            num.Add(i);
        }
        while (num.Count > 0)
        {
            int index = Random.Range(0, num.Count);
            int u = num[index];
            num.RemoveAt(index);
            var rb = GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezePosition;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            //攻撃行動
            if (u == 0)
            {
                GetComponent<Animator>().SetTrigger("Attack");
                times = 0;
                attack = 50;
                //u = 4;
            }
            //魔法攻撃行動
            else if (u == 1)
            {
                GetComponent<Animator>().SetTrigger("Attack2");
                times = 0;
                attack = 100;
                //u = 4;
            }
            //Idle状態に戻る
            else if (u == 2)
            {
                GetComponent<Animator>().SetTrigger("Idle");
                times = 0;
                //u = 4;
            }
            //操作キャラの所まで移動
            else if (u == 3)
            {
                //u = 4;
                rb.constraints = RigidbodyConstraints.None;
                rb.constraints = RigidbodyConstraints.FreezeRotation;
                GetComponent<Animator>().SetTrigger("Walk");
                agent.SetDestination(target.transform.position);
                if(agent.remainingDistance<aD)
                {
                    agent.isStopped = true;
                    animator.SetFloat("Speed", 0f);
                }
                else if(agent.remainingDistance>fD)
                {
                    agent.isStopped = false;
                    animator.SetFloat("Speed", agent.desiredVelocity.magnitude);
                }
                rb.constraints = RigidbodyConstraints.FreezePosition;
                times = 0;
            }
            else if (u == 4)
            {
                times += Time.deltaTime;
                if (times >= 2)
                {
                    times = 0;
                }
                else
                {
                    times += Time.deltaTime;
                }
            }
            //連続近接攻撃
            if (u == 5)
            {
                GetComponent<Animator>().SetTrigger("Attack");
                GetComponent<Animator>().SetTrigger("Attack_2");
                times = 0;
                attack = 100;
                //u = 4;
            }
            else
            {
                u = Random.Range(0, 10);
            }

            Debug.Log(u);
        }
    }
    //操作キャラに追尾するスクリプト
    private void OnAnimatorIK()
    {
        var weight = Vector3.Dot(transform.forward.normalized, target.transform.position - transform.position);
        if(weight<0)
        {
            weight = 0;
        }
        animator.SetLookAtWeight(weight, 0f, 1f, 0f, 0f);
        animator.SetLookAtPosition(target.transform.position + Vector3.up * 1.5f);
    }
}