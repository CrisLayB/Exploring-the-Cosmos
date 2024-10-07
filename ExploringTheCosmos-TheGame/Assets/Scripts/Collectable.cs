using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{    
    [SerializeField] private CollectableInfo _collectableInfo;
    [SerializeField] private float _speedRotation = -0.7f;

    public CollectableInfo GetCollectableInfo { get => _collectableInfo; }

    private void Start()
    {
        // CollectibleManager.Instance.ResetCollectedItems(); // ! For Debuggin propurses

        if (CollectibleManager.Instance != null && CollectibleManager.Instance.IsItemCollected(_collectableInfo.Id))
        {
            gameObject.SetActive(false);
        }
    }

    private void Update() 
    {
        transform.Rotate(0, Mathf.Sin(90) + _speedRotation, 0);
    }

    public void TakeObject()
    {
        CollectibleManager.Instance.RegisterCollectedItem(_collectableInfo.Id);
        gameObject.SetActive(false);
    }
}
