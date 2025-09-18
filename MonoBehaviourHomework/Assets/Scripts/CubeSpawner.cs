using System.Collections;
using UnityEngine;


public class CubeSpawner : MonoBehaviour
{

    [SerializeField] private CubeRotator cubeRotator;
    [SerializeField] private ControlCubePosition cubePositionController;
    [SerializeField] private CubeLayout cubeLayout;

    [SerializeField] private Transform center;
    [SerializeField] private GameObject cubeToCopy;
    private float radius;


    [SerializeField] private int cubeCount;
    private float angleStep;


    void Awake()
    {
        if (AreDependenciesValid())
        {
            TypeLayout typeLayout = cubeLayout.GetTypeSpawn();

            if (typeLayout == TypeLayout.Evenly)
                angleStep = 360f / cubeCount;
            else
                angleStep = cubeLayout.GetAngleBetweenCubes();
            radius = cubeRotator.GetRotationRadius();
            Debug.Log($"Шаг: {angleStep}");
            for (int i = 0; i < cubeCount; i++)
            {
                Debug.Log(
                    $"Угл:{i * angleStep} Синус: {Mathf.Sin(i * angleStep * Mathf.Deg2Rad)} Косинус:{Mathf.Cos(i * angleStep * Mathf.Deg2Rad)}");
                float oX = Mathf.Sin(i * angleStep * Mathf.Deg2Rad) * radius;
                float oZ = Mathf.Cos(i * angleStep * Mathf.Deg2Rad) * radius;
                Vector3 deltaVector = new Vector3(oX, 0, oZ);
                Vector3 currentCubePosition = center.position + deltaVector;

                GameObject cube = Instantiate(cubeToCopy, currentCubePosition, Quaternion.identity, center);
                cubePositionController.AddCube(cube.transform);
            }
        }
    }

    private bool AreDependenciesValid()
    {
        bool valid = true;

        if (cubeRotator == null)
        {
            Debug.LogWarning("cubeRotator is null");
            valid = false;
        }

        if (cubeToCopy == null)
        {
            Debug.LogWarning("cubeToCopy is null");
            valid = false;
        }

        if (center == null)
        {
            Debug.LogWarning("center is null");
            valid = false;
        }

        if (cubePositionController == null)
        {
            Debug.LogWarning("cubePositionController is null");
            valid = false;
        }

        if (cubeLayout == null)
        {
            Debug.LogWarning("cubeLayout is null");
            valid = false;
        }

        return valid;
    }
}