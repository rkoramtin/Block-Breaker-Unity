using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour {
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    private int timeHits;
    private LevelManager levelManager;
    private bool isBreakable;
    // Use this for initialization
    void Start () {
        isBreakable = (this.tag == "Breakable");
        //increament part of brakable
        if(isBreakable)
        {
            breakableCount++;
        }
        timeHits = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

    // Update is called once per frame
    void Update() {
    }
    void OnCollisionEnter2D(Collision2D col)
        {
        bool isBreakable = (this.tag == "Breakable");
          if (isBreakable)
          {
            HandleHits();
          }
        }
    void HandleHits()
    {
        timeHits++;
        int maxHits = hitSprites.Length + 1;

        if (timeHits >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }
    void LoadSprites()
    {
        int spriteIndex = timeHits - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }
    void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }

    }

