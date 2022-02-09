using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara2_camera : MonoBehaviour
{
    //プレイヤーのオブジェクト
    private GameObject chara2;

    //プレイヤーからの距離（半径）
    private float radius = 7.0f;

    //注視点のオブジェクト
    private GameObject lookat;

    //カメラの方向（オイラー角）0～360°
    private float rotation = 180.0f;

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーのオブジェクトを取得
        this.chara2 = GameObject.Find("Chara2");

        //注視点のオブジェクトを取得
        this.lookat = GameObject.Find("LookAt");
    }

    // Update is called once per frame
    void Update()
    {
        //カメラ座標の更新 ※Yの座標はスルー（回転デモ）
        //this.transform.position = new Vector3( this.chara2.transform.position.x + (Mathf.Sin( Time.time) * radius), this.transform.position.y, this.chara2.transform.position.z + (Mathf.Cos( Time.time) * radius));

        //カメラ座標の更新 ※Yの座標はスルー
        this.transform.position = new Vector3(this.chara2.transform.position.x + (Mathf.Sin(rotation * Mathf.Deg2Rad) * radius), this.transform.position.y, this.chara2.transform.position.z + (Mathf.Cos(rotation * Mathf.Deg2Rad) * radius));

        //注視点（プレイヤー）
        transform.LookAt( this.chara2.transform.position + new Vector3( 0f, 1f, 0f));

        //注視点（LookAtのオブジェクト）
        //transform.LookAt(this.lookat.transform);
    }
}
