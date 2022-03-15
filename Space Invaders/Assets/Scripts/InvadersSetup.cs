using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class InvadersSetup : MonoBehaviour
{
    public Aliens[] prefabs;
    public int rows = 5;
    public int columns = 11;
    public AnimationCurve speed;
    public float missleAttack = 1.0f;
    public ScoreCapture score;

    private Aliens aliens;
    public AudioClip pewpew;

    public Shooting missilePrefab;

    public int aliensKilledCount { get; private set; }
    public int totalAliens => this.rows * this.columns;
    public float percentKilled => (float)this.aliensKilledCount / (float)this.totalAliens;
    public int stillAlive => this.totalAliens - this.aliensKilledCount;
    private Vector3 direction = Vector2.right;

    private void Start()
    {
        InvokeRepeating(nameof(alienMissile), this.missleAttack, this.missleAttack);
    }

    private void Awake()
    {
        for (int row = 0; row < this.rows; row++)
        {
            float width = 2.0f * (this.columns - 1);
            float height = 2.0f * (this.rows - 1);
            Vector2 centering = new Vector2(-width / 2, -height / 2);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * 2.0f), 0.0f);
            for (int col = 0; col < this.columns; col++)
            {
                aliens = Instantiate(this.prefabs[row], this.transform);
                aliens.killed += AlienKilled;
                Vector3 position = rowPosition;
                position.x += col * 2.0f;
                aliens.transform.localPosition = position;
                
            }
        }
    }

    private void Update()
    {
        this.transform.position += direction * this.speed.Evaluate(this.percentKilled) * Time.deltaTime;
        
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);

        Vector3 RightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
        score.UpdateScore(aliens.ScoreCount);

        foreach (Transform aliens in this.transform)
        {
            if (!aliens.gameObject.activeInHierarchy)
            {
                continue;
            }

            if (direction == Vector3.right && aliens.position.x >= (RightEdge.x - 1.0f))
            {
                AdvanceRow();
            }
            else if (direction == Vector3.left && aliens.position.x <= (leftEdge.x + 1.0f))
            {
                AdvanceRow();
            }
        }
    }

    private void AdvanceRow()
    {
        direction.x *= -1.0f;

        Vector3 position = this.transform.position;
        position.y -= 1.0f;
        this.transform.position = position;
    }

    private void alienMissile()
    {
        
        foreach (Transform aliens in this.transform)
        {
            if (!aliens.gameObject.activeInHierarchy)
            {
                continue;
            }

            if (Random.value < (10f / (float) this.stillAlive))
            {
                AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
                audioSource.clip = pewpew;
                audioSource.Play();
                Instantiate(this.missilePrefab, aliens.position, Quaternion.identity);
                break;
            }
        }
    }

    private void AlienKilled()
    {
        this.aliensKilledCount++;
    }
}
