using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject Explosionparticle;
    public List<GameObject> enemyList;

    [Header("ShockWaveDamage")]
    [SerializeField] private int Damage;

    // Start is called before the first frame update
    void Start()
    {
        enemyList = new List<GameObject>();
        Destroy(gameObject, 1.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemyBug"))
        {
            // Damage to Enemy
            other.gameObject.GetComponent<Drone>().GetDamage(Damage);
        }
    }
}
