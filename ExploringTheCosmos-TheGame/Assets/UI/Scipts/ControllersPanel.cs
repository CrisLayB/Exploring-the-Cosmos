using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllersPanel : MonoBehaviour
{
    // title
    [SerializeField] GameObject title;
    [SerializeField] GameObject text;

    // background
    [SerializeField] GameObject backgroundlines;
    [SerializeField] GameObject background;
    RectTransform backgroundRT;
    Vector2 backgroundSize;

    // bts
    [SerializeField] GameObject btn_0;
    RectTransform btnRT_0;
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

        title.SetActive(false);
        text.SetActive(false);
    }

    public IEnumerator PopUpMenu()
    {
        title.SetActive(false);
        text.SetActive(false);

        // LeanTween.size(background.GetComponent<RectTransform>(), backgroundSize, 0.5f).setEase(LeanTweenType.easeOutBack);
        backgroundRT.LeanSize(backgroundSize, 0.3f).setEase(LeanTweenType.easeInCubic);
        yield return new WaitForSeconds(0.4f);
        backgroundlines.SetActive(true);
        title.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        text.SetActive(true);

        

    }

    // Update is called once per frame
    public IEnumerator PopDownMenu()
    {
        title.SetActive(false);
        text.SetActive(false);

        yield return new WaitForSeconds(0.4f);

        backgroundRT.LeanSize(new Vector2(0, 0), 0.2f).setEase(LeanTweenType.easeInCubic);

        yield return new WaitForSeconds(0.2f);

        gameObject.SetActive(false);
    }
}
