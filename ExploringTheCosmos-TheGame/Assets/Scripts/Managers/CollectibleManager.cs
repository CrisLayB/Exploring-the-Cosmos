using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager Instance { get; private set; }
    private HashSet<string> collectedItems = new HashSet<string>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadCollectedItems();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterCollectedItem(string itemName)
    {
        if (!collectedItems.Contains(itemName))
        {
            collectedItems.Add(itemName);
            SaveCollectedItems();
        }
    }

    public bool IsItemCollected(string itemName)
    {
        return collectedItems.Contains(itemName);
    }

    private void SaveCollectedItems()
    {
        string collectedData = string.Join(",", collectedItems);
        PlayerPrefs.SetString("CollectedItems", collectedData);
        PlayerPrefs.Save();
    }

    private void LoadCollectedItems()
    {
        if (PlayerPrefs.HasKey("CollectedItems"))
        {
            string collectedData = PlayerPrefs.GetString("CollectedItems");
            collectedItems = new HashSet<string>(collectedData.Split(','));
        }
    }

    public void ResetCollectedItems()
    {
        collectedItems.Clear();
        PlayerPrefs.DeleteKey("CollectedItems");
    }
}
