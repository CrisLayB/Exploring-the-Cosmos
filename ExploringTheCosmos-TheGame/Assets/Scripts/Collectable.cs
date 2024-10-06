using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{    
    [SerializeField] private CollectableInfo _collectableInfo;

    public CollectableInfo GetCollectableInfo { get => _collectableInfo; }
}
