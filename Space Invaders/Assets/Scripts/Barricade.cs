using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            this.gameObject.SetActive(false);
        }
        if (col.gameObject.layer == LayerMask.NameToLayer("Missile"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
