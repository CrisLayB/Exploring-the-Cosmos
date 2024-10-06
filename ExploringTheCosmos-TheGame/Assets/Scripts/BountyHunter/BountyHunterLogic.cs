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

            _collectableDetected = hitInfo.collider.gameObject.GetComponent<Collectable>();
            if(_collectableDetected != null)
            {
                print("HIT: " + _collectableDetected.GetCollectableInfo.Name);
                // Shot Information of the Collectable or press Button
            }
        }
        else
        {
            Debug.DrawLine(camRay.origin, camRay.origin + camRay.direction * _maxDistance, Color.red);
            _collectableDetected = null;
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
