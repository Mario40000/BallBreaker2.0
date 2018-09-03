using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Transform playerInstancier;
    public GameObject player;
    public GameObject explosion;
    public Text scoreText;
    public Text hiScoreText;
    
    public Text infoText;
    public Text livesText;

    private GameObject playerExplosion;
    // Use this for initialization
    void Start()
    {
        
        livesText.text = "X " + StaticData.lives.ToString();
        Instantiate(player, playerInstancier.position, Quaternion.identity);
        playerExplosion = GameObject.Find("PlayerExplosion");
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + StaticData.score.ToString();
        hiScoreText.text = "HiScore: " + StaticData.hiScore.ToString();
        if(StaticData.score > StaticData.hiScore)
        {
            StaticData.hiScore = StaticData.score;
        }

        //Boton para suicidarse
        if(Input.GetButtonDown("Fire3"))
        {
            SuicideBall();
        }
    }

    //Metodo para llamar al anterior desde otro script
    public void LosingBall()
    {
        StartCoroutine(LoseBall());
    }

    //Metodo para matar al jugador y volver a instanciarlo o acabar la partida
    IEnumerator LoseBall()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject playerTemp = GameObject.FindGameObjectWithTag("Player");
        Instantiate(explosion, playerTemp.GetComponent<Transform>().position, Quaternion.identity);
        playerExplosion.GetComponent<AudioSource>().Play();
        Destroy(playerTemp);
        yield return new WaitForSeconds(3);
        if(StaticData.lives <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
        else
        {
            StaticData.lives -= 1;
            livesText.text = "X " + StaticData.lives.ToString();
            Instantiate(player, playerInstancier.position, Quaternion.identity);
        }
        
    }
    
    //Metodo para destruir la pelota si se atasca
    void SuicideBall()
    {
        GameObject ballTemp = GameObject.FindGameObjectWithTag("Ball");
        if(ballTemp != null)
        {
            Destroy(ballTemp);
            StartCoroutine(LoseBall());
        }
    }
        
}

 

