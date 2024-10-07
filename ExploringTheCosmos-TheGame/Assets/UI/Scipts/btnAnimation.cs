using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class btnAnimation : MonoBehaviour
{
    TextMeshProUGUI btnText;
    RectTransform rectTransform;

    Color transparent;
    Color full;

    Vector2 originalSize;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        btnText = GetComponentInChildren<TextMeshProUGUI>();
        originalSize = rectTransform.sizeDelta;
        rectTransform.sizeDelta = new Vector2(0, 0);

        transparent = btnText.color;
        full = btnText.color;

        transparent.a = 0f;
        btnText.color = transparent;

        StartCoroutine(Animation());

    }

    public IEnumerator Animation() {
        yield return new WaitForSeconds(0.2f);
        rectTransform.LeanSize(originalSize, 0.4f).setEase(LeanTweenType.easeInCubic);

        yield return new WaitForSeconds(0.45f);    
        btnText.color = full;
    }
}
