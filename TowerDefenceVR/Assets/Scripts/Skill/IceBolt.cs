using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceBolt : MonoBehaviour
{
    #region Configure Variable
    public float speed = 5f;
    public float fireRate = 1f;
    public float timeBeforeDestroyed = 10f;
    private bool collided = false;
    private Rigidbody rb = null;

    [Header("IceBoltDamage")]
    [SerializeField] private int Damage;

    [Header("IceBoltCoolTime")]
    [SerializeField] private int IceBolt_CoolTime;
    private bool isIceBoltCooling = false;
    #endregion


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, timeBeforeDestroyed);
    }

    void FixedUpdate()
    {
        if (speed != 0 && rb != null)
            rb.position += (transform.forward) * (speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision co)
    {
        
        if (co.gameObject.tag != "Bullet" && !collided && !co.gameObject.CompareTag("enemyBug"))
        {
            collided = true;
            speed = 0;
            // Destroy(gameObject);
        }
    }

    public void ExplosionSkillActivate()
    {
        if (!isIceBoltCooling)
        {
            StartCoroutine(IceBoltCoroutine(3f));
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("enemyBug"))
        {
            // Damage to Enemy
            other.gameObject.GetComponent<Drone>().GetDamage(Damage);
            // Destroy(gameObject);
        }
    }

    #region Coroutine함수
    IEnumerator IceBoltCoroutine(float IceBolt_CoolTime)
    {
        while (IceBolt_CoolTime > 1.0f)
        {
            IceBolt_CoolTime -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
    }
    #endregion
}