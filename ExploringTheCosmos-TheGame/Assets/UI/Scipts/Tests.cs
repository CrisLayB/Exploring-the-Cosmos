using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Tests : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] GameObject pauseMenuGO;
    PauseMenu pauseMenu;

    [SerializeField] GameObject logMenuGO;
    LogMenu logMenu;

    [SerializeField] GameObject controllersPanelGO;
    ControllersPanel controllersPanel;

    

    void Start()
    {
        pauseMenuGO.SetActive(false);
        logMenuGO.SetActive(false);
        controllersPanelGO.SetActive(false);
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

        if (Input.GetKeyDown(KeyCode.L)) {
            logMenu = logMenuGO.GetComponent<LogMenu>();
            if (logMenuGO.activeSelf) {
                StartCoroutine(logMenu.PopDownMenu());

            } else {
                logMenuGO.SetActive(true);
                StartCoroutine(logMenu.PopUpMenu());
            }

        }

        if (Input.GetKeyDown(KeyCode.C)) {
            controllersPanel = controllersPanelGO.GetComponent<ControllersPanel>();
            if (controllersPanelGO.activeSelf) {
                StartCoroutine(controllersPanel.PopDownMenu());

            } else {
                controllersPanelGO.SetActive(true);
                StartCoroutine(controllersPanel.PopUpMenu());
            }

        }
    }
}
