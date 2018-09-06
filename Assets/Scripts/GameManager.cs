﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Transform playerInstancier;
    public GameObject player;
    public GameObject explosion;
    public GameObject ballExplosion;
    public GameObject imageReady;
    public GameObject imageGo;
    public GameObject imageAwesome;
    public GameObject imageSuicide;
    public GameObject imageUPS;
    public Text scoreText;
    public Text hiScoreText;
    public Text infoText;
    public Text livesText;

    private GameObject playerExplosion;
    private GameObject ballExplosionFX;

    void Awake()
    {
        imageReady.SetActive(false);
        imageGo.SetActive(false);
        imageAwesome.SetActive(false);
        imageSuicide.SetActive(false);
        imageUPS.SetActive(false);
    }
    // Use this for initialization
    void Start()
    {
        livesText.text = "X " + StaticData.lives.ToString();
        playerExplosion = GameObject.Find("PlayerExplosion");
        ballExplosionFX = GameObject.Find("BallExplosionFX");
        StartCoroutine(StartGame());
        
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
        imageUPS.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        GameObject playerTemp = GameObject.FindGameObjectWithTag("Player");
        Instantiate(explosion, playerTemp.GetComponent<Transform>().position, Quaternion.identity);
        playerExplosion.GetComponent<AudioSource>().Play();
        Destroy(playerTemp);
        imageUPS.SetActive(false);
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
        if(ballTemp != null && !ballTemp.GetComponent<Rigidbody2D>().isKinematic)
        {
            Instantiate(ballExplosion, ballTemp.GetComponent<Transform>().position, Quaternion.identity);
            ballExplosionFX.GetComponent<AudioSource>().Play();
            Destroy(ballTemp);
            StartCoroutine(LoseBall());
        }
    }

    //Corrutina para empezar la partida
    IEnumerator StartGame ()
    {
        yield return new WaitForSeconds(1);
        imageReady.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        imageReady.SetActive(false);
        imageGo.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        imageGo.SetActive(false);
        Instantiate(player, playerInstancier.position, Quaternion.identity);
    }
        
}

 

