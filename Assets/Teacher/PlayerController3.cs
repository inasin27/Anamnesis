using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3 : MonoBehaviour
{
	// アニメーションするためのコンポーネントを入れる
	private Animator myAnimator;

	//移動させるコンポーネントを入れる
	private Rigidbody myRigidbody;

	//移動量
	private float velocity = 5.0f;

	//回転量
	private float rotation = 50.0f;

	//地面に接触
	private bool isGround = false;

	//プレハブ
	public GameObject SpherePrefab;

	//敵オブジェクト
	private GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
		//アニメータコンポーネントを取得
		this.myAnimator = GetComponent<Animator>();

		//Rigidbodyコンポーネントを取得
		this.myRigidbody = GetComponent<Rigidbody>(); 

		//敵のオブジェクトを取得
		Enemy = GameObject.Find( "Enemy");
    }

    // Update is called once per frame
    void Update()
    {
 		// 向いている方向を得る（オイラー）
		float direction = this.transform.rotation.eulerAngles.y;

		// キーボード Wで移動
		if( Input.GetKey( KeyCode.UpArrow) || Input.GetKey( KeyCode.W)) {
			//歩くアニメーションを開始
			this.myAnimator.SetFloat( "Speed", velocity);

			//移動ジャンプ ※Y軸のvelocityスルー
			if( Input.GetKey( KeyCode.Space) && isGround) {
				//速度を与える（オイラー→ラジアン）
				this.myRigidbody.velocity = new Vector3( Mathf.Sin( direction * Mathf.Deg2Rad) * velocity, 5.0f, Mathf.Cos( direction * Mathf.Deg2Rad) * velocity);					
			} else {
				//速度を与える（オイラー→ラジアン）
				this.myRigidbody.velocity = new Vector3( Mathf.Sin( direction * Mathf.Deg2Rad) * velocity, this.myRigidbody.velocity.y, Mathf.Cos( direction * Mathf.Deg2Rad) * velocity);
			}
		} else {
			//歩くアニメーションを停止
			this.myAnimator.SetFloat( "Speed", 0.0f);

			//垂直ジャンプ ※Y軸のvelocityスルー
			if( Input.GetKey( KeyCode.Space) && isGround) {
				//速度を与える（オイラー→ラジアン）
				this.myRigidbody.velocity = new Vector3( 0.0f, 5.0f, 0.0f);					
			}
		}

		// キーボード A, D 回転 ※Time.deltaTime、FPS非依存
		if( Input.GetKey( KeyCode.LeftArrow) || Input.GetKey( KeyCode.A)) {
			this.transform.Rotate( new Vector3( 0.0f, -rotation * Time.deltaTime, 0.0f));
		} else if( Input.GetKey( KeyCode.RightArrow) || Input.GetKey( KeyCode.D)) {
			this.transform.Rotate( new Vector3( 0.0f, rotation * Time.deltaTime, 0.0f));
		}
		
		// キーボード 1～4で攻撃のモーションテスト
        if( Input.GetKey( KeyCode.Alpha1))
		{
			this.myAnimator.SetTrigger( "Attack1");
		} else if( Input.GetKey( KeyCode.Alpha2))
		{
			this.myAnimator.SetTrigger( "Attack2");
		} else if( Input.GetKey( KeyCode.Alpha3))
		{
			this.myAnimator.SetTrigger( "Attack3");
		} else if( Input.GetKey( KeyCode.Alpha4))
		{
			this.myAnimator.SetTrigger( "Attack4");
		}

		// キーボード 5でダメージ、6～7で死亡A,Bのモーションテスト
        if( Input.GetKey( KeyCode.Alpha5))
		{
			this.myAnimator.SetTrigger( "Damage");
		} else if( Input.GetKey( KeyCode.Alpha6))
		{
			this.myAnimator.SetTrigger( "DieA");
		} else if( Input.GetKey( KeyCode.Alpha7))
		{
			this.myAnimator.SetTrigger( "DieB");
		}

		// Zキーで攻撃の生成
        if( Input.GetKeyDown( KeyCode.Z))
		{
			//インスタンス
            GameObject Sphere = Instantiate( SpherePrefab);
			//生成する座標 ※プレイヤー足元から上へ1メートルの位置
            Sphere.transform.position = this.transform.position + new Vector3(0f, 1f, 0f);
			//敵の方向へ向ける
			Sphere.transform.LookAt( Enemy.transform);
			//自身、敵の方へ向く
			this.transform.LookAt( Enemy.transform);
		}
    }

	//衝突した
	void OnCollisionEnter( Collision other) {
		//地面 ※床が多いので床は全て Untaggedで実装する。
		if( other.gameObject.tag == "Untagged") {
			isGround = true;
		}
	}

	//衝突した（補強）
	void OnCollisionStay( Collision other) {
		//地面 ※床が多いので床は全て Untaggedで実装する。
		if( other.gameObject.tag == "Untagged") {
			isGround = true;
		}
	}

	//衝突から離れた
	void OnCollisionExit( Collision other) {
		//地面 ※床が多いので床は全て Untaggedで実装する。
		if( other.gameObject.tag == "Untagged") {
			isGround = false;
		}		
	}

	/*
	//衝突した ※トリガー
	void OnTriggerEnter( Collider other) {
		if( other.gameObject.tag == "") {

		}
	}

	//衝突から離れた ※トリガー
	void OnTriggerExit( Collider other) {
		if( other.gameObject.tag == "") {

		}		
	}
	*/
}
