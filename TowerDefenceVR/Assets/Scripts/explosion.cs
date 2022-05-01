using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    private ParticleSystem explosionPs;
    // Start is called before the first frame update
    void Start()
    {
        explosionPs = gameObject.GetComponent<ParticleSystem>();
        Destroy(gameObject, 1.0f);
        explosionPs.Stop();
        explosionPs.Play();
        gameObject.GetComponent<AudioSource>().Stop();
        gameObject.GetComponent<AudioSource>().Play();
    }

}
