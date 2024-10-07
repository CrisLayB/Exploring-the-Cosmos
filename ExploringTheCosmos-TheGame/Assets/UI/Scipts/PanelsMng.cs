using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsMng : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuGO;
    PauseMenu pauseMenu;

    [SerializeField] GameObject controllersPanelGO;
    ControllersPanel controllersPanel;
    void Start()
    {
        pauseMenuGO.SetActive(false);
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
