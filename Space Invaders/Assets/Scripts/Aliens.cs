using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Aliens : MonoBehaviour
{
    public System.Action killed;
    private int animationFrame;
    public int ScoreCount = 0;
    private Animator animComp;
    private float timer = 0f;
    public AudioClip gone;

    private void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
            audioSource.clip = gone;
            audioSource.Play();
            
            this.killed.Invoke();
            timer = 0f;
            if (this.gameObject.tag.Equals("Alien1"))
            {
                ScoreCount += 30;
                Debug.Log(ScoreCount);
                this.gameObject.GetComponent<Animator>().SetBool("Hit", true);
            }
            else if (this.gameObject.tag.Equals("Alien2"))
            {
                ScoreCount += 20;
                Debug.Log(ScoreCount);
                this.gameObject.GetComponent<Animator>().SetBool("Hit", true);
            }
            else if (this.gameObject.tag.Equals("Alien3"))
            {
                ScoreCount += 10;
                Debug.Log(ScoreCount);
                this.gameObject.GetComponent<Animator>().SetBool("Hit", true);
            }
            Destroy(this.gameObject, 1);
            
        }
    }
}
