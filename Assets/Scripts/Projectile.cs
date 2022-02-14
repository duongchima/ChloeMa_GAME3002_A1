using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    //[SerializeField]
    //private GameManager gameManager;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "spawn")
        {
            GameManager.score++;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

}
