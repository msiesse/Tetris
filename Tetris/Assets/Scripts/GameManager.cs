using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameObject[,]	bigGrid;

    // Start is called before the first frame update
    void Start()
    {
        bigGrid = new GameObject[20,10];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
