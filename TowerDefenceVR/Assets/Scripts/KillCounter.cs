using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class KillCounter : MonoBehaviour
{
    public Text counterText;
    int kills;

    [Header("RandomImageRespawner")]
    [SerializeField] private GameObject ImageManager;

    private int nowPaze;
    private int MaxPaze;

    /*
    [Header("Description UI")]
    [SerializeField] private Text description;
    */
    [Header("Give Data")]
    [SerializeField] private GameObject PauseManager;

    [System.NonSerialized] public Hands RightHandData;
    [System.NonSerialized] public Hands LeftHandData;

    private bool isRight;
    private List<bool> IsPaze;
    private Hands nowCurrentHand;
    [System.NonSerialized] public bool readyImage;

    private void Awake() {
        readyImage = false;
        MaxPaze = 4;
        DataReset();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowKills();
        
        if(RightHandData == Hands.Four) {
            Debug.Log("Four OK");
        }
        if(LeftHandData == Hands.Four) {
            Debug.Log("LFour OK");
        }
        if (kills >= 10)
        {
            //description.text = "������ �����̿���.\n��ȣ�� �����ؼ� ���� �������ּ���.";
            // ImageManager.GetComponent<ImageManager>().ImageSet(Hands.Peace);
            if (nowPaze == 0) {
                PauseManager.GetComponent<Pause>().PauseGame();
                nowPaze = 1;
                readyImage = false;
                PazeFunc();
            }
            
            //if (RightHandData == Hands.Peace)
            // first
            if (nowPaze == 1 && !IsPaze[nowPaze - 1] && readyImage)
            {
                if (isRight) {
                    if (nowCurrentHand == RightHandData) {
                        IsPaze[nowPaze - 1] = true;
                        nowPaze = 2;
                        ImageManager.GetComponent<ImageManager>().ImageSuccess();
                        readyImage = false;
                        PazeFunc();
                    }
                }
                else {
                    if (nowCurrentHand == LeftHandData) {
                        IsPaze[nowPaze - 1] = true;
                        nowPaze = 2;
                        ImageManager.GetComponent<ImageManager>().ImageSuccess();
                        readyImage = false;
                        PazeFunc();
                    }
                }
            }
            // second
            if (nowPaze == 2 && !IsPaze[nowPaze - 1] && readyImage)
            {
                if (isRight) {
                    if (nowCurrentHand == RightHandData) {
                        IsPaze[nowPaze - 1] = true;
                        nowPaze = 3;
                        ImageManager.GetComponent<ImageManager>().ImageSuccess();
                        readyImage = false;
                        PazeFunc();
                    }
                }
                else {
                    if (nowCurrentHand == LeftHandData) {
                        IsPaze[nowPaze - 1] = true;
                        nowPaze = 3;
                        ImageManager.GetComponent<ImageManager>().ImageSuccess();
                        readyImage = false;
                        PazeFunc();
                    }
                }
            }
            // third
            if (nowPaze == 3 && !IsPaze[nowPaze - 1] && readyImage)
            {
                if (isRight) {
                    if (nowCurrentHand == RightHandData) {
                        IsPaze[nowPaze - 1] = true;
                        nowPaze = 4;
                        ImageManager.GetComponent<ImageManager>().ImageSuccess();
                        readyImage = false;
                        PazeFunc();
                    }
                }
                else {
                    if (nowCurrentHand == LeftHandData) {
                        IsPaze[nowPaze - 1] = true;
                        nowPaze = 4;
                        ImageManager.GetComponent<ImageManager>().ImageSuccess();
                        readyImage = false;
                        PazeFunc();
                    }
                }
            }
            // fourth
            if (nowPaze == 4 && !IsPaze[nowPaze - 1] && readyImage)
            {
                if (isRight) {
                    if (nowCurrentHand == RightHandData) {
                        IsPaze[nowPaze - 1] = true;
                        nowPaze = 5;
                        ImageManager.GetComponent<ImageManager>().ImageSuccess();
                        readyImage = false;
                    }
                }
                else {
                    if (nowCurrentHand == LeftHandData) {
                        IsPaze[nowPaze - 1] = true;
                        nowPaze = 5;
                        ImageManager.GetComponent<ImageManager>().ImageSuccess();
                        readyImage = false;
                    }
                }
            }

            // Last Paze
            if (nowPaze >= 5)
            {
                PauseManager.GetComponent<Pause>().NonPause();

                DataReset();
                ImageManager.GetComponent<ImageManager>().Reset();
                // GameClear and Clear Impact open
                
                SceneManager.LoadScene("mainMenuUI");
            }
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

    #region 각 페이즈 함수
    void PazeFunc() {
        Debug.Log("Image Create : PazeFunc");
        nowCurrentHand = ImageManager.GetComponent<ImageManager>().RandomImage();
        isRight = ImageManager.GetComponent<ImageManager>().isRight();
    }
    #endregion


    #region Input Hands Gesture
    public void RightHandInput(int data)
    {
        // enum Hands { Gun, Shoot, Good, Boom, Two, Three, Four, Five, Peace, Temp }
        switch (data)
        {
            case 0: RightHandData = Hands.Gun; break;
            case 1: RightHandData = Hands.Shoot; break;
            case 2: RightHandData = Hands.Good; break;
            case 3: RightHandData = Hands.Calling; break;
            case 4: RightHandData = Hands.Two; break;
            case 5: RightHandData = Hands.Three; break;
            case 6: RightHandData = Hands.Four; break;
            case 7: RightHandData = Hands.Five; break;
            case 8: RightHandData = Hands.Peace; break;
            case 9: RightHandData = Hands.Temp; break;
        }
    }

    public void LeftHandInput(int data)
    {
        // enum Hands { Gun, Shoot, Good, Boom, Two, Three, Four, Five, Peace, Temp }
        switch (data)
        {
            case 0: LeftHandData = Hands.Gun; break;
            case 1: LeftHandData = Hands.Shoot; break;
            case 2: LeftHandData = Hands.Good; break;
            case 3: LeftHandData = Hands.Calling; break;
            case 4: LeftHandData = Hands.Two; break;
            case 5: LeftHandData = Hands.Three; break;
            case 6: LeftHandData = Hands.Four; break;
            case 7: LeftHandData = Hands.Five; break;
            case 8: LeftHandData = Hands.Peace; break;
            case 9: LeftHandData = Hands.Temp; break;
        }
    }
    #endregion

    private IEnumerator WaitSecnd()
    {
        yield return new WaitForSeconds(1f);
    }

    private void DataReset() {
        RightHandData = Hands.Temp;
        nowPaze = 0;
        IsPaze = new List<bool>(MaxPaze);
        for (int i=0; i<MaxPaze; i++) {
            IsPaze.Add(false);
        }
    }
}
