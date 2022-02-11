using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	//�A�j���[�V�������邽�߂̃R���|�[�l���g������
	private Animator myAnimator;

	//�ړ�������R���|�[�l���g������
	private Rigidbody myRigidbody;

	//�ړ���
	private float velocity = 5.0f;

	//��]��
	private float rotation = 5.0f;

	//�n�ʂɐڐG
	private bool isGround = false;

    // Start is called before the first frame update
    void Start()
    {
		//�A�j���[�^�R���|�[�l���g���擾
		this.myAnimator = GetComponent<Animator>();

		//Rigidbody�R���|�[�l���g���擾
		this.myRigidbody = GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
 		//�����Ă�������𓾂�i�I�C���[�j
		float direction = this.transform.rotation.eulerAngles.y;

		//�ړ��A�W�����v
		if( Input.GetKey( KeyCode.W))
		{
			//�����A�j���[�V�������J�n
			this.myAnimator.SetFloat( "Speed", velocity);

			//���x��^����i�I�C���[�����W�A���j
			this.myRigidbody.velocity = new Vector3( Mathf.Sin( direction * Mathf.Deg2Rad) * velocity, 0.0f, Mathf.Cos( direction * Mathf.Deg2Rad) * velocity);
		}
		else
		{
			//�����A�j���[�V�������~
			this.myAnimator.SetFloat( "Speed", 0.0f);
		}

		//��]
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
