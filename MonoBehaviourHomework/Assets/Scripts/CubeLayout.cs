using UnityEngine;

public enum TypeLayout
{
    Evenly,
    consistently
}

public class CubeLayout : MonoBehaviour
{
    [SerializeField] private TypeLayout typeLayout = TypeLayout.Evenly;
    [Tooltip("Если вы выбрали последовательный спавн, то укажите угол между кубами:")]
    [Range(20, 180)]
    [SerializeField] private float angleBetweenCubes;
    
    public TypeLayout GetTypeSpawn()
    {
        return typeLayout;
    }

    public float GetAngleBetweenCubes()
    {
        return angleBetweenCubes;
    }
}
