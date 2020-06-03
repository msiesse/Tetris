using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetraminos : MonoBehaviour
{
	public static bool[,]	tetra;
    // Start is called before the first frame update
    void Start()
    {
		tetra = new bool[4,4];
		for (int i = 0; i < 4; i++)
		{
			tetra[0,i] = true;
		}
    }

    // Update is called once per frame
    void Update()
    {

    }
}
