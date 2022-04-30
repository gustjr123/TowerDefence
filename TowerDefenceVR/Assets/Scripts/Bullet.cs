using UnityEngine;

public class Bullet : MonoBehaviour
{
    //ÃÑ¾Ë ½ºÇÇµå
    public float speed = 20f;

    //ÃÑ¾Ë ¿¬»ç·Â
    public float fireRate = 1f;

    // 
    public float timeBeforeDestroyed = 5f;

    private bool collided = false;

    private Rigidbody rb = null;

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
}