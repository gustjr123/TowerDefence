using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clearText : MonoBehaviour
{

    private Text clear;

    // Start is called before the first frame update
    void Start()
    {
        clear = GameObject.Find("clearText").GetComponent<Text>(); //클리어 객체 연결
    }

    // Update is called once per frame
    void Update()
    {
        if (TowerA.isClear == false) //클리어 실패시
        {
            clear.text = "아쉽습니다. 타워를 다시 지켜내봅시다.";
        }
    }
}