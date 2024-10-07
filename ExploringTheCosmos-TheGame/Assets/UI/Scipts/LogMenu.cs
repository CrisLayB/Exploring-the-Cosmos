using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogMenu : MonoBehaviour
{
    // title
    [SerializeField] GameObject title;

    // background
    [SerializeField] GameObject backgroundlines;
    [SerializeField] GameObject background;
    RectTransform backgroundRT;
    Vector2 backgroundSize;
    
    // bts
    [SerializeField] GameObject btn_0;
    [SerializeField] GameObject btn_1;
    [SerializeField] GameObject btn_2;
    [SerializeField] GameObject btn_3;
    [SerializeField] GameObject btn_4;

    RectTransform btnRT_0;
    RectTransform btnRT_1;
    RectTransform btnRT_2;
    RectTransform btnRT_3;
    RectTransform btnRT_4;
    Color btnTextColor;
    Color full;
    Color transparent;
    TextMeshProUGUI btnText;
    Vector2 btnSize;
    
    void Awake() {

        // set up del fondo
        backgroundRT = background.GetComponent<RectTransform>();
        if (backgroundRT == null) {
            Debug.LogError("ERRRR");
        }
        backgroundSize = backgroundRT.sizeDelta;
        Debug.Log(backgroundSize);
        backgroundRT.sizeDelta = new Vector2(0, 0);

        backgroundlines.SetActive(false);


        // set up de los botones
        btnRT_0 = btn_0.GetComponent<RectTransform>();
        btnRT_1 = btn_1.GetComponent<RectTransform>();
        btnRT_2 = btn_2.GetComponent<RectTransform>();
        btnRT_3 = btn_3.GetComponent<RectTransform>();
        btnRT_4 = btn_4.GetComponent<RectTransform>();
        btnSize = btnRT_1.sizeDelta; // todos los botones tienen el mismo tamaño
        btnRT_0.sizeDelta = new Vector2(0, 0);
        btnRT_1.sizeDelta = new Vector2(0, 0);
        btnRT_2.sizeDelta = new Vector2(0, 0);
        btnRT_3.sizeDelta = new Vector2(0, 0);
        btnRT_4.sizeDelta = new Vector2(0, 0);
        // textos
        btnText = btn_0.GetComponentInChildren<TextMeshProUGUI>();
        btnTextColor = btnText.color;
        full = btnTextColor;
        transparent = btnTextColor;
        transparent.a = 0f;  // Make fully transparent
        btnText.color = transparent;
        btnText = btnRT_1.GetComponentInChildren<TextMeshProUGUI>();
        btnText.color = transparent;
        btnText = btnRT_2.GetComponentInChildren<TextMeshProUGUI>();
        btnText.color = transparent;
        btnText = btnRT_3.GetComponentInChildren<TextMeshProUGUI>();
        btnText.color = transparent;
        btnText = btnRT_4.GetComponentInChildren<TextMeshProUGUI>();
        btnText.color = transparent;

        title.SetActive(false);
    }


    public IEnumerator PopUpMenu() {
        // evitar mostrar mal los textos y los botones 
        btnText = btn_0.GetComponentInChildren<TextMeshProUGUI>();
        btnText.color = transparent;
        btnText = btnRT_1.GetComponentInChildren<TextMeshProUGUI>();
        btnText.color = transparent;
        btnText = btnRT_2.GetComponentInChildren<TextMeshProUGUI>();
        btnText.color = transparent;
        btnText = btnRT_3.GetComponentInChildren<TextMeshProUGUI>();
        btnText.color = transparent;
        btnText = btnRT_4.GetComponentInChildren<TextMeshProUGUI>();
        btnText.color = transparent;
        btnRT_0.sizeDelta = new Vector2(0, 0);
        btnRT_1.sizeDelta = new Vector2(0, 0);
        btnRT_2.sizeDelta = new Vector2(0, 0);
        btnRT_3.sizeDelta = new Vector2(0, 0);
        btnRT_4.sizeDelta = new Vector2(0, 0);
        
        // LeanTween.size(background.GetComponent<RectTransform>(), backgroundSize, 0.5f).setEase(LeanTweenType.easeOutBack);
        backgroundRT.LeanSize(backgroundSize, 0.2f).setEase(LeanTweenType.easeInCubic);
        yield return new WaitForSeconds(0.3f);
        backgroundlines.SetActive(true);
        title.SetActive(true);

        btnRT_0.LeanSize(btnSize, 0.2f).setEase(LeanTweenType.easeInCubic);
        yield return new WaitForSeconds(0.2f);
        btnText = btn_0.GetComponentInChildren<TextMeshProUGUI>();
        btnTextColor = btnText.color;
        btnText.color = full;

        btnRT_1.LeanSize(btnSize, 0.2f).setEase(LeanTweenType.easeInCubic);
        yield return new WaitForSeconds(0.2f);
        btnText = btn_1.GetComponentInChildren<TextMeshProUGUI>();
        btnTextColor = btnText.color;
        btnText.color = full;

        btnRT_2.LeanSize(btnSize, 0.2f).setEase(LeanTweenType.easeInCubic);
        yield return new WaitForSeconds(0.2f);
        btnText = btn_2.GetComponentInChildren<TextMeshProUGUI>();
        btnTextColor = btnText.color;
        btnText.color = full;

        btnRT_3.LeanSize(btnSize, 0.2f).setEase(LeanTweenType.easeInCubic);
        yield return new WaitForSeconds(0.2f);
        btnText = btn_3.GetComponentInChildren<TextMeshProUGUI>();
        btnTextColor = btnText.color;
        btnText.color = full;

        btnRT_4.LeanSize(btnSize, 0.2f).setEase(LeanTweenType.easeInCubic);
        yield return new WaitForSeconds(0.2f);
        btnText = btn_4.GetComponentInChildren<TextMeshProUGUI>();
        btnTextColor = btnText.color;
        btnText.color = full;

    }

    public IEnumerator PopDownMenu() {
        btnRT_0.LeanSize(new Vector2(0,0), 0.2f).setEase(LeanTweenType.easeInCubic);
        btnText = btn_0.GetComponentInChildren<TextMeshProUGUI>();
        btnTextColor = btnText.color;
        btnText.color = transparent;

        btnRT_1.LeanSize(new Vector2(0,0), 0.2f).setEase(LeanTweenType.easeInCubic);
        btnText = btn_1.GetComponentInChildren<TextMeshProUGUI>();
        btnTextColor = btnText.color;
        btnText.color = transparent;

        btnRT_2.LeanSize(new Vector2(0,0), 0.2f).setEase(LeanTweenType.easeInCubic);
        btnText = btn_2.GetComponentInChildren<TextMeshProUGUI>();
        btnTextColor = btnText.color;
        btnText.color = transparent;

        btnRT_3.LeanSize(new Vector2(0,0), 0.2f).setEase(LeanTweenType.easeInCubic);
        btnText = btn_3.GetComponentInChildren<TextMeshProUGUI>();
        btnTextColor = btnText.color;
        btnText.color = transparent;

        btnRT_4.LeanSize(new Vector2(0,0), 0.2f).setEase(LeanTweenType.easeInCubic);
        btnText = btn_4.GetComponentInChildren<TextMeshProUGUI>();
        btnTextColor = btnText.color;
        btnText.color = transparent;

        backgroundlines.SetActive(false);
        title.SetActive(false);
        yield return new WaitForSeconds(0.4f);

        backgroundRT.LeanSize(new Vector2(0, 0), 0.2f).setEase(LeanTweenType.easeInCubic);

        yield return new WaitForSeconds(0.2f);

        gameObject.SetActive(false);

    }

    public void GoToEntry() {
        
    }

    
}
