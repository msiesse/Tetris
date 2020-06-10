using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
	public Spawner	piece;

	void Start()
	{
		piece = GameObject.Find("Spawner").GetComponent<Spawner>();
	}
	public void	OnPointerDown(PointerEventData data)
	{
		if (name == "Left")
		{
			piece.SetMoveLeft(true);
		}
		else
		{
			piece.SetMoveLeft(false);
		}
	}

	public void	OnPointerUp(PointerEventData data)
	{
		piece.StopMove();
	}
}
