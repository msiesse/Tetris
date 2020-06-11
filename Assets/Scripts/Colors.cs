using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Colors : MonoBehaviour
{
	public SpriteRenderer[]	sprites;
	public Image[]			images;
	public Text[]			texts;
	private bool			menu;

	public void		SetMenu(bool value)
	{
		this.menu = value;
		sprites = GetComponentsInChildren<SpriteRenderer>();
		images = GetComponentsInChildren<Image>();
		texts = GetComponentsInChildren<Text>();
	}

	public bool		GetMenu()
	{
		return (this.menu);
	}

    // Update is called once per frame
    void Update()
    {
		if (menu)
		{
			foreach (SpriteRenderer sprite in sprites)
			{
				sprite.color = new Color(1,1,1,0.2f);
			}
			foreach (Image image in images)
			{
				image.color = new Color(1,1,1,0.2f);
			}
			foreach (Text text in texts)
			{
				text.color = new Color(1,1,1,0.2f);
			}
		}
		else
		{
			foreach (SpriteRenderer sprite in sprites)
			{
				sprite.color = new Color(1,1,1,1);
			}
			foreach (Image image in images)
			{
				image.color = new Color(1,1,1,1);
			}
			foreach (Text text in texts)
			{
				text.color = new Color(1,1,1,1);
			}
		}
    }
}
