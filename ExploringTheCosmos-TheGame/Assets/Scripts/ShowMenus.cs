using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMenus : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuGO;
    private PauseMenu pauseMenu;

    [SerializeField] private GameObject logMenuGO;
    private LogMenu logMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        pauseMenuGO.SetActive(false);        
        logMenuGO.SetActive(false);

        pauseMenu = pauseMenuGO.GetComponent<PauseMenu>();
        logMenu = logMenuGO.GetComponent<LogMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("PauseMenu"))
        {            
            PauseMenuFunctionallity();
        }

        if(Input.GetButtonDown("CollectionMenu"))
        {
            if (logMenuGO.activeSelf) 
            {
                StartCoroutine(logMenu.PopDownMenu());
                if(GameManager.Instance != null) GameManager.Instance.LockMouseCursor();
                if(GameManager.Instance != null) GameManager.Instance.ContinuePlaying();
            } 
            else 
            {
                if (pauseMenuGO.activeSelf) return;

                logMenuGO.SetActive(true);
                StartCoroutine(logMenu.PopUpMenu());
                if(GameManager.Instance != null) GameManager.Instance.UnlockMouseCursor();
                if(GameManager.Instance != null) GameManager.Instance.StopPlaying();
            }
        }
    }

    public void PauseMenuFunctionallity()
    {
        if (pauseMenuGO.activeSelf) 
        {
            StartCoroutine(pauseMenu.PopDownMenu());
            if(GameManager.Instance != null) GameManager.Instance.LockMouseCursor();
            if(GameManager.Instance != null) GameManager.Instance.ContinuePlaying();
        } 
        else 
        {
            if(logMenuGO.activeSelf) return;
            
            pauseMenuGO.SetActive(true);
            StartCoroutine(pauseMenu.PopUpMenu());
            if(GameManager.Instance != null) GameManager.Instance.UnlockMouseCursor();
            if(GameManager.Instance != null) GameManager.Instance.StopPlaying();
        }
    }
}
