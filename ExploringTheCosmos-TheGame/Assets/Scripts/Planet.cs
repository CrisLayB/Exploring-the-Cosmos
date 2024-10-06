using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private PlanetType _planetType;
    [SerializeField] private float _speedRotation = 2f;

    public PlanetType PlanetSelected { get => _planetType; }

    private void Update() 
    {
        transform.Rotate(0, Mathf.Sin(90) + _speedRotation, 0);
    }
}
