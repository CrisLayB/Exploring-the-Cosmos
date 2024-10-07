using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/CollectableInfo")]
public class CollectableInfo : ScriptableObject
{
    [SerializeField] private PlanetType _planetBelong;
    [SerializeField] private string _name;
    [SerializeField] private string _description;

    public PlanetType PlanetBelong { get => _planetBelong; }
    public string Name { get => _name; }
    public string Description { get => _description; }
}