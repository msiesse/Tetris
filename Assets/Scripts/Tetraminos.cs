using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetraminos : MonoBehaviour
{
	public static int[,,]	tetra;
    // Start is called before the first frame update
    void Start()
    {
		tetra = new int[7,4,4] {{{1,1,1,1},{0,0,0,0},{0,0,0,0},{0,0,0,0}}
								, {{1,1,0,0},{1,1,0,0},{0,0,0,0},{0,0,0,0}}
								, {{1,1,1,0},{0,1,0,0},{0,0,0,0},{0,0,0,0}}
								, {{0,1,0,0},{0,1,0,0},{1,1,0,0},{0,0,0,0}}
								, {{1,0,0,0},{1,0,0,0},{1,1,0,0},{0,0,0,0}}
								, {{1,0,0,0},{1,1,0,0},{0,1,0,0},{0,0,0,0}}
								, {{0,1,0,0},{1,1,0,0},{1,0,0,0},{0,0,0,0}}};
    }

    // Update is called once per frame
    void Update()
    {

    }
}
