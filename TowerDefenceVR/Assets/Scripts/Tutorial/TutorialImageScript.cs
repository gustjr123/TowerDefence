using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialImageScript : MonoBehaviour
{
    private Image nowimage;
    
    /*
    0 : Gun
    1 : Shoot
    2 : Good
    3 : Boom
    4 : Two
    5 : Three
    6 : Four
    7 : Five
    8 : Peace
    */
    [SerializeField] private Sprite[] images;

    // Start is called before the first frame update
    void Start()
    {
        nowimage = GetComponent<Image>();
    }

    public void SelectImage(int idx) {
        nowimage.sprite = images[idx];
    }
}
