using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Upgrade Area")
        {
            other.GetComponent<GodInteraction>().SetCircleVisability(true);
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "Upgrade Area")
        {
            other.GetComponent<GodInteraction>().SetCircleVisability(false);
        }
    }
}
