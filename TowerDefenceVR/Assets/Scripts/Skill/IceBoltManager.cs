using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBoltManager : MonoBehaviour
{
    [Header("SpawnTransform")]
    public Transform hand;

    [Header("BulletPrefab")]
    [SerializeField] GameObject bulletPrefab;


    public enum ShootMode
    {
        IceBolt,
        Single
    }

    [Header("ShootMethod")]
    public ShootMode shootMode;

    private bool hasShoot = false;
    private float timeToFire = 0f;

    [System.NonSerialized] public bool isSkillOn = false;
    [System.NonSerialized] public float RunningTime;

    public void OnShoot()
    {
        // Switch between the to modes
        switch (shootMode)
        {
            case ShootMode.IceBolt:
                if (Time.time >= timeToFire)
                {
                    timeToFire = Time.time + 3f / bulletPrefab.GetComponent<Bullet>().fireRate;
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
        }
    }

    // Method to put in the Event when the gesture are not recognized
    public void StopShoot()
    {
        hasShoot = false;
    }

    public void explosionSkillOn()
    {
        if (!isSkillOn)
        {
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

    IEnumerator SkillDuring()
    {
        bulletPrefab.GetComponent<Bullet>().IsOnSkill = true;
        bulletPrefab.GetComponent<Bullet>().fireRate *= 2.0f;
        yield return new WaitForSeconds(RunningTime);
        bulletPrefab.GetComponent<Bullet>().IsOnSkill = false;
        bulletPrefab.GetComponent<Bullet>().fireRate *= 0.5f;
        isSkillOn = false;
    }

}
