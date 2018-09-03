using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickInstancier : MonoBehaviour
{

    public GameObject brickPrefab;
    public Material[] colors;

	// Creamos las filas de bloques con nuestros prefabs
	void Start ()
    {
        CreatingFiles(6);
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    // Metodo para crear una linea
    //void CreatingFile (float y)
    //{
    //    for (int i = 0;i <= 7; i++)
    //    {
    //        GameObject tempBrick = Instantiate(brickPrefab, new Vector2(i - (7 - i), y), Quaternion.identity);
    //        tempBrick.GetComponent<BrickController>().PaintingBricks(colors[Random.Range(0, colors.Length)], colors);
            //tempBrick.GetComponent<MeshRenderer>().material = colors[Random.Range(0, colors.Length - 1)];
    //    }
    //}

    //Metodo para crear varias filas de lineas
    void CreatingFiles (int num)
    {
        for (float i = 0;i <= num; i++)
        {
            //CreatingFile(4 - (i/2));
        }
    }

    
}
