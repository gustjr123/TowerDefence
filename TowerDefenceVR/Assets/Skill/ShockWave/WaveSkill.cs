using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSkill : MonoBehaviour
{
    [SerializeField] private GameObject WaveParticle;
    [SerializeField] private GameObject targeting;
    public List<GameObject> enemyList;
    [Header("ShockWaveDamage")]
    [SerializeField] private int Damage;

    // Start is called before the first frame update
    void Start()
    {
        enemyList = new List<GameObject>();
        Destroy(WaveParticle, 0.7f);
        Destroy(targeting, 0.65f);
        Destroy(gameObject, 1.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemyBug"))
        {
            // Damage to Enemy
            other.gameObject.GetComponent<Drone>().GetDamage(Damage);
            Destroy(gameObject);
        }
    }
}
