using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Aliens : MonoBehaviour
{
    public Sprite[] animationSprites;

    public float animationTime;
    public System.Action killed;
    private SpriteRenderer spriteRenderer;
    private int animationFrame;
    public GameObject[] AliensPrefab;
    public int ScoreCount = 0;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
    }

    private void AnimateSprite()
    {
        animationFrame++;

        if (animationFrame >= this.animationSprites.Length)
        {
            animationFrame = 0;
        }

        spriteRenderer.sprite = this.animationSprites[animationFrame];
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            this.killed.Invoke();
            if (this.gameObject.tag.Equals("Alien1"))
            {
                ScoreCount += 30;
                Debug.Log(ScoreCount);
            }
            else if (this.gameObject.tag.Equals("Alien2"))
            {
                ScoreCount += 20;
                Debug.Log(ScoreCount);
            }
            else if (this.gameObject.tag.Equals("Alien3"))
            {
                ScoreCount += 10;
                Debug.Log(ScoreCount);
            }
            this.gameObject.SetActive(false);
            
        }
    }
}
