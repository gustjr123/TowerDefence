using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialEvent : MonoBehaviour
{
    [Header("Description UI")]
    [SerializeField] private Text description;

    [Header("First Enemy")]
    [SerializeField] private GameObject enemyPrefab;

    private int nowPaze;
    private int MaxPaze;
    // Paze list here

    // Paze end boolean list here
    private List<bool> IsPaze;
    private GameObject target;

    [System.NonSerialized] public int inputData;

    // Start is called before the first frame update
    void Start()
    {
        inputData = 999;
        MaxPaze = 2;
        nowPaze = 0;
        IsPaze = new List<bool>(MaxPaze);
        for (int i=0; i<MaxPaze; i++) {
            IsPaze.Add(false);
        }
        firstPaze();
    }

    // Update is called once per frame
    void Update()
    {
        // 기본 형태
        if (nowPaze == 0 && !IsPaze[nowPaze]) {
            if (target == null) {
                // inputdata Check
                // 제대로 된 입력이 맞다면 다음페이즈로
                IsPaze[nowPaze] = true;
                nowPaze++;    

                // 다음페이즈 함수 호출
                // todo    
                lastPaze();        
            }            
        }
        // if (nowPaze == 0 && !IsPaze[nowPaze]) {
        //     if (inputData == 0) {
        //         // inputdata Check
        //         // 제대로 된 입력이 맞다면 다음페이즈로
        //         IsPaze[nowPaze] = true;
        //         nowPaze++;    

        //         // 다음페이즈 함수 호출
        //         // todo    
        //         lastPaze();        
        //     }            
        // }

        // data 0은 tutorial 종료 신호로 지정
        if (inputData == 0 && nowPaze == 1) {
            SceneManager.LoadScene("mainMenuUI");
        }
        
    }

    void firstPaze() {
        target = Instantiate(enemyPrefab, gameObject.transform.position, gameObject.transform.rotation);
        // 상태창 대화문 갱신 필요 X
    }

    void lastPaze() {
        description.text = "모든 튜토리얼이 종료되었습니다. \n엄지척을 들어 메인메뉴로 돌아가세요";
    }
    public void GetInput(int data) {
        inputData = data;
    }
}
