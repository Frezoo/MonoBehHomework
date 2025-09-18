using System;
using UnityEngine;

public class CubeRotator : MonoBehaviour
{
    enum RotationDirection
    {
        Clockwise,
        CounterClockwise
    }
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float rotationRadius;
    [SerializeField] private RotationDirection direction;

    

    private void Awake()
    {
        GetRotationSpeed();
    }

    

    void Update()
    {
        transform.Rotate(Vector3.up, GetRotationSpeed() * Time.deltaTime);
    }

    public float GetRotationRadius()
    {
        return rotationRadius;
    }
    private float GetRotationSpeed()
    {
        if (direction == RotationDirection.Clockwise)
        {
            return Mathf.Abs(rotateSpeed);
        }
        else
        {
            return -Mathf.Abs(rotateSpeed); 
        }
    }
}
