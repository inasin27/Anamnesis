using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	//アニメーションするためのコンポーネントを入れる
	private Animator myAnimator;

	//移動させるコンポーネントを入れる
	private Rigidbody myRigidbody;

	//移動量
	private float velocity = 5.0f;

	//回転量
	private float rotation = 5.0f;

	//地面に接触
	private bool isGround = false;

    // Start is called before the first frame update
    void Start()
    {
		//アニメータコンポーネントを取得
		this.myAnimator = GetComponent<Animator>();

		//Rigidbodyコンポーネントを取得
		this.myRigidbody = GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
 		//向いている方向を得る（オイラー）
		float direction = this.transform.rotation.eulerAngles.y;

		//移動、ジャンプ
		if( Input.GetKey( KeyCode.W))
		{
			//歩くアニメーションを開始
			this.myAnimator.SetFloat( "Speed", velocity);

			//速度を与える（オイラー→ラジアン）
			this.myRigidbody.velocity = new Vector3( Mathf.Sin( direction * Mathf.Deg2Rad) * velocity, 0.0f, Mathf.Cos( direction * Mathf.Deg2Rad) * velocity);
		}
		else
		{
			//歩くアニメーションを停止
			this.myAnimator.SetFloat( "Speed", 0.0f);
		}

		//回転
		if( Input.GetKey( KeyCode.A))
		{
			this.transform.Rotate( new Vector3( 0.0f, -rotation, 0.0f));
		}
		else if( Input.GetKey( KeyCode.D))
		{
			this.transform.Rotate( new Vector3( 0.0f, rotation, 0.0f));
		}		       
    }
}
