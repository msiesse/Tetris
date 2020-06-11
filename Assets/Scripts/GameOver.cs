using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
	public Spawner	current;
	public Colors	objects;
    // Start is called before the first frame update
    void Start()
    {
        current = GameObject.Find("Spawner").GetComponent<Spawner>();
		objects = GameObject.Find("Objects").GetComponent<Colors>();
    }

    // Update is called once per frame
    void Update()
    {
        if (current.gameOver)
		{
			StartCoroutine(waiter());
		}
    }

	IEnumerator waiter()
	{
		GetComponent<SpriteRenderer>().color = Color.white;
		objects.SetMenu(true);
		yield return new WaitForSecondsRealtime(2);
		SceneManager.LoadScene("Menu");
	}
}
