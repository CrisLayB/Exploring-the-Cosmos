using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{    
    [SerializeField] private CollectableInfo _collectableInfo;

    public CollectableInfo GetCollectableInfo { get => _collectableInfo; }

    private void Start()
    {
        CollectibleManager.Instance.ResetCollectedItems(); // ! For Debuggin propurses
        if (CollectibleManager.Instance != null && CollectibleManager.Instance.IsItemCollected(_collectableInfo.Id))
        {
            gameObject.SetActive(false);
        }
    }

    public void TakeObject()
    {
        CollectibleManager.Instance.RegisterCollectedItem(_collectableInfo.Id);
        gameObject.SetActive(false);
    }
}
