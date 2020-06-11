using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler
{
	public Spawner	piece;
	public Colors	objects;
	public Sprite	play, pause;

	void Start()
	{
		piece = GameObject.Find("Spawner").GetComponent<Spawner>();
		objects = GameObject.Find("Objects").GetComponent<Colors>();
	}
	public void	OnPointerDown(PointerEventData data)
	{
		if (name == "Left")
		{
			piece.SetMoveLeft(true);
		}
		else if (name == "Right")
		{
			piece.SetMoveLeft(false);
		}
		else if (name == "Down")
		{
			piece.SetMoveDown(1);
		}
	}

	public void OnPointerClick(PointerEventData data)
	{
		if (name == "Rotate")
		{
			piece.SetRotate(true);
		}
		else if (name == "Pause" && !objects.GetMenu())
		{
			piece.SetPause();
			if (GetComponent<Image>().sprite == pause)
				GetComponent<Image>().sprite = play;
			else
				GetComponent<Image>().sprite = pause;
		}
		else if (name == "Home")
		{
			objects.SetMenu(true);
			piece.SetPause(true);
		}
	}

	public void	OnPointerUp(PointerEventData data)
	{
		piece.StopMove();
	}
}
