using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BountyHunterLogic : MonoBehaviour
{
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
