using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{    
    [SerializeField] private CollectableInfo _collectableInfo;

    public CollectableInfo GetCollectableInfo { get => _collectableInfo; }

    private void Start()
    {
        if (CollectibleManager.Instance != null && CollectibleManager.Instance.IsItemCollected(_collectableInfo.Name))
        {
            gameObject.SetActive(false);
        }
    }

    public void TakeObject()
    {
        CollectibleManager.Instance.RegisterCollectedItem(_collectableInfo.Name);
        gameObject.SetActive(false);
    }
}
