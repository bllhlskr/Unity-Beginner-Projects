using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D othercollider)
    {
        GameObject otherobject = othercollider.gameObject;
        if (otherobject.GetComponent<GraveStone>())
        {
            GetComponent<Animator>().SetTrigger("jumpTrigger");
        }
        else if (otherobject.GetComponent<Defender>() )
        {
            GetComponent<Attacker>().Attack(otherobject);
        }
        
    }
}
 