﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour, IPointerClickHandler
{
	public Colors	objects;
	public Spawner	piece;

    // Start is called before the first frame update
    void Start()
    {
		objects = GameObject.Find("Objects").GetComponent<Colors>();
		piece = GameObject.Find("Spawner").GetComponent<Spawner>();
    }

	public void OnPointerClick(PointerEventData data)
	{
		if (name == "Play")
		{
			objects.SetMenu(false);
			piece.SetPause(false);
		}
		else if (objects.GetMenu())
		{
			SceneManager.LoadScene("Menu");
			/*#if UNITY_EDITOR
         		UnityEditor.EditorApplication.isPlaying = false;
     		#else
         		Application.Quit();
     		#endif*/
		}
	}

	void Update()
	{
		if (objects.GetMenu())
		{
			GetComponent<Image>().color = Color.white;
		}
		else
		{
			GetComponent<Image>().color = new Color(0,0,0,0);
		}
	}
}
