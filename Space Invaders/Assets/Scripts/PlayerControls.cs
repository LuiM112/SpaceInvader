using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Shooting laserPrefab;
    public float speed = 5.0f;

    private bool laserActive;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += Vector3.left * this.speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += Vector3.right * this.speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            pew();
        }
    }

    private void pew()
    {
        if (!laserActive)
        {
            Shooting shooting = Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
            shooting.destroyed += LaserDestroyed;
            laserActive = true;
        }
        
    }

    private void LaserDestroyed()
    {
        laserActive = false;
    }
}
