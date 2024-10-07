using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BountyHunterLogic : MonoBehaviour
{
    [SerializeField] private float _maxDistance = 1.5f;
    private Collectable _collectableDetected;
    
    private void Update() 
    {
        Ray camRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));        

        RaycastHit hitInfo;
        
        if (Physics.Raycast(camRay, out hitInfo, _maxDistance))
        {            
            Debug.DrawLine(camRay.origin, hitInfo.point, Color.green);
            PickupObject(hitInfo);
        }
        else
        {
            Debug.DrawLine(camRay.origin, camRay.origin + camRay.direction * _maxDistance, Color.red);
            _collectableDetected = null;
        }
    }

    private void PickupObject(RaycastHit hitInfo)
    {
        _collectableDetected = hitInfo.collider.gameObject.GetComponent<Collectable>();

        if(_collectableDetected == null) return;

        // Show Information in the UI        

        if(Input.GetButtonDown("Grab"))
        {
            _collectableDetected.TakeObject();
        }
    }
    
    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.tag == "ShipStation")
        {            
            if(Input.GetButtonDown("ConfirmButton"))
            {
                LevelSelector.GalaxyNavigation();
            }
        }
    }
}
