using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : MonoBehaviour
{    
    [SerializeField] private GameObject _objectToHide;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("HideControlls"))
        {
            _objectToHide.SetActive(!_objectToHide.activeSelf);
        }
    }
}
