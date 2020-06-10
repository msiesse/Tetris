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
	private float			lastTime;
	public float			speed;
	public int				lines;
	public bool				gameOver;
	private AudioSource		puted;

    // Start is called before the first frame update
    void Start()
    {
		jBegin = 4;
		xo = gameZone.GetComponent<BoxCollider2D>().bounds.min.x;
		yo = gameZone.GetComponent<BoxCollider2D>().bounds.max.y;
		deltaX = (gameZone.GetComponent<BoxCollider2D>().bounds.max.x - xo) / 9;
		deltaY = deltaX/*(yo - gameZone.GetComponent<BoxCollider2D>().bounds.min.y) / 19*/;
		current = new GameObject[4];
		indexCurrent = new int[4, 2];
		lastTime = Time.time;
		lines = 0;
		speed = 1f;
		gameOver = false;
		puted = GetComponent<AudioSource>();
    }

	private bool IsSpawnable()
	{
		for (int j = 4; j < 8; j++)
		{
			if (GameManager.bigGrid[0, j] != null)
				return (false);
		}
		return (true);
	}
	private void SpawnTetraminos()
	{
		int	iBig, jBig;
		int	count;
		int	k;
		int	randomTetra;
		int	color;

		iBig = 0;
		count = 0;
		k = 0;
		randomTetra = (int)Mathf.Round(Random.Range(-0.5f, 0.5f));
		color = (int)Mathf.Round(Random.Range(-0.5f,3.5f));
		for (int i = 0; i < 4; i++)
		{
			if (count != 0)
				iBig++;
			jBig = 0;
			for (int j = 0; j < 4; j++)
			{
				if (Tetraminos.tetra[randomTetra, i, j] == 1)
				{
					GameManager.bigGrid[iBig, jBig + jBegin] = Instantiate(block[color]
						, new Vector3(xo + deltaX * (jBig + jBegin), yo - deltaY * iBig)
							, Quaternion.identity);
					current[count] = GameManager.bigGrid[iBig, jBig + jBegin];
					indexCurrent[count, 0] = iBig;
					indexCurrent[count, 1] = jBig + jBegin;
					k++;
					count++;
				}
				jBig++;
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

	private void RotateRight(Vector3 center)
	{
		float[]	delta;

		delta = new float[2];
		for (int i = 0; i < 4; i++)
		{
			delta[0] = (current[i].transform.position.x - center.x);
			delta[1] = current[i].transform.position.y - center.y;
			current[i].transform.Translate(new Vector3(-(delta[0] - delta[1]) , -(delta[1] + delta[0]), 0));
			GameManager.bigGrid[indexCurrent[i, 0], indexCurrent[i, 1]] = null;
			indexCurrent[i, 1] += (int)Mathf.Round(-(delta[0] - delta[1]) / deltaX);
			indexCurrent[i, 0] += (int)Mathf.Round((delta[1] + delta[0]) / deltaY);
		}
		for (int i = 0; i < 4; i++)
			GameManager.bigGrid[indexCurrent[i, 0], indexCurrent[i, 1]] = current[i];
	}

	private bool	CanRotateRight(Vector3 center)
	{
		float[]	delta;
		int[]	newIndexes;

		delta = new float[2];
		newIndexes = new int[2];
		for (int i = 0; i < 4; i++)
		{
			delta[0] = current[i].transform.position.x - center.x;
			delta[1] = current[i].transform.position.y - center.y;
			newIndexes[0] = indexCurrent[i, 0] + (int)Mathf.Round((delta[0] + delta[1]) / deltaX);
			newIndexes[1] = indexCurrent[i, 1] + (int)Mathf.Round(-(delta[0] - delta[1]) / deltaY);
			if (newIndexes[0] >= 20 || newIndexes[0] < 0 || newIndexes[1] < 0
				|| newIndexes[1] >= 10)
				return (false);
			else if (IsNeighboor(GameManager.bigGrid[newIndexes[0], newIndexes[1]]))
				return (false);
		}
		return (true);
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

	private void	DestroyLine(int i)
	{
		for (int j = 0; j < 10; j++)
		{
			Destroy(GameManager.bigGrid[i, j]);
			GameManager.bigGrid[i, j] = null;
		}
	}

	private void	DownLines(int i)
	{
		for (int k = (i - 1); k >= 0; k--)
		{
			for (int j = 0; j < 10; j++)
			{
				if (GameManager.bigGrid[k, j] != null)
				{
					GameManager.bigGrid[k, j].transform.Translate(new Vector3(0f, -deltaX, 0f));
					GameManager.bigGrid[k + 1, j] = GameManager.bigGrid[k, j];
					GameManager.bigGrid[k, j] = null;
				}
			}
		}
	}

	private int CheckLines()
	{
		int	i, j;
		int	count;

		count = 0;
		i = 19;
		while (i >= 0)
		{
			j = 0;
			while (j < 10)
			{
				if (GameManager.bigGrid[i, j] == null)
				{
					j++;
					break ;
				}
				j++;
			}
			if (GameManager.bigGrid[i, j - 1] != null)
			{
				DestroyLine(i);
				DownLines(i);
				count++;
				i++;
			}
			i--;
		}
		return (count);
	}

    // Update is called once per frame
    void Update()
    {
		int	check;

		if (!spawned && !IsSpawnable())
			gameOver = true;
		if (gameOver)
			return;
		if (!spawned)
		{
			check = CheckLines();
			lines += check;
			speed += 0.1f + 0.25f * check;
			SpawnTetraminos();
		}
		if (Input.GetKeyDown("right") && CanGoRight())
			MoveRight();
		else if (Input.GetKeyDown("left") && CanGoLeft())
			MoveLeft();
		else if (Input.GetKeyDown("d") && CanRotateRight(current[0].transform.position))
			RotateRight(current[0].transform.position);
		else if (Time.time - lastTime >= (1.0f / speed))
		{
			if (CanGoDown())
				MoveDown();
			else
			{
				spawned = false;
				puted.Play(0);
			}
			lastTime = Time.time;
		}
		if (Input.GetKeyDown("down"))
			speed *= 15f;
		if (Input.GetKeyUp("down"))
			speed /= 15f;
    }
}
