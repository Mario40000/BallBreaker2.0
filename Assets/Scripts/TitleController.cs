using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{

    // Script para controlar la pantalla de titulo

    public Button startButton;
    public Button optionsbutton;
    public GameObject clickFX;
    public GameObject hoverFX;
    public GameObject canvasTitle;
    public GameObject canvasOptions;
    public float waitTime;
    public Text highScore;
    public Text bricks;
    public Text maxLevel;


    //Ordenamos los canvas al iniciar la pantalla
    private void Awake()
    {
        canvasTitle.SetActive(true);
        canvasOptions.SetActive(false);
        highScore.text = StaticData.hiScore.ToString();
        bricks.text = StaticData.totalDestroyedBricks.ToString();
        maxLevel.text = StaticData.maxLevel.ToString();

    }

    //Metodo para arrancar el juego al pulsar start
    public void StartGame()
    {
        StaticDataReset();
        StartCoroutine(GameStart());
    }

    //Corrutina asociada a startGame
    IEnumerator GameStart ()
    {
        clickFX.GetComponent<AudioSource>().Play();
        startButton.GetComponent<Button>().enabled = false;
        optionsbutton.GetComponent<Button>().enabled = false;
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Level1");

    }

    //Metodo para resetar los puntos y las vidas
    void StaticDataReset()
    {
        StaticData.score = 0;
        StaticData.lives = 3;
        StaticData.level = 1;
        StaticData.destroyedBricks = 0;
        StaticData.remainsBricks = 0;
    }

    //Metodo para pasar a las opciones
    public void Options()
    {
        clickFX.GetComponent<AudioSource>().Play();
        canvasTitle.SetActive(false);
        canvasOptions.SetActive(true);
    }

    //Metodo para volver de las opciones al titulo
    public void ReturnTitle()
    {
        clickFX.GetComponent<AudioSource>().Play();
        canvasOptions.SetActive(false);
        canvasTitle.SetActive(true); 
    }

    //Metodo para abandonar la partida
    public void ExitGame()
    {
        clickFX.GetComponent<AudioSource>().Play();
        Application.Quit();
    }

}
