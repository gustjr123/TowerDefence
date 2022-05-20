using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    [Header("SpawnTransform")]
    public Transform hand;

    [Header("BulletPrefab")]
    [SerializeField] GameObject bulletPrefab;


    public enum ShootMode
    {
        Auto,
        Single,
        IceBolt
    }

    [Header("ShootMethod")]
    // Choose the method of firing the bullets from Inspector
    public ShootMode shootMode;

    

    // Boolean to use in single ShootMode
    private bool hasShoot = false;

    // Float used to calculate the time need to fire the bullet, related to the bullet fireRate
    private float timeToFire = 0f;

    // for Explosion skill, Not Use it for WaveSkill
    [System.NonSerialized] public bool isSkillOn = false;
    [System.NonSerialized] public float RunningTime;

    private bool isIceCool = false;

    // Method to add in the Event of the gesture you want to make shoot
    public void OnShoot()
    {
        // Switch between the to modes
        switch (shootMode)
        {
            case ShootMode.Auto:
                if (Time.time >= timeToFire)
                {
                    timeToFire = Time.time + 1f / bulletPrefab.GetComponent<Bullet>().fireRate;
                    Shoot();
                }
                break;

            case ShootMode.Single:
                if (!hasShoot)
                {
                    hasShoot = true;
                    timeToFire = Time.time + 1f / bulletPrefab.GetComponent<Bullet>().fireRate;
                    Shoot();
                }
                break;

            case ShootMode.IceBolt:
                if (!hasShoot && !isIceCool)
                {
                    // Debug.Log("IceBolt : " + hasShoot.ToString());
                    hasShoot = true;
                    timeToFire = Time.time + 1f / bulletPrefab.GetComponent<Bullet>().fireRate;
                    Shoot();
                    StartCoroutine(IceBolt());
                }
                break;
        }
    }

    // Method to put in the Event when the gesture are not recognized
    public void StopShoot()
    {
        hasShoot = false;
    }

    public void explosionSkillOn() {
        if (!isSkillOn) {
            StartCoroutine(SkillDuring());
            isSkillOn = true;
        }
    }

    private void Shoot()
    {
        // In the End we will going to shoot a bullet
        GameObject bullet = Instantiate(bulletPrefab, hand.position, Quaternion.identity);
        bullet.transform.localRotation = hand.rotation;
        gameObject.GetComponent<AudioSource>().Stop();
        gameObject.GetComponent<AudioSource>().Play();
        
    }

    IEnumerator SkillDuring() {
        bulletPrefab.GetComponent<Bullet>().IsOnSkill = true;
        bulletPrefab.GetComponent<Bullet>().fireRate *= 2.0f;
        yield return new WaitForSeconds(RunningTime);
        bulletPrefab.GetComponent<Bullet>().IsOnSkill = false;
        bulletPrefab.GetComponent<Bullet>().fireRate *= 0.5f;
        isSkillOn = false;
    }

    IEnumerator IceBolt() {
        isIceCool = true;
        yield return new WaitForSeconds(5.0f);
        isIceCool = false;
    }

}
