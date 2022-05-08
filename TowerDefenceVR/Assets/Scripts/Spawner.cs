using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Spawner : MonoBehaviour
{
    public List<GameObject> prefabs;

    [Header("Cooldown Time for Second")]
    [SerializeField] private int Cooldown;

    [Header("TextField")]
    [SerializeField] private Text text;

    [Header("BulletPrefab for explosion")]
    [SerializeField] private GameObject bullet;

    [Header("ExplosionDuringTime Time for Second")]
    [SerializeField] private int ExplosionDuringTime;

    private bool isCooldown;
    private WaitForSeconds WaitTime;

    private void Start() {
        isCooldown = true;
        WaitTime = new WaitForSeconds(1.0f);
    }

    public void Spawn(int index)
    {
        if (isCooldown) {
            // if explosion
            if (index == 1) {
                bullet.GetComponent<Bullet>().fireRate *= 2.0f;
                bullet.GetComponent<Bullet>().OnExplosion = true;
                StartCoroutine(ExplosionCoroutine());
            }
            else {
                Instantiate(prefabs[index], transform.position, transform.rotation);
            }
            StartCoroutine(CoolDownCoroutine());
        }
    }

    IEnumerator CoolDownCoroutine() {
        isCooldown = false;
        for(int i=Cooldown; i>0; i--) {
            yield return WaitTime;
            if (text != null)
                text.text = (i-1).ToString();
        }
        if (text != null)
            text.text = "Can Use";
        isCooldown = true;
    }

    IEnumerator ExplosionCoroutine() {
        for(int i=ExplosionDuringTime; i>0; i--) {
            yield return WaitTime;
        }
        bullet.GetComponent<Bullet>().fireRate *= 0.5f;
        bullet.GetComponent<Bullet>().OnExplosion = false;
    }
}