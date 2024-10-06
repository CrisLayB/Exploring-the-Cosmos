using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public static void GalaxyNavigation()
    {
        SceneManager.LoadScene("Galaxy");
    }

    public static void PlanetNavigation(PlanetType planetType)
    {
        SceneManager.LoadScene(planetType.ToString());
    }
}
