using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class numberwizard : MonoBehaviour
{
    [SerializeField] int max;
    [SerializeField] int min;
    [SerializeField] Text guessText;
    int guess;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }
    void StartGame()
    {   max = +1;
        max = 1000;
        min = 1;
        guess = Random.Range(min,max+1);
        guessText.text = guess.ToString();


    }
    // Update is called once per frame



    
void NextGuess()
    {
       guess = (max+min)/2;
        OnClick();
       
    }
public void PressHigher()
    {
            min = guess;
            NextGuess();
    }
public void PressLower()
    {
        max = guess;
        NextGuess();
    }
public void OnClick()
    {
 guessText.text = guess.ToString();
    }
}
