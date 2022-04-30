using UnityEngine;

public class Bullet : MonoBehaviour
{
    //�Ѿ� ���ǵ�
    public float speed = 20f;

    //�Ѿ� �����
    public float fireRate = 1f;

    // 
    public float timeBeforeDestroyed = 5f;

    private bool collided = false;

    private Rigidbody rb = null;

    [Header("BulletDamage")]
    [SerializeField] private int Damage;

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
            Destroy(gameObject);
        }
    }
}