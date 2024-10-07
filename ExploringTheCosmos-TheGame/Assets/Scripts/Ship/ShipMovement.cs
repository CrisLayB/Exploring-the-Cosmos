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
        
    // Private Components
    private Rigidbody _rb; 

    // Auxiliar Components
    private TextForShowInfo _showInfo;
    private Planet _planetSelected;
    private bool _allowedToMove = true;

    private void Start() 
    {
        _rb = GetComponent<Rigidbody>();
        _showInfo = GetComponent<TextForShowInfo>();
        if(GameManager.Instance != null) GameManager.Instance.LockMouseCursor();
        if(GameManager.Instance != null) GameManager.Instance.ContinuePlaying();
    }

    private void Update()
    {
        if(GameManager.Instance != null)
        {
            if(!GameManager.Instance.IsPlaying) return;
        }

        if((Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")) && Cursor.visible)
        {
            if(GameManager.Instance != null) GameManager.Instance.LockMouseCursor();
        }

        if(!_allowedToMove) return;

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

    

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject?.GetComponent<Planet>().PlanetSelected == PlanetType.Sol)
        {            
            StartCoroutine(RestartLevel());
        }
    }

    private IEnumerator RestartLevel()
    {
        _allowedToMove = false;
        
        // Explode Particles
        
        MeshRenderer[] meshes = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer mRenderer in meshes)
        {
            mRenderer.enabled = false;
        }

        yield return new WaitForSeconds(2f);
        _allowedToMove = true;
        LevelSelector.GalaxyNavigation();
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
        
        _showInfo.ShowText($"{_planetSelected.PlanetSelected.ToString()}\n\nPresiona Tecla Espacio o Boton A para visitar.");
    }

    private void OnTriggerExit(Collider other) 
    {        
        _planetSelected = null;
        _showInfo.HideText();
    }
}
