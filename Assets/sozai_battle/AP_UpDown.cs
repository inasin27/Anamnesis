using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AP_UpDown : MonoBehaviour
{
    //ç≈ëÂÇÃAPêî
    int maxAP = 100;
    //åªç›ÇÃAPêî
    float currentAP;
    GameObject AP;


    // Start is called before the first frame update
    void Start()
    {
        AP = GameObject.Find("AP");    
    }

    // Update is called once per frame
    void Update()
    {
        AP.GetComponent<AP>().APFull(currentAP, maxAP);
    }

    private void FixedUpdate()
    {
        if(0<=currentAP)
        {
            currentAP = maxAP - Time.time * 100;
        }
    }
}
