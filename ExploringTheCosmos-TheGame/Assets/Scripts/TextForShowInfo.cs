using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextForShowInfo : MonoBehaviour
{
    [SerializeField] private TextInfo _textInfo;
    private TextMeshProUGUI _textVisitinPlanet;

    void Start()
    {
        if(_textInfo != null)
        {
            _textVisitinPlanet = _textInfo.GetComponentInChildren<TextMeshProUGUI>();
        }

        if(_textVisitinPlanet != null)
        {
            _textVisitinPlanet.text = $"";
        }
    }

    public void ShowText(string message)
    {
        _textVisitinPlanet.text = message;
        _textInfo.gameObject.SetActive(true);
        StartCoroutine(_textInfo.PopUpMenu());
    }

    public void HideText()
    {
        StartCoroutine(_textInfo.PopDownMenu());
        _textVisitinPlanet.text = $"";
    }    
}
