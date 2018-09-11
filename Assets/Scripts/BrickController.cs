using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{

    //public Material material;
    public int score;
    public bool breakable = true;
    public int hitsRemains = 1;
    public int hits = 0;
    public GameObject breakMask;
    public GameObject hitFX;
    public GameObject explosionFX;

    private GameObject brickSound;
    
    private void Start()
    {
        
    }
    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.collider.tag == "Ball" && breakable)
        {
            BreakingBrick();
        }
    }

    //Rompiendo los bloques
    void BreakingBrick()
    {
        brickSound = GameObject.Find("BrickBreak");
        brickSound.GetComponent<AudioSource>().Play();
        breakMask = Instantiate(breakMask, gameObject.GetComponent<Transform>().position, Quaternion.identity);
        breakMask.transform.parent = gameObject.transform;
        Instantiate(hitFX, gameObject.GetComponent<Transform>().position, Quaternion.identity);
        hits += 1;
        if (hits == hitsRemains)
        {
            StaticData.score += score;
            StaticData.destroyedBricks += 1;
            Instantiate(explosionFX, gameObject.GetComponent<Transform>().position, Quaternion.identity);
            StaticData.remainsBricks--;
            Destroy(gameObject);
        }
    }

    //Metodo para colorear los bloques
    //public void PaintingBricks(Material material_, Material[] colors
    //{
    //    GetComponent<MeshRenderer>().material = material_;
    //    material = material_;

    //    for (int i = 1;i <= colors.Length -1;i++)
    //    {
    //        if (material_ == colors[i])
    //        {
    //            score = (i * 10) + 10 ;
    //        }
    //    }
    //}
}
