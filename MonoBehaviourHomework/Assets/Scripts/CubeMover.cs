using UnityEngine;

public class CubeMover : MonoBehaviour
{
    [SerializeField] private Vector3 speedVector;
    
    

    void Update()
    {
        transform.Translate(speedVector * Time.deltaTime,Space.World);
    }
}
