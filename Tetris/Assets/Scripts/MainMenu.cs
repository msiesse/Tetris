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
			Debug.Log("lol");
			SceneManager.LoadScene("Game");
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

    // Update is called once per frame
    void Update()
    {

    }
}
