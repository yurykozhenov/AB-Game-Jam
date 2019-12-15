using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public SpriteRenderer onOffSprite;
    public GameObject exit;
    public Sprite onSprite;

    private SpriteRenderer sprite;
    
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sprite.sprite = onSprite;
            onOffSprite.color = Color.white;
            exit.SetActive(true);
        }
    }
}
