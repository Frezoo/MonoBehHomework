using System.Collections;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private CubeRotator cubeRotator;
    
    [SerializeField] private Transform center;
    [SerializeField] private GameObject cubeToCopy;
    private float radius;

    [SerializeField] private int cubeCount;
    private float angleStep;

    void Awake()
    {
        CheckNulls();

        angleStep = 360f / cubeCount;
        radius = cubeRotator.GetRotationRadius();
        Debug.Log($"Шаг: {angleStep}");
        for (int i = 0; i < cubeCount; i++)
        {
            Debug.Log($"Угл:{i * angleStep} Синус: {Mathf.Sin(i * angleStep * Mathf.Deg2Rad)} Косинус:{Mathf.Cos(i * angleStep * Mathf.Deg2Rad)}");
            float oX = Mathf.Sin(i * angleStep * Mathf.Deg2Rad) * radius;
            float oZ = Mathf.Cos(i * angleStep * Mathf.Deg2Rad) * radius;
            Vector3 deltaVector = new Vector3(oX, 0, oZ);
            Vector3 currentCubePosition = center.position + deltaVector;

            Instantiate(cubeToCopy, currentCubePosition, Quaternion.identity, center);


        }
    }

    private void CheckNulls()
    {
        if (cubeRotator == null)
        {
            Debug.LogWarning("cubeRotator is null");
        }

        if (cubeToCopy == null)
        {
            Debug.LogWarning("cubeToCopy is null");
        }
    }
}
  
