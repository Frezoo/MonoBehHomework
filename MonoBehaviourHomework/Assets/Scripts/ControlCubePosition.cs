using System;
using System.Collections.Generic;
using UnityEngine;

public class ControlCubePosition : MonoBehaviour
{
    private List<Transform> cubes = new List<Transform>();
    
    [SerializeField] private CubeRotator cubeRotator;
    private CubeSpawner cubeSpawner;
    private CubeLayout cubeLayout;
    
    private float angleStep;

    private void Awake()
    {
        cubeSpawner = GetComponent<CubeSpawner>();
        cubeLayout = GetComponent<CubeLayout>();
       
    }

    void Update()
    {
        if (!AreDependenciesValid())
            return;
        if (cubeLayout.GetTypeSpawn() == TypeLayout.Evenly)
        {
            angleStep = 360f / cubes.Count;
        }
        else
        {
            angleStep = cubeLayout.GetAngleBetweenCubes();
        }
            
        for(int i = 0; i < cubes.Count; i++)
        {
            float oX = Mathf.Sin(i * angleStep * Mathf.Deg2Rad) * cubeRotator.GetRotationRadius();
            float oZ = Mathf.Cos(i * angleStep * Mathf.Deg2Rad) * cubeRotator.GetRotationRadius();
            cubes[i].localPosition = new Vector3(oX, 0, oZ);
        }
    }

    public void AddCube(Transform cube)
    {
        cubes.Add(cube);
    }
    
    private bool AreDependenciesValid()
    {
        bool valid = true;

        if (cubeRotator == null)
        {
            Debug.LogWarning("cubeRotator is null");
            valid = false;
        }
        if (cubeSpawner == null)
        {
            Debug.LogWarning("cubeSpawner is null");
            valid = false;
        }
        if(cubeLayout == null)
        {
            Debug.LogWarning("cubeLayout is null");
            valid = false;
        }

        return valid;
    }
}
