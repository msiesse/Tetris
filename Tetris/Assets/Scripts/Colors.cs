using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Colors : MonoBehaviour
{
	public SpriteRenderer[]	sprites;
	public Image[]			images;
	private bool			menu;

	public void		SetMenu(bool value)
	{
		this.menu = value;
	}

    // Update is called once per frame
    void Update()
    {
		if (menu)
		{
			sprites = GetComponentsInChildren<SpriteRenderer>();
			images = GetComponentsInChildren<Image>();
			foreach (SpriteRenderer sprite in sprites)
			{
				sprite.color = new Color(1,1,1,0.2f);
			}
			foreach (Image image in images)
			{
				image.color = new Color(1,1,1,0.2f);
			}
		}
		else
		{
			sprites = GetComponentsInChildren<SpriteRenderer>();
			images = GetComponentsInChildren<Image>();
			foreach (SpriteRenderer sprite in sprites)
			{
				sprite.color = new Color(1,1,1,1);
			}
			foreach (Image image in images)
			{
				image.color = new Color(1,1,1,1);
			}
		}
    }
}
