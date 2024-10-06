using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    // title
    [SerializeField] GameObject title;

    // background
    [SerializeField] GameObject backgroundlines;
    [SerializeField] GameObject background;
    RectTransform backgroundRT;
    Vector2 backgroundSize;
    
    // bts
    [SerializeField] GameObject btn_resume;
    [SerializeField] GameObject btn_options;
    [SerializeField] GameObject btn_quit;

    RectTransform btnRT_resume;
    RectTransform btnRT_options;
    RectTransform btnRT_quit;
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
        btnRT_resume = btn_resume.GetComponent<RectTransform>();
        btnRT_options = btn_options.GetComponent<RectTransform>();
        btnRT_quit = btn_quit.GetComponent<RectTransform>();
        btnSize = btnRT_options.sizeDelta; // todos los botones tienen el mismo tamaño
        btnRT_resume.sizeDelta = new Vector2(0, 0);
        btnRT_options.sizeDelta = new Vector2(0, 0);
        btnRT_quit.sizeDelta = new Vector2(0, 0);
        // textos
        btnText = btn_resume.GetComponentInChildren<TextMeshProUGUI>();
        btnTextColor = btnText.color;
        full = btnTextColor;
        transparent = btnTextColor;
        transparent.a = 0f;  // Make fully transparent
        btnText.color = transparent;
        btnText = btnRT_options.GetComponentInChildren<TextMeshProUGUI>();
        btnText.color = transparent;
        btnText = btnRT_quit.GetComponentInChildren<TextMeshProUGUI>();
        btnText.color = transparent;

        title.SetActive(false);
    }


    public IEnumerator PopUpMenu() {
        // evitar mostrar mal los textos y los botones 
        btnText = btn_resume.GetComponentInChildren<TextMeshProUGUI>();
        btnText.color = transparent;
        btnText = btnRT_options.GetComponentInChildren<TextMeshProUGUI>();
        btnText.color = transparent;
        btnText = btnRT_quit.GetComponentInChildren<TextMeshProUGUI>();
        btnText.color = transparent;
        btnRT_resume.sizeDelta = new Vector2(0, 0);
        btnRT_options.sizeDelta = new Vector2(0, 0);
        btnRT_quit.sizeDelta = new Vector2(0, 0);
        
        // LeanTween.size(background.GetComponent<RectTransform>(), backgroundSize, 0.5f).setEase(LeanTweenType.easeOutBack);
        backgroundRT.LeanSize(backgroundSize, 0.2f).setEase(LeanTweenType.easeInCubic);
        yield return new WaitForSeconds(0.3f);
        backgroundlines.SetActive(true);
        title.SetActive(true);

        btnRT_resume.LeanSize(btnSize, 0.2f).setEase(LeanTweenType.easeInCubic);
        yield return new WaitForSeconds(0.2f);
        btnText = btn_resume.GetComponentInChildren<TextMeshProUGUI>();
        btnTextColor = btnText.color;
        btnText.color = full;

        btnRT_options.LeanSize(btnSize, 0.2f).setEase(LeanTweenType.easeInCubic);
        yield return new WaitForSeconds(0.2f);
        btnText = btn_options.GetComponentInChildren<TextMeshProUGUI>();
        btnTextColor = btnText.color;
        btnText.color = full;

        btnRT_quit.LeanSize(btnSize, 0.2f).setEase(LeanTweenType.easeInCubic);
        yield return new WaitForSeconds(0.2f);
        btnText = btn_quit.GetComponentInChildren<TextMeshProUGUI>();
        btnTextColor = btnText.color;
        btnText.color = full;

        
    }

    public IEnumerator PopDownMenu() {
        btnRT_resume.LeanSize(new Vector2(0,0), 0.2f).setEase(LeanTweenType.easeInCubic);
        btnText = btn_resume.GetComponentInChildren<TextMeshProUGUI>();
        btnTextColor = btnText.color;
        btnText.color = transparent;

        btnRT_options.LeanSize(new Vector2(0,0), 0.2f).setEase(LeanTweenType.easeInCubic);
        btnText = btn_options.GetComponentInChildren<TextMeshProUGUI>();
        btnTextColor = btnText.color;
        btnText.color = transparent;

        btnRT_quit.LeanSize(new Vector2(0,0), 0.2f).setEase(LeanTweenType.easeInCubic);
        btnText = btn_quit.GetComponentInChildren<TextMeshProUGUI>();
        btnTextColor = btnText.color;
        btnText.color = transparent;

        backgroundlines.SetActive(false);
        title.SetActive(false);
        yield return new WaitForSeconds(0.4f);

        backgroundRT.LeanSize(new Vector2(0, 0), 0.5f).setEase(LeanTweenType.easeInCubic);

        yield return new WaitForSeconds(0.3f);

        gameObject.SetActive(false);

    }

    
}
