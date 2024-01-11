using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTraget : MonoBehaviour
{
    ScoreManager scoreManager;
    [SerializeField] public GameObject target;
    [SerializeField] private GameObject MapSurface;

    int MaxTarget = 50;
    bool TargetCreated = false;


    private void Start()
    {
        CreateTarget();
    }
    private void CreateTarget()
    {
        if (TargetCreated == false)
        {
            for (int i = 0; i < MaxTarget; i++)
            {
                GameObject newObstacle = Instantiate(target, MapSurface.transform.position + new Vector3(Random.Range(0, 100), Random.Range (2.52f, 20f), Random.Range(0, 100)), Quaternion.identity);

            }
            TargetCreated = true;
        }
    }

    //private void Update()
    //{
    //    if (MaxTarget == scoreManager)
    //}
}
