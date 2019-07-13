using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float unityUnit = 16f;
    [SerializeField] float min = 1f;
    [SerializeField] float max = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   Vector2 paddlePosition = new Vector2(transform.position.x,transform.position.y);
        paddlePosition.x = Mathf.Clamp(GetXPos(),min,max);
        transform.position = paddlePosition;
     }
    private float GetXPos()
    {
        if (FindObjectOfType<GameStatus>().IsAutoPlayEnabled())
        {
            return FindObjectOfType<Ball>().transform.position.x;
        }
        else
        {
            return (Input.mousePosition.x / Screen.width * unityUnit);
        }
    }
}
