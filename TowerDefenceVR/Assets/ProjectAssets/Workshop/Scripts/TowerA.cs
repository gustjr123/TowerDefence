using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TowerA : MonoBehaviour {

	public static TowerA Instance;

    public Slider hpSlider;

	public int MAX_HP = 10;
	int hp = 0;

    bool gameOver = false;

	public GameObject die;

	void Awake()
	{
        
		if(Instance == null)
			Instance = this;
	}

	void Start()
	{
        
		hp = MAX_HP;
	}

    private void Update()
    {
        //만약 게임오버가 True이고 버튼이 클릭되면 게임 재시작
        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(0);
        }
    }

	public void Damage()
	{
		hp--;
        hpSlider.value = hp;

        //게임오버 플래그 킴
        gameOver = true;
		if(hp <= 0)
		{
			if(die)
			{
				die.SetActive(true);
			}
		}
	}
}
