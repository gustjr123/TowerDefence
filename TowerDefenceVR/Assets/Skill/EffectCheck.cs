using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCheck : MonoBehaviour
{
    public List<GameObject> enemys;
    [SerializeField] private GameObject enemyCheck;
    void Start()
    {
        enemys = new List<GameObject>();
    }

    private void OnDestroy()
    {
        string temp = "";
        foreach (GameObject oj in enemys)
        {
            temp += oj.name + ", ";
        }
        Debug.Log("All : " + temp);

        // Todo damage enemy
    }
}
