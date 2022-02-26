using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3 : MonoBehaviour
{
	// �A�j���[�V�������邽�߂̃R���|�[�l���g������
	private Animator myAnimator;

	//�ړ�������R���|�[�l���g������
	private Rigidbody myRigidbody;

	//�ړ���
	private float velocity = 5.0f;

	//��]��
	private float rotation = 50.0f;

	//�n�ʂɐڐG
	private bool isGround = false;

	//�v���n�u
	public GameObject SpherePrefab;

	//�G�I�u�W�F�N�g
	private GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
		//�A�j���[�^�R���|�[�l���g���擾
		this.myAnimator = GetComponent<Animator>();

		//Rigidbody�R���|�[�l���g���擾
		this.myRigidbody = GetComponent<Rigidbody>(); 

		//�G�̃I�u�W�F�N�g���擾
		Enemy = GameObject.Find( "Enemy");
    }

    // Update is called once per frame
    void Update()
    {
 		// �����Ă�������𓾂�i�I�C���[�j
		float direction = this.transform.rotation.eulerAngles.y;

		// �L�[�{�[�h W�ňړ�
		if( Input.GetKey( KeyCode.UpArrow) || Input.GetKey( KeyCode.W)) {
			//�����A�j���[�V�������J�n
			this.myAnimator.SetFloat( "Speed", velocity);

			//�ړ��W�����v ��Y����velocity�X���[
			if( Input.GetKey( KeyCode.Space) && isGround) {
				//���x��^����i�I�C���[�����W�A���j
				this.myRigidbody.velocity = new Vector3( Mathf.Sin( direction * Mathf.Deg2Rad) * velocity, 5.0f, Mathf.Cos( direction * Mathf.Deg2Rad) * velocity);					
			} else {
				//���x��^����i�I�C���[�����W�A���j
				this.myRigidbody.velocity = new Vector3( Mathf.Sin( direction * Mathf.Deg2Rad) * velocity, this.myRigidbody.velocity.y, Mathf.Cos( direction * Mathf.Deg2Rad) * velocity);
			}
		} else {
			//�����A�j���[�V�������~
			this.myAnimator.SetFloat( "Speed", 0.0f);

			//�����W�����v ��Y����velocity�X���[
			if( Input.GetKey( KeyCode.Space) && isGround) {
				//���x��^����i�I�C���[�����W�A���j
				this.myRigidbody.velocity = new Vector3( 0.0f, 5.0f, 0.0f);					
			}
		}

		// �L�[�{�[�h A, D ��] ��Time.deltaTime�AFPS��ˑ�
		if( Input.GetKey( KeyCode.LeftArrow) || Input.GetKey( KeyCode.A)) {
			this.transform.Rotate( new Vector3( 0.0f, -rotation * Time.deltaTime, 0.0f));
		} else if( Input.GetKey( KeyCode.RightArrow) || Input.GetKey( KeyCode.D)) {
			this.transform.Rotate( new Vector3( 0.0f, rotation * Time.deltaTime, 0.0f));
		}
		
		// �L�[�{�[�h 1�`4�ōU���̃��[�V�����e�X�g
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

		// �L�[�{�[�h 5�Ń_���[�W�A6�`7�Ŏ��SA,B�̃��[�V�����e�X�g
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

		// Z�L�[�ōU���̐���
        if( Input.GetKeyDown( KeyCode.Z))
		{
			//�C���X�^���X
            GameObject Sphere = Instantiate( SpherePrefab);
			//����������W ���v���C���[����������1���[�g���̈ʒu
            Sphere.transform.position = this.transform.position + new Vector3(0f, 1f, 0f);
			//�G�̕����֌�����
			Sphere.transform.LookAt( Enemy.transform);
			//���g�A�G�̕��֌���
			this.transform.LookAt( Enemy.transform);
		}
    }

	//�Փ˂���
	void OnCollisionEnter( Collision other) {
		//�n�� �����������̂ŏ��͑S�� Untagged�Ŏ�������B
		if( other.gameObject.tag == "Untagged") {
			isGround = true;
		}
	}

	//�Փ˂����i�⋭�j
	void OnCollisionStay( Collision other) {
		//�n�� �����������̂ŏ��͑S�� Untagged�Ŏ�������B
		if( other.gameObject.tag == "Untagged") {
			isGround = true;
		}
	}

	//�Փ˂��痣�ꂽ
	void OnCollisionExit( Collision other) {
		//�n�� �����������̂ŏ��͑S�� Untagged�Ŏ�������B
		if( other.gameObject.tag == "Untagged") {
			isGround = false;
		}		
	}

	/*
	//�Փ˂��� ���g���K�[
	void OnTriggerEnter( Collider other) {
		if( other.gameObject.tag == "") {

		}
	}

	//�Փ˂��痣�ꂽ ���g���K�[
	void OnTriggerExit( Collider other) {
		if( other.gameObject.tag == "") {

		}		
	}
	*/
}
