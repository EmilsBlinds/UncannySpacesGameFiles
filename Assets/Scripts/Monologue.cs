using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Monologue : MonoBehaviour
{
    public Text textElement;
    public float displayDuration = 7.0f;

    void Start()
    {
        StartCoroutine(DisplayText());
    }

    IEnumerator DisplayText()
    {
        textElement.enabled = true;

        yield return new WaitForSeconds(displayDuration);

        textElement.enabled = false;
    }
}
