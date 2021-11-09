using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRemains : MonoBehaviour
{
    public ParticleSystem particles;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent == null)
        {
            particles.Stop();
            Destroy(gameObject, 5f);
        }
    }
}
