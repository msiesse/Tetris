using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject[]		block;
	private int[]		current;
	public float			xo, yo, deltaX, deltaY;
	public GameObject		gameZone;
	public int				jBegin, iBig, jBig;
	public int				count;
	public int				k;
	public bool				spawned;

    // Start is called before the first frame update
    void Start()
    {
		jBegin = 4;
		xo = gameZone.GetComponent<BoxCollider2D>().bounds.min.x;
		yo = gameZone.GetComponent<BoxCollider2D>().bounds.max.y;
		deltaX = (gameZone.GetComponent<BoxCollider2D>().bounds.max.x - xo) / 9;
		deltaY = (gameZone.GetComponent<BoxCollider2D>().bounds.min.y - yo) / 19;
		current = new int[2];
    }

	private void SpawnTetraminos()
	{
		int	iBig, jBig;
		int	count;
		int	k;

		iBig = 0;
		count = 0;
		k = 0;
		for (int i = 0; i < 4; i++)
		{
			if (count != 0)
				iBig++;
			jBig = 0;
			for (int j = 0; j < 4; j++)
			{
				if (Tetraminos.tetra[i, j])
				{
					GameManager.bigGrid[iBig, jBig + jBegin] = Instantiate(block[0]
						, new Vector3(xo + deltaX * (jBig + jBegin), yo + deltaY * iBig)
							, Quaternion.identity);
					if (count == 0)
					{
						current[0] = iBig;
						current[1] = jBig + jBegin;
					}
					k++;
					jBig++;
					count++;
				}
			}
			if (count == 4)
				break ;
		}
		spawned = true;
	}

/*	private bool	CanGoRight()
	{

	}*/

    // Update is called once per frame
    void Update()
    {
		if (!spawned)
			SpawnTetraminos();
		if (Input.GetKeyDown("right") /*&& CanGoRight()*/)
		{
			for (int i = 0; i < 4; i++)
			{
				current[i].transform.position += new Vector3(deltaX, 0, 0);
			}
			current[0] = Instantiate(block[0]
				, new Vector3(xo + deltaX * 1, yo + deltaY * 1)
					, Quaternion.identity);
		}
		else if (Input.GetKeyDown("left"))
		{
			for (int i = 0; i < 4; i++)
			{
				current[i].transform.position -= new Vector3(deltaX, 0, 0);
			}
		}

    }
}
