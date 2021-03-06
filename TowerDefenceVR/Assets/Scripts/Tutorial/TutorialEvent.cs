using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class TutorialEvent : MonoBehaviour
{
    [Header("Description UI")]
    [SerializeField] private Text description;

    [Header("Test UI")]
    [SerializeField] private Text Test1;

    [Header("First Enemy")]
    [SerializeField] private GameObject enemyPrefab;

    [Header("ImageManager")]
    [SerializeField] private GameObject RightHandImage;
    [SerializeField] private GameObject LeftHandImage;

    private int nowPaze;
    private int MaxPaze;
    // Paze list here

    // Paze end boolean list here
    private List<bool> IsPaze;
    private GameObject target;
    private GameObject target2;
    private GameObject target3;
    private bool iswait;
    private bool isStart;
    private float waittime = 2.1f;

    [System.NonSerialized] public Hands RightHandData;
    [System.NonSerialized] public Hands LeftHandData;

    // Start is called before the first frame update
    void Start()
    {
        MaxPaze = 8;
        DataReset();
        
    }

    // Update is called once per frame
    void Update()
    {
        // 튜토리얼 시작
        if (isStart) {
            firstPaze();
            isStart = false;
        }
        
        #region 1 ~ last페이즈 코드
        // 기본 형태
        if (nowPaze == 0 && !IsPaze[nowPaze] && !iswait) {
            if (target == null && RightHandData == Hands.Shoot) {
                // inputdata Check
                // 제대로 된 입력이 맞다면 다음페이즈로
                IsPaze[nowPaze] = true;
                nowPaze++;    

                // 다음페이즈 함수 호출
                // todo    
                RightHandImage.GetComponent<ImageManager>().ImageSuccess(); // 화면에 입력이 정답임을 표시 (녹색테두리)
                // Nextpaze( {Function name of nextpaze} )
                StartCoroutine(Nextpaze(IceBoltPaze));
            }            
        }
        // Icebolt
        if (nowPaze == 1 && !IsPaze[nowPaze] && !iswait) {
            if (target == null && LeftHandData == Hands.Shoot) {
                IsPaze[nowPaze] = true;
                nowPaze++;    

                // 다음페이즈 함수 호출
                LeftHandImage.GetComponent<ImageManager>().ImageSuccess(); 
                StartCoroutine(Nextpaze(secondPaze));
            }            
        }
        // todo ==> explosion
        if (nowPaze == 2 && !IsPaze[nowPaze]) {
            if (target == null && target2 == null && target3 == null && LeftHandData == Hands.Peace) {
                IsPaze[nowPaze] = true;
                nowPaze++;    

                // 다음페이즈 함수 호출
                LeftHandImage.GetComponent<ImageManager>().ImageSuccess();
                StartCoroutine(Nextpaze(thirdPaze));
            }            
        }
        if (nowPaze == 3 && !IsPaze[nowPaze] && !iswait) {
            if (target == null && LeftHandData == Hands.Calling) {
                IsPaze[nowPaze] = true;
                nowPaze++;    

                // 다음페이즈 함수 호출
                LeftHandImage.GetComponent<ImageManager>().ImageSuccess();
                StartCoroutine(Nextpaze(fourthPaze));
            }            
        }
        if (nowPaze == 4 && !IsPaze[nowPaze] && !iswait) {
            if (target == null && RightHandData == Hands.Peace) {
                IsPaze[nowPaze] = true;
                nowPaze++;    

                // 다음페이즈 함수 호출
                RightHandImage.GetComponent<ImageManager>().ImageSuccess();
                StartCoroutine(Nextpaze(fifthPaze)); 
            }            
        }
        if (nowPaze == 5 && !IsPaze[nowPaze] && !iswait) {
            if (target == null && RightHandData == Hands.Two) {
                IsPaze[nowPaze] = true;
                nowPaze++;    

                // 다음페이즈 함수 호출
                RightHandImage.GetComponent<ImageManager>().ImageSuccess();
                StartCoroutine(Nextpaze(sixthPaze));
            }            
        }
        if (nowPaze == 6 && !IsPaze[nowPaze] && !iswait) {
            if (target == null && RightHandData == Hands.Three) {
                IsPaze[nowPaze] = true;
                nowPaze++;    

                // 다음페이즈 함수 호출
                RightHandImage.GetComponent<ImageManager>().ImageSuccess();
                StartCoroutine(Nextpaze(lastPaze));
            }            
        }
        #endregion
 
        // data 0은 tutorial 종료 신호로 지정
        if (RightHandData == Hands.Good && nowPaze == 7) {
            // 각종 데이터 초기화
            DataReset();

            // 씬 넘어가기
            SceneManager.LoadScene("mainMenuUI");
        }
    }

    private void DataReset() {
        isStart = true;
        iswait = false;
        RightHandData = Hands.Temp;
        nowPaze = 0;
        IsPaze = new List<bool>(MaxPaze);
        for (int i=0; i<MaxPaze; i++) {
            IsPaze.Add(false);
        }
    }
    private IEnumerator Nextpaze(Action work) {
        iswait = true;
        yield return new WaitForSeconds(waittime);
        iswait = false;
        work();
    }

    #region 각 페이즈 함수
    void firstPaze() {
        target = Instantiate(enemyPrefab, gameObject.transform.position, gameObject.transform.rotation);
        // 상태창 대화문 갱신 필요 X
        RightHandImage.GetComponent<ImageManager>().RightImageSet(Hands.Shoot);
    }

    void IceBoltPaze() {
        target = Instantiate(enemyPrefab, gameObject.transform.position, gameObject.transform.rotation);
        description.text = "왼손으로 총모양을 만들면 IceBolt스킬이 발동 됩니다.";
        LeftHandImage.GetComponent<ImageManager>().ImageSet(Hands.Shoot);
    }

    void secondPaze() {
        // explosion skill
        target = Instantiate(enemyPrefab, gameObject.transform.position, gameObject.transform.rotation);
        Vector3 v = new Vector3(0.5f, 0.5f, 4.5f);
        target2 = Instantiate(enemyPrefab, v, gameObject.transform.rotation);
        v = new Vector3(-0.5f, 0.5f, 4.5f);
        target3 = Instantiate(enemyPrefab, v, gameObject.transform.rotation);

        description.text = "앞의 표시된 손모양을 지어서 스킬을 발동하세요.\n본 스킬발동은 왼손으로만 발동시킬 수 있습니다.\n본 스킬은 발동시키면 발사속도가 증가하며, 총알이 명중할 시 폭발하게 됩니다.";
        LeftHandImage.GetComponent<ImageManager>().ImageSet(Hands.Peace);
    }

    void thirdPaze() {
        target = Instantiate(enemyPrefab, gameObject.transform.position, gameObject.transform.rotation);
        description.text = "앞의 표시된 손모양을 지어서 스킬을 발동하세요.\n본 스킬발동은 왼손으로만 발동시킬 수 있습니다.";
        LeftHandImage.GetComponent<ImageManager>().ImageSet(Hands.Calling);
    }

    void fourthPaze() {
        description.text = "앞의 표시된 손모양을 오른손으로 만들어 보세요.\n본 과정은 눈 앞의 이미지를 따라서 손을 만들 수 있는지를 확인하는 과정입니다.";
        RightHandImage.GetComponent<ImageManager>().RightImageSet(Hands.Peace);
    }

    void fifthPaze() {
        RightHandImage.GetComponent<ImageManager>().RightImageSet(Hands.Two);
    }

    void sixthPaze() {
        RightHandImage.GetComponent<ImageManager>().RightImageSet(Hands.Three);
    }

    void lastPaze() {
        description.text = "모든 튜토리얼이 종료되었습니다. \n엄지척을 들어 메인메뉴로 돌아가세요";
        RightHandImage.GetComponent<ImageManager>().RightImageSet(Hands.Good);
    }
    #endregion

    #region Input Hands Gesture
    public void RightHandInput(int data) {
        // enum Hands { Gun, Shoot, Good, Boom, Two, Three, Four, Five, Peace, Temp }
        switch(data) {
            case 0 : RightHandData = Hands.Gun; break;
            case 1 : RightHandData = Hands.Shoot; break;
            case 2 : RightHandData = Hands.Good; break;
            case 3 : RightHandData = Hands.Calling; break;
            case 4 : RightHandData = Hands.Two; break;
            case 5 : RightHandData = Hands.Three; break;
            case 6 : RightHandData = Hands.Four; break;
            case 7 : RightHandData = Hands.Five; break;
            case 8 : RightHandData = Hands.Peace; break;
            case 9 : RightHandData = Hands.Temp; break;
        }
    }

    public void LeftHandInput(int data) {
        // enum Hands { Gun, Shoot, Good, Boom, Two, Three, Four, Five, Peace, Temp }
        switch(data) {
            case 0 : LeftHandData = Hands.Gun; break;
            case 1 : LeftHandData = Hands.Shoot; break;
            case 2 : LeftHandData = Hands.Good; break;
            case 3 : LeftHandData = Hands.Calling; break;
            case 4 : LeftHandData = Hands.Two; break;
            case 5 : LeftHandData = Hands.Three; break;
            case 6 : LeftHandData = Hands.Four; break;
            case 7 : LeftHandData = Hands.Five; break;
            case 8 : LeftHandData = Hands.Peace; break;
            case 9 : LeftHandData = Hands.Temp; break;
        }
    }
    #endregion
}
