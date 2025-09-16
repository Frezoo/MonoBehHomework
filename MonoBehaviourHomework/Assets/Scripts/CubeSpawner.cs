using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Transform center;
    [SerializeField] private GameObject cubeToCopy;
    [SerializeField] private float radius;

    [SerializeField] private int cubeCount;
    private float angleStep;

    void Awake()
    {
        angleStep = 360f / cubeCount;
        Debug.Log($"Шаг: {angleStep}");
        for (int i = 0; i < cubeCount; i++)
        {
            Debug.Log($"Угл:{i * angleStep} Синус: { Mathf.Sin(i * angleStep * Mathf.Deg2Rad)} Косинус:{Mathf.Cos(i * angleStep * Mathf.Deg2Rad)}");
            float oX = Mathf.Sin(i * angleStep * Mathf.Deg2Rad) * radius;
            float oZ = Mathf.Cos(i * angleStep * Mathf.Deg2Rad) * radius;
            Vector3 deltaVector = new Vector3(oX, 0, oZ);
            Debug.Log($"{deltaVector} {deltaVector.magnitude}");
            Vector3 currentCubePosition = center.position + deltaVector;
            
            Instantiate(cubeToCopy, currentCubePosition, Quaternion.identity,center);
            
        }
    }
    
}
