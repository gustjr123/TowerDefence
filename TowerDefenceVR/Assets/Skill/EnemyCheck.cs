using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyCheck : MonoBehaviour
{

    [SerializeField] private GameObject skill;
    private List<GameObject> enemyList;
    void Start()
    {
        enemyList = new List<GameObject>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (!enemyList.Contains(other.gameObject) && other.gameObject.CompareTag("enemy"))
        {
            enemyList.Add(other.gameObject);
        }
    }
    // Input enemy List data
    private void OnDestroy()
    {
        skill.GetComponent<EffectCheck>().enemys.AddRange(enemyList);
    }
}