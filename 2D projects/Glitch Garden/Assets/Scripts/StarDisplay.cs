﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    Text StarText;

    void Start()
    {
        StarText = GetComponent<Text>();
        UpdateDisplay();
    }
    private void UpdateDisplay()
    {
        StarText.text =  stars.ToString() ;
    }

    public bool HaveEnoughStars(int amount)
    {
        return stars >= amount;
    }
    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }
    public void RemoveStar(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
        }
       
    }
}
