using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get => instance; }
    
    private void Awake() 
    {        
        Time.timeScale = 1.0f;
        ContinuePlaying();

        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }

        Destroy(gameObject);
    }

    private bool _isPlaying = true;

    public bool IsPlaying { get => _isPlaying; }

    public void ContinuePlaying() => _isPlaying = true;
    public void StopPlaying() => _isPlaying = false;

    public void LockMouseCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void UnlockMouseCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
