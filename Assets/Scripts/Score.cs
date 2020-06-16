using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public GameObject		game;
	private int				count;
	private Text			theText;
	private static float	highscore;
	private float			score;
	
    // Start is called before the first frame update
    void Start()
    {
		count = 0;
		theText = GetComponent<Text>();
		highscore = PlayerPrefs.GetFloat ("highscore", highscore);
		score = 0;
    }

    // Update is called once per frame
    void Update()
    {
		if (game.GetComponent<Spawner>().gameOver)
		{
			//afficher un gros game over
			if (score > highscore)
			{
				highscore = score;
			}
			PlayerPrefs.SetFloat("highscore", highscore);
		}
		if (game.GetComponent<Spawner>().lines != count)
		{
			count = game.GetComponent<Spawner>().lines;
			score = Mathf.Round(count * 10 * game.GetComponent<Spawner>().speed);
			if (name == "Score")
				theText.text = "Score:\n" + score;
			else if (name == "Lines")
				theText.text = "Lines:\n" + count;
		}
    }
}
