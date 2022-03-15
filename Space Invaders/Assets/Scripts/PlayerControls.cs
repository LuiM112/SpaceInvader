using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    public Shooting laserPrefab;
    public float speed = 5.0f;

    private bool laserActive;
    private bool shoot;

    private Animator animComp;
    public AudioClip glock;
    public AudioClip death;

    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
    }
    // Update is called once per frame
    void Update()
    {
        AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
        
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
            this.gameObject.GetComponent<Animator>().SetBool("Input", true);
            pew();
            audioSource.clip = glock;
            audioSource.Play();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            this.gameObject.GetComponent<Animator>().SetBool("Input", false);
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
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Missile"))
        {
            this.gameObject.GetComponent<Animator>().SetBool("Hit", true);
        }
        
        if (col.gameObject.layer == LayerMask.NameToLayer("Alien"))
        {
            this.gameObject.GetComponent<Animator>().SetBool("Hit", true);
        }
        AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.clip = death;
        audioSource.Play();
        StartCoroutine(WaitForSceneLoad());
    }
}
