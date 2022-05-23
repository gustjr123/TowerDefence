using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class test1 : MonoBehaviour
{
    [SerializeField] private GameObject lefttip;
    [SerializeField] private GameObject righttip;
    [SerializeField] private GameObject leftthump;
    [SerializeField] private GameObject rightthump;
    [SerializeField] private Text text;
    [SerializeField] private Text text2;
    private float timeTo = 0f;
     

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timeTo){
            Vector3 v1 = gameObject.transform.InverseTransformPoint(lefttip.transform.position);
            Vector3 v2 = gameObject.transform.InverseTransformPoint(righttip.transform.position);

            text.text = Vector3.Distance(v1, v2).ToString();

            v1 = gameObject.transform.InverseTransformPoint(leftthump.transform.position);
            v2 = gameObject.transform.InverseTransformPoint(rightthump.transform.position);

            text2.text = Vector3.Distance(v1, v2).ToString();
            timeTo = 0.5f + Time.time;
        }
            
    }
}
