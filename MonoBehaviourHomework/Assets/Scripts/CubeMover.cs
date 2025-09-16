using UnityEngine;

public class CubeMover : MonoBehaviour
{
    [SerializeField] private Vector3 speedVector;
    [SerializeField] private float speedMultiplier;

    void Awake()
    {
        speedVector *= speedMultiplier;
    }

    void Update()
    {
        
        transform.Translate(speedVector * Time.deltaTime,Space.World);
    }
}
