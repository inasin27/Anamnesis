using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		//�����Ă�������ֈړ�
        this.GetComponent<Rigidbody>().AddForce( transform.forward * 1f, ForceMode.Force);
    }
}
