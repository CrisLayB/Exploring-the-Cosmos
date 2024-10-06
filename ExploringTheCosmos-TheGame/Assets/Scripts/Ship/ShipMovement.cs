using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [Header("Ship Movement")]
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _nitroSpeed = 20f;
    [SerializeField] private float _rotationSpeed = 1f;

    [Header("UI Connection")]
    [SerializeField] private TextInfo _textInfo;

    // Private Components
    private Rigidbody _rb; 

    // Auxiliar Components
    private TextMeshProUGUI _textVisitinPlanet;
    private Planet _planetSelected;

    private void Start() 
    {
        _rb = GetComponent<Rigidbody>();        

        if(_textInfo != null)
        {
            _textVisitinPlanet = _textInfo.GetComponentInChildren<TextMeshProUGUI>();
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
            LevelSelector.PlanetNavigation(_planetSelected.PlanetSelected);
        }

        float moveDirection = Input.GetAxis("Vertical");

        float shipVelocity = _moveSpeed;
        float inputNitro = Input.GetAxis("Nitro");

        if(Input.GetButtonDown("Nitro")) shipVelocity = _nitroSpeed;
        else if(inputNitro > 0.1f) shipVelocity = _nitroSpeed * Mathf.Abs(inputNitro);

        transform.Translate(Vector3.forward * moveDirection * shipVelocity * Time.deltaTime);

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
            StartCoroutine(RestartLevel());
        }
    }

    private IEnumerator RestartLevel()
    {
        print("AAA");
        Destroy(this.gameObject);        
        yield return new WaitForSeconds(2f);
        LevelSelector.GalaxyNavigation();
        print("BBB");
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

        
        _textVisitinPlanet.text = $"{_planetSelected.PlanetSelected.ToString()}\n\nPresiona Tecla Espacio o Boton A para visitar.";
        _textInfo.gameObject.SetActive(true);
        StartCoroutine(_textInfo.PopUpMenu());
    }

    private void OnTriggerExit(Collider other) 
    {        
        _planetSelected = null;
        
        if(_textVisitinPlanet == null) return;

        StartCoroutine(_textInfo.PopDownMenu());
        _textVisitinPlanet.text = $"";
    }
}
