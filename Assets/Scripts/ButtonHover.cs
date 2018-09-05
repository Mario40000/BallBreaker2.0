using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHover : MonoBehaviour
{
    //Script que controla el hover y el sonido de este en los botones

    public GameObject hoverFX;
    public GameObject imageButton;

    //Metodo para aumentar el tamaño del boton y hacer sonar el FX
    public void Hover()
    {
        hoverFX.GetComponent<AudioSource>().Play();
        //Agrandamos un poco el boton para resaltarlo
        imageButton.GetComponent<RectTransform>().localScale = new Vector3(1.55f, 3.55f, 1.0f);
    }

    //Metodo para hacer volver al boton al tamaño original al salir de hover
    public void Resize()
    {
        imageButton.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 3.5f, 1.0f);
    }
	
}
