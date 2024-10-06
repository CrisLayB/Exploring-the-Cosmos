using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInfo : MonoBehaviour
{
    // text
    [SerializeField] GameObject text;

    // background
    [SerializeField] GameObject backgroundlines;
    [SerializeField] GameObject background;
    RectTransform backgroundRT;
    Vector2 backgroundSize;
    void Awake()
    {
        // set up del fondo
        backgroundRT = background.GetComponent<RectTransform>();
        if (backgroundRT == null) {
            Debug.LogError("ERRRR");
        }
        backgroundSize = backgroundRT.sizeDelta;
        Debug.Log(backgroundSize);
        backgroundRT.sizeDelta = new Vector2(0, 0);

        backgroundlines.SetActive(false);
    }

    public IEnumerator PopUpMenu() {
        // LeanTween.size(background.GetComponent<RectTransform>(), backgroundSize, 0.5f).setEase(LeanTweenType.easeOutBack);
        backgroundRT.LeanSize(backgroundSize, 0.3f).setEase(LeanTweenType.easeInCubic);
        yield return new WaitForSeconds(0.3f);
        backgroundlines.SetActive(true);
        text.SetActive(true);
    }

    public IEnumerator PopDownMenu() {
        backgroundlines.SetActive(false);
        text.SetActive(false);
        yield return new WaitForSeconds(0.2f);

        backgroundRT.LeanSize(new Vector2(0, 0), 0.3f).setEase(LeanTweenType.easeInCubic);

        yield return new WaitForSeconds(0.3f);

        gameObject.SetActive(false);
    }


}
