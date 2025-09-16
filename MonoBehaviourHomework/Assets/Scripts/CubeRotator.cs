using UnityEngine;

public class CubeRotator : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float rotationRadius;
    void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }

    public float GetRotationRadius()
    {
        return rotationRadius;
    }
}
