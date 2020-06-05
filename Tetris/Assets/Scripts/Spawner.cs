using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject[]		block;
	private GameObject[]	current;
	private int[,]			indexCurrent;
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
		deltaY = (yo - gameZone.GetComponent<BoxCollider2D>().bounds.min.y) / 19;
		current = new GameObject[4];
		indexCurrent = new int[4, 2];
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
					current[count] = GameManager.bigGrid[iBig, jBig + jBegin];
					indexCurrent[count, 0] = iBig;
					indexCurrent[count, 1] = jBig + jBegin;
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

	private bool	IsNeighboor(GameObject element)
	{
		for (int i = 0; i < 4; i++)
		{
			if (element == current[i])
				return (false);
		}
		if (element != null)
			return (true);
		return (false);
	}

	private void	MoveRight()
	{
		for (int i = 0; i < 4; i++)
		{
			current[i].transform.position += new Vector3(deltaX, 0, 0);
			GameManager.bigGrid[indexCurrent[i, 0], indexCurrent[i, 1]] = null;
			indexCurrent[i, 1]++;
		}
		for (int i = 0; i < 4; i++)
			GameManager.bigGrid[indexCurrent[i, 0], indexCurrent[i, 1]] = current[i];
	}

	private void	MoveLeft()
	{
		for (int i = 0; i < 4; i++)
		{
			current[i].transform.position -= new Vector3(deltaX, 0, 0);
			GameManager.bigGrid[indexCurrent[i, 0], indexCurrent[i, 1]] = null;
			indexCurrent[i, 1]--;
		}
		for (int i = 0; i < 4; i++)
			GameManager.bigGrid[indexCurrent[i, 0], indexCurrent[i, 1]] = current[i];
	}

	private void	MoveDown()
	{
		for (int i = 0; i < 4; i++)
		{
			current[i].transform.position -= new Vector3(0, deltaY, 0);
			GameManager.bigGrid[indexCurrent[i, 0], indexCurrent[i, 1]] = null;
			indexCurrent[i, 0]++;
		}
		for (int i = 0; i < 4; i++)
			GameManager.bigGrid[indexCurrent[i, 0], indexCurrent[i, 1]] = current[i];
	}

	private bool	CanGoRight()
	{
		for (int i = 0; i < 4; i++)
		{
			if ((indexCurrent[i, 1] + 1) >= 10)
				return (false);
			else if (IsNeighboor(GameManager.bigGrid[indexCurrent[i, 0], indexCurrent[i, 1] + 1]))
				return (false);
		}
		return (true);
	}

	private bool	CanGoLeft()
	{
		for (int i = 0; i < 4; i++)
		{
			if ((indexCurrent[i, 1] - 1) < 0)
				return (false);
			else if (IsNeighboor(GameManager.bigGrid[indexCurrent[i, 0], indexCurrent[i, 1] - 1]))
				return (false);
		}
		return (true);
	}

	private bool	CanGoDown()
	{
		for (int i = 0; i < 4; i++)
		{
			if ((indexCurrent[i, 0] + 1) >= 20)
				return (false);
			else if (IsNeighboor(GameManager.bigGrid[indexCurrent[i, 0] + 1, indexCurrent[i, 1]]))
				return (false);
		}
		return (true);
	}

    // Update is called once per frame
    void Update()
    {
		if (!spawned)
			SpawnTetraminos();
		if (Input.GetKeyDown("right") && CanGoRight())
		{
			MoveRight();
		}
		else if (Input.GetKeyDown("left") && CanGoLeft())
		{
			MoveLeft();
		}
/*		else if (Input.GetKeyDown("down") && CanGoDown()) // Debug
		{
			MoveDown();
		}
		else if (Input.GetKeyDown("up")) // Debug
		{
			for (int i = 0; i < 4; i++)
				current[i].transform.position += new Vector3(0, deltaY, 0);
		}*/
		else if (Input.GetKeyDown("space")) // Debug
		{
			SpawnTetraminos();
		}
    }
}
