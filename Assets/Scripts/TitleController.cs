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
    public float waitTime;

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
    }
}
