using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Tests : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] GameObject pauseMenuGO;
    PauseMenu pauseMenu;

    [SerializeField] GameObject textInfoGO;
    TextInfo textInfo;

    

    void Start()
    {
        pauseMenuGO.SetActive(false);
        textInfoGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape)) {
            pauseMenu = pauseMenuGO.GetComponent<PauseMenu>();
            if (pauseMenuGO.activeSelf) {

                StartCoroutine(pauseMenu.PopDownMenu());

            } else {
                pauseMenuGO.SetActive(true);
                StartCoroutine(pauseMenu.PopUpMenu());
            }
        }

        if (Input.GetKeyDown(KeyCode.T)) {
            textInfo = textInfoGO.GetComponent<TextInfo>();
            if (textInfoGO.activeSelf) {
                StartCoroutine(textInfo.PopDownMenu());

            } else {
                textInfoGO.SetActive(true);
                StartCoroutine(textInfo.PopUpMenu());
            }

        }
    }
}
