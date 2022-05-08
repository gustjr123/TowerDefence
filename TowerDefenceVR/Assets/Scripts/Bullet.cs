using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Bullet Speed
    public float speed = 20f;

    // ShootRate
    public float fireRate = 1f;

    // Destroyed Time after Shooting. for other words, life time for bullet
    public float timeBeforeDestroyed = 5f;

    private bool collided = false;

    private Rigidbody rb = null;

    [Header("BulletDamage")]
    [SerializeField] private int Damage;
    [Header("Explosion skill")]
    [SerializeField] private GameObject explosion;

    [Header("Skill On/Off")]
    public bool OnExplosion;

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
        if (co.gameObject.tag != "Bullet" && !collided)
        {
            collided = true;
            speed = 0;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("enemyBug")) {
            // Damage to Enemy
            other.gameObject.GetComponent<Drone>().GetDamage(Damage);
            // skill
            if (OnExplosion) {
                Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            }

            Destroy(gameObject);
        }
    }
}