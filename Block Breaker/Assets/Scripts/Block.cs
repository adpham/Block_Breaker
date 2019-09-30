using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // config parameters

    //[SerializeField] AudioClip breakSound;

    [SerializeField] GameObject blockSparkles;
    [SerializeField] Sprite[] hitSprites;

    //cached reference
    Level level;
    GameState gameState;

    //state variables
    [SerializeField] int timesHit; //***SERIALIZED FOR DEBUG PURPOSES***

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
        if (tag == "Breakable")
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
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array" + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparkles();
        TextUpdate();
    }

    private void TextUpdate()
    {
        gameState = FindObjectOfType<GameState>();
        gameState.AddToScore();
        gameState.GameSpeedUpdate();
    }

    private void TriggerSparkles()
    {
        GameObject sparkles = Instantiate(blockSparkles, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
