using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/CollectableInfo")]
public class CollectableInfo : ScriptableObject
{
    [SerializeField] private PlanetType _planetBelong;
    [SerializeField] private string _id;
    [SerializeField] private string _parameter;
    [SerializeField] private string _valueAndDimension;
    [SerializeField] private string _description;

    public PlanetType PlanetBelong { get => _planetBelong; }
    public string Id { get => _id; }
    public string Parameter { get => _parameter; }
    public string ValueAndDimension { get => _valueAndDimension; }
    public string Description { get => _description; }
}