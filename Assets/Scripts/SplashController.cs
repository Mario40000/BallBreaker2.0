using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashController : MonoBehaviour
{

    // Script para controlar la pantalla de splash

    public float waitTime = 0.0f;

    private GameObject fxEffect;

	void Start ()
    {
        fxEffect = GameObject.Find("StartSound");
        StartCoroutine(startSplash());
	}
	
    IEnumerator startSplash()
    {
        yield return new WaitForSeconds(1);
        fxEffect.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("TitleScene");

    }
	
}
