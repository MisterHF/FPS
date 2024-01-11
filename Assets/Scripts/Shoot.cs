using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public ParticleSystem FireParticules;
    public Transform FirePoint;
    public GameObject Fire;
    // public GameObject HitPoint;
    

    private void Start()
    {
        FireParticules.Stop();
    }

    void Update()
    {
       if (Input.GetMouseButtonDown(0))
       {
            Shooting();
            
            
            
        }
        
        
        

    }

    public void Shooting()
    {
        FireParticules.Stop();
        FireParticules.Play();

        RaycastHit hit;

        if(Physics.Raycast(FirePoint.position, Camera.main.transform.forward, out hit, 200))
        {
            Debug.DrawRay(FirePoint.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            Debug.Log(hit.collider.name);

            if (hit.collider.CompareTag("Enemy"))
            {
                
                Destroy(hit.collider.gameObject);
                ScoreManager.Instance.AddPoint();
            }

            
           // Instantiate(HitPoint, hit.point, Quaternion.identity);
        }
    }
    public void ClearOldParticles()
    {
        ParticleSystem[] particles = FindObjectsOfType<ParticleSystem>();

        foreach (ParticleSystem particle in particles)
        {
            if (particle.isPlaying)
            {
                float duration = particle.main.duration + particle.main.startLifetime.constant;
                Destroy(particle.gameObject, duration);
            }
        }
    }
}
