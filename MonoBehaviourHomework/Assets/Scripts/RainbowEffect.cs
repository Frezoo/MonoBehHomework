using UnityEngine;
using System.Collections;

public class RainbowEffect : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private float transitionDuration = 2.0f; 
    [SerializeField] private float delayBetweenTransitions = 0.5f; 

    private void Start()
    {
        if (meshRenderer == null)
        {
            Debug.LogWarning("MeshRenderer is null");
        }
        StartCoroutine(ChangeColorCoroutine());
    }

    private IEnumerator ChangeColorCoroutine()
    {
        while (true)
        {
            
            Color targetColor = Random.ColorHSV(0f, 1f, 0.7f, 1f, 0.8f, 1f);

         
            float elapsedTime = 0f;
            Color startColor = meshRenderer.material.color;

            while (elapsedTime < transitionDuration)
            {
                meshRenderer.material.color = Color.Lerp(startColor, targetColor, elapsedTime / transitionDuration);
                elapsedTime += Time.deltaTime;
                yield return null; 
            }
            
            meshRenderer.material.color = targetColor;
            yield return new WaitForSeconds(delayBetweenTransitions);
        }
    }
}