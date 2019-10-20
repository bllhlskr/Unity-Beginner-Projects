using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    
    [SerializeField] Defender defenderPrefab;
     private void OnMouseDown()
    {
        var Buttons = FindObjectsOfType<DefenderButton>();
        
        foreach (DefenderButton button in Buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(87, 87, 87, 255);
           
        }
      GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
        
    }
    
}
