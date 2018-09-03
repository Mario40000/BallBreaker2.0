using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBounceController : MonoBehaviour
{
    //Hacemos sonar el rebote contra paredes y raqueta

    private GameObject bounceSound;
   
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Ball")
        {
            bounceSound = GameObject.Find("BounceSound");
            bounceSound.GetComponent<AudioSource>().Play();
        }
    }

}
