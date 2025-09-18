using UnityEngine;
using System.Collections;


public class RainbowEffect : MonoBehaviour
{
    [SerializeField] private Material materialToWork;


    [SerializeField] private float transitionDuration = 2.0f;
    [SerializeField] private float delayBetweenTransitions = 0.5f;


    private void Start()
    {
        if (AreDependenciesValid())
            StartCoroutine(ChangeColorCoroutine());
    }

    private IEnumerator ChangeColorCoroutine()
    {
        while (true)
        {
            Color targetColor = Random.ColorHSV(0f, 1f, 0.7f, 1f, 0.8f, 1f);


            float elapsedTime = 0f;
            Color startColor = materialToWork.color;

            while (elapsedTime < transitionDuration)
            {
                materialToWork.color = Color.Lerp(startColor, targetColor, elapsedTime / transitionDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            
            materialToWork.color = targetColor;


            yield return new WaitForSeconds(delayBetweenTransitions);
        }
    }

    private bool AreDependenciesValid()
    {
        bool valid = true;

        if (materialToWork == null)
        {
            Debug.LogWarning("material is null");
            valid = false;
        }

        return valid;
    }
}