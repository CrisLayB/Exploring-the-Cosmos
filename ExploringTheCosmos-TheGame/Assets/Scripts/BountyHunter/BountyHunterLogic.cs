using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BountyHunterLogic : MonoBehaviour
{
    [SerializeField] private float _maxDistance = 1.5f;
    private Collectable _collectableDetected;  // Current detected collectable
    private Collectable _previousCollectable;  // To track the previously detected collectable
    private TextForShowInfo _showInfo;

    private void Start()
    {
        _showInfo = GetComponent<TextForShowInfo>();
    }

    private void Update()
    {
        Ray camRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitInfo;

        // Perform the raycast within the defined maximum distance
        if (Physics.Raycast(camRay, out hitInfo, _maxDistance))
        {
            Debug.DrawLine(camRay.origin, hitInfo.point, Color.green);
            DetectCollectable(hitInfo);
        }
        else
        {
            Debug.DrawLine(camRay.origin, camRay.origin + camRay.direction * _maxDistance, Color.red);
            ClearCollectableDetection();  // Clear detection when no hit is found
        }
    }

    private void DetectCollectable(RaycastHit hitInfo)
    {
        // Get the collectable component if the hit object has one
        _collectableDetected = hitInfo.collider.gameObject?.GetComponent<Collectable>();

        // Check if the detected collectable has changed
        if (_collectableDetected != _previousCollectable)
        {
            if (_collectableDetected != null)
            {
                // Show new collectable information when a new collectable is detected
                _showInfo.ShowText($"Información sobre: {_collectableDetected.GetCollectableInfo.Parameter}\n\nPresiona Tecla E o Boton X para recoger la Tablet");
            }
            else
            {
                // Hide the text if no collectable is detected
                _showInfo.HideText();
            }

            // Update the previous collectable to the newly detected one
            _previousCollectable = _collectableDetected;
        }

        // Allow picking up the object if the "Grab" button is pressed
        if (_collectableDetected != null && Input.GetButtonDown("Grab"))
        {
            _collectableDetected.TakeObject();
        }
    }

    private void ClearCollectableDetection()
    {
        // Only update the UI if the previous collectable was not null
        if (_collectableDetected != null)
        {
            _showInfo.HideText();
            _previousCollectable = null;
        }

        // Clear the currently detected collectable
        _collectableDetected = null;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("ShipStation"))
        {
            _showInfo.ShowText("Presiona Tecla Spacio o Boton A para ir a la Galaxia");

            if (Input.GetButtonDown("ConfirmButton"))
            {
                LevelSelector.GalaxyNavigation();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _showInfo.HideText();
    }
}
