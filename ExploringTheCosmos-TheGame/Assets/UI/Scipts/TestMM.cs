using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMM : MonoBehaviour
{
    [SerializeField] GameObject controllersPanelGO;
    ControllersPanel controllersPanel;

    void Start()
    {
        controllersPanelGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
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
        controllersPanel = controllersPanelGO.GetComponent<ControllersPanel>();
        controllersPanelGO.SetActive(true);
        StartCoroutine(controllersPanel.PopUpMenu());
    }

    public void CloseControllers() {
        controllersPanel = controllersPanelGO.GetComponent<ControllersPanel>();
        StartCoroutine(controllersPanel.PopDownMenu());
    }
}
