using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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
            //description.text = "������ �����̿���.\n��ȣ�� �����ؼ� ���� �������ּ���.";
            ImageManager.GetComponent<ImageManager>().ImageSet(Hands.Peace);
            PauseManager.GetComponent<Pause>().PauseGame();

            if (RightHandData == Hands.Peace)
            {
                PauseManager.GetComponent<Pause>().NonPause();
                ImageManager.GetComponent<ImageManager>().ImageSuccess();
                SceneManager.LoadScene("mainMenuUI");
            }



            // todo Image Open
            // ~~~~~
            // ���ӳ����� ���ǽ� isEnd = !isEnd

            // ����
            /*
             * 1. ���� ���ǽ� (���ߴ� ����) ���ӻ� ���� ���߰� image������Ʈ�� ������ġ ����
             * 2. �յ��� �ν����� image������Ʈ �νĵɶ� ����׵θ� ��ȯ��
             * 3. ��� image������Ʈ ����׵θ��� ��ȯ�Ǹ� ���ӻ��� ������ �ʱ�ȭ��Ű�� SceneLoad�� Menu������ ��ȯ
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
