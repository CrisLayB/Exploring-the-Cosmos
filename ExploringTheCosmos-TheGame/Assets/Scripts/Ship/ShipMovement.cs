using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [Header("Ship Movement")]
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _rotationSpeed = 1f;   
    private Rigidbody _rb; 

    // Auxiliar Components
    private GameObject _gameObjectText;
    private TextMeshProUGUI _textVisitinPlanet;
    private Planet _planetSelected;

    private void Start() 
    {
        _rb = GetComponent<Rigidbody>();
        _gameObjectText = GameObject.Find("Visit Text (TMP)");

        if(_gameObjectText != null)
        {
            _textVisitinPlanet = _gameObjectText.GetComponent<TextMeshProUGUI>();
        }

        if(_textVisitinPlanet != null)
        {
            _textVisitinPlanet.text = $"";
        }

        LockMouseCursor();
    }

    private void Update()
    {
        if((Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")) && Cursor.visible)
        {
            LockMouseCursor();
        }

        if(Input.GetButtonDown("ResetPos"))
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.y, 0);
        }

        if(Input.GetButtonDown("ConfirmButton") && _planetSelected)
        {
            // print("Go To The Planet");
            LevelSelector.PlanetNavigation(_planetSelected.PlanetSelected);
        }

        float moveDirection = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * moveDirection * _moveSpeed * Time.deltaTime);

        float yaw = Input.GetAxis("Horizontal") * _rotationSpeed;
        transform.Rotate(0, yaw, 0);
        
        if (Input.GetButton("Ascend")) transform.Rotate(Vector3.right * _rotationSpeed);
        if (Input.GetButton("Descend")) transform.Rotate(Vector3.left * _rotationSpeed);
    }

    private void LockMouseCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void UnlockMouseCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject?.GetComponent<Planet>().PlanetSelected == PlanetType.Sol)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionExit(Collision other) 
    {
        _rb.velocity = Vector3.zero;
        _rb.isKinematic = true;
        _rb.isKinematic = false;
    }

    private void OnTriggerEnter(Collider other) 
    {
        _planetSelected = other.gameObject.GetComponent<Planet>();

        if(_planetSelected == null) return;

        if(_textVisitinPlanet == null) return;

        _textVisitinPlanet.text = $"Presiona Tecla Espacio o Botón A para visitar: {_planetSelected.PlanetSelected.ToString()}";
    }

    private void OnTriggerExit(Collider other) 
    {        
        _planetSelected = null;
        
        if(_textVisitinPlanet == null) return;

        _textVisitinPlanet.text = $"";
    }
}
