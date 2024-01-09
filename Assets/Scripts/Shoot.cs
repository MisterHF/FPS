using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject Fire;
    public GameObject HitPoint;
    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButtonDown(0))
       {
            Shooting();
            
        }
        
    }

    public void Shooting()
    {
        RaycastHit hit;

        if(Physics.Raycast(FirePoint.position, transform.TransformDirection(Vector3.forward), out hit, 100))
        {
            Debug.DrawRay(FirePoint.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);


            Instantiate(Fire, FirePoint.position, Quaternion.identity);
            Instantiate(HitPoint, hit.point, Quaternion.identity);
        }
    }
}
