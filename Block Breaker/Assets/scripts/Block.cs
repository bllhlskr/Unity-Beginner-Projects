using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config params
    [SerializeField] GameObject blockSparklesVfx;
    [SerializeField] AudioClip BreakSound;
    //[SerializeField] int maxhits;
    [SerializeField] Sprite[] hitSprites;
    
    //cached reference
    Level level;

    // state variables
    [SerializeField] int timesHit;//TODO only serialized for debug purposes

    private void Start()
    {
        CountBreakableBlocks();

    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            HandleHit();

        }


    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {

        int spriteIndex = timesHit-1;
        if(hitSprites[spriteIndex]!= null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];

        }
        else
        {
            Debug.Log("Block sprite is missing from array" + gameObject.name) ;
        }
            
        

        
    }

    private void DestroyBlock()
    {
        PlayBlockDestroySFX();
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparklesVfx();
    }

    private void PlayBlockDestroySFX()
    { 
        FindObjectOfType<GameStatus>().AddToScore();
        AudioSource.PlayClipAtPoint(BreakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVfx()

    {
        GameObject sparkles = Instantiate(blockSparklesVfx,transform.position,transform.rotation) ;
        Destroy(sparkles,1f);

    }

  
}
