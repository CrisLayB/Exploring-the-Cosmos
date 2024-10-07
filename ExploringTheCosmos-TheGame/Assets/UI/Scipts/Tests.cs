using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


public class Tests : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] GameObject pauseMenuGO;
    PauseMenu pauseMenu;

    [SerializeField] GameObject logMenuGO;
    LogMenu logMenu;

    [SerializeField] GameObject controllersPanelGO;
    ControllersPanel controllersPanel;

    [SerializeField] GameObject controllerBtn;
    [SerializeField] GameObject exitControllerBtn;
    [SerializeField] GameObject logBtn;


    

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

        if (Input.GetKeyDown(KeyCode.Tab)) {
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

    public void OpenControllers() {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(controllerBtn);
        controllersPanel = controllersPanelGO.GetComponent<ControllersPanel>();
        controllersPanelGO.SetActive(true);
        StartCoroutine(controllersPanel.PopUpMenu());
    }

    public void CloseControllers() {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(controllerBtn);
        controllersPanel = controllersPanelGO.GetComponent<ControllersPanel>();
        StartCoroutine(controllersPanel.PopDownMenu());
        
    }

    public void openLogs() {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(controllerBtn);
        logMenu = logMenuGO.GetComponent<LogMenu>();
        logMenuGO.SetActive(true);
        StartCoroutine(logMenu.PopUpMenu());
    }

    public void closeLogs() {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(controllerBtn);
        StartCoroutine(logMenu.PopDownMenu());
        
    }
}
