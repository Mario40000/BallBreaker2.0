using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {

    // Script para controlar la pantalla de game over

    public Text scoreText;
    public Text bricksDestroyed;
    public float waitTime = 0.0f;

    private GameObject click;

	void Start ()
    {
        StartCoroutine(TitleReturn());
        scoreText.text = StaticData.score.ToString();
        bricksDestroyed.text = StaticData.destroyedBricks.ToString();
        StaticData.totalDestroyedBricks += StaticData.destroyedBricks;
        if (StaticData.maxLevel < StaticData.level)
        {
            StaticData.maxLevel = StaticData.level;
        }
        click = GameObject.Find("ClickFX");
    }

    void Update()
    {
       
    }

    //Metodo para cargar los carteles de la pantalla y devolvernos al titulo
    IEnumerator TitleReturn ()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("TitleScene");
    }

    //Metodo para volver nada mas pulsar el boton
    public void ReturnTitle ()
    {
        click.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("TitleScene");
    }
}
