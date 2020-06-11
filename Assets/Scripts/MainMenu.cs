using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {

    }

	public void OnPointerClick(PointerEventData data)
	{
		if (name == "Play")
		{
			SceneManager.LoadScene("Game");
		}
		else if (name == "Home")
		{
			SceneManager.LoadScene("Menu");
		}
		else if (name == "Scores")
		{
			SceneManager.LoadScene("Scores");
		}
		else
		{
			#if UNITY_EDITOR
         		UnityEditor.EditorApplication.isPlaying = false;
     		#else
         		Application.Quit();
     		#endif
		}
	}

	void	OnDestroy()
	{
		PlayerPrefs.Save();
	}

    // Update is called once per frame
    void Update()
    {

    }
}
