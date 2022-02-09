using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara2_camera : MonoBehaviour
{
    //�v���C���[�̃I�u�W�F�N�g
    private GameObject chara2;

    //�v���C���[����̋����i���a�j
    private float radius = 7.0f;

    //�����_�̃I�u�W�F�N�g
    private GameObject lookat;

    //�J�����̕����i�I�C���[�p�j0�`360��
    private float rotation = 180.0f;

    // Start is called before the first frame update
    void Start()
    {
        //�v���C���[�̃I�u�W�F�N�g���擾
        this.chara2 = GameObject.Find("Chara2");

        //�����_�̃I�u�W�F�N�g���擾
        this.lookat = GameObject.Find("LookAt");
    }

    // Update is called once per frame
    void Update()
    {
        //�J�������W�̍X�V ��Y�̍��W�̓X���[�i��]�f���j
        //this.transform.position = new Vector3( this.chara2.transform.position.x + (Mathf.Sin( Time.time) * radius), this.transform.position.y, this.chara2.transform.position.z + (Mathf.Cos( Time.time) * radius));

        //�J�������W�̍X�V ��Y�̍��W�̓X���[
        this.transform.position = new Vector3(this.chara2.transform.position.x + (Mathf.Sin(rotation * Mathf.Deg2Rad) * radius), this.transform.position.y, this.chara2.transform.position.z + (Mathf.Cos(rotation * Mathf.Deg2Rad) * radius));

        //�����_�i�v���C���[�j
        transform.LookAt( this.chara2.transform.position + new Vector3( 0f, 1f, 0f));

        //�����_�iLookAt�̃I�u�W�F�N�g�j
        //transform.LookAt(this.lookat.transform);
    }
}
