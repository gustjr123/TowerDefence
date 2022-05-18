using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;





public class TowerA : MonoBehaviour {

   public static TowerA Instance;
    public static bool isClear = true;
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
        //만약 게임오버가 True이면 씬 이동
        if (gameOver == true)
        {
            isClear = false;
            SceneManager.LoadScene("resultScene");
        }
    }

   public void Damage()
   {
      hp--;
      hpSlider.value = hp;

      if(hp <= 0)
      {
         //게임오버 플래그 킴
         gameOver = true;
         // if(die)
         // {
         //    //die.SetActive(true);
         // }
      }
   }
}