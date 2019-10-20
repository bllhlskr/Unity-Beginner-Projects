using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEst : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefsControler.SetMasterVolume(0.4f);
        Debug.Log(PlayerPrefsControler.GetVolume());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
