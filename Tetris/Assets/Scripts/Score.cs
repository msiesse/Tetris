using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public GameObject	game;
	private int			count;
	private Text		theText;
    // Start is called before the first frame update
    void Start()
    {
		count = 0;
		theText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
		if (game.GetComponent<Spawner>().gameOver)
		{
			//afficher un gros game over
			Time.timeScale = 0;
		}
		if (game.GetComponent<Spawner>().lines != count)
		{
			count = game.GetComponent<Spawner>().lines;
			if (name == "Score")
				theText.text = "Score:\n" + Mathf.Round(count * 10 * game.GetComponent<Spawner>().speed);
			else if (name == "Lines")
				theText.text = "Lines:\n" + count;
		}
    }
}
