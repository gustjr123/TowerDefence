using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{
    public Text counterText;
    int kills;
    private GameObject target;

    [System.NonSerialized] public Hands RightHandData;
    /*
    [Header("Description UI")]
    [SerializeField] private Text description;
    */
    [Header("Give Data")]
    [SerializeField] private GameObject PauseManager;

    [Header("ImageManager")]
    [SerializeField] private GameObject ImageManager;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShowKills();
        if (kills == 10)
        {
            //description.text = "고지가 눈앞이예요.\n암호를 따라해서 적을 물리쳐주세요.";
            ImageManager.GetComponent<ImageManager>().ImageSet(Hands.Peace);
            PauseManager.GetComponent<Pause>().PauseGame();

            if (RightHandData == Hands.Peace)
            {
                PauseManager.GetComponent<Pause>().NonPause();
                ImageManager.GetComponent<ImageManager>().ImageSuccess();
            }



            // todo Image Open
            // ~~~~~
            // 게임끝나는 조건시 isEnd = !isEnd

            // 할일
            /*
             * 1. 일정 조건시 (멈추는 조건) 게임상 모든게 멈추고 image오브젝트가 랜덤위치 생성
             * 2. 손동작 인식으로 image오브젝트 인식될때 녹색테두리 변환됨
             * 3. 모든 image오브젝트 녹색테두리로 변환되면 게임상의 데이터 초기화시키고 SceneLoad로 Menu씬으로 전환
             * */

            /*
            if (RightHandData == Hands.Calling)
            {
                PauseManager.GetComponent<Pause>().NonPause();
                ImageManager.GetComponent<ImageManager>().ImageSuccess();
            }
            */
        }
    }

    private void ShowKills()
    {
        counterText.text = kills.ToString();
    }

    public void AddKill()
    {
        kills += 1;
    }

    public void RightHandInput(int data)
    {
        // enum Hands { Gun, Shoot, Good, Boom, Two, Three, Four, Five, Peace, Temp }
        switch (data)
        {
            case 1: RightHandData = Hands.Shoot; break;
            case 2: RightHandData = Hands.Peace; break;
        }
    }
}
