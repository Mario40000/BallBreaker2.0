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

	void Start ()
    {
        //StartCoroutine(TitleReturn());
        scoreText.text = "Final score: " + StaticData.score.ToString();
        bricksDestroyed.text = "Bricks destroyed: " + StaticData.destroyedBricks.ToString();
        StaticData.totalDestroyedBricks += StaticData.destroyedBricks;
    }

    void Update()
    {
       if(Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }

    //Metodo para cargar los carteles de la pantalla y devolvernos al titulo
    IEnumerator TitleReturn ()
    {
        scoreText.text = "Final score: " + StaticData.score.ToString();
        bricksDestroyed.text = "Bricks destroyed: " + StaticData.destroyedBricks.ToString();
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("TitleScene");
    }
}
