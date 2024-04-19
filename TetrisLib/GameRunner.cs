using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisLib;

public class GameRunner
{
	public ITetroid heldTetroid { get; set; }
	public ITetroid activeTetroid { get; set; }
	public List<ITetroid> hand { get; set; }
	public Board CurrentBoard { get; set; }
	public int Score { get; set; }
	private Random random;

	public GameRunner() : this(70) { }

	public GameRunner(int seed)
	{
		random = new Random(seed);
		Board.PieceHitWall += (i) => PlacePiece();
	}

	public void GameStart()
	{
		activeTetroid = GetRandomTetroid();

		hand = new List<ITetroid>(5);
		for (int i = 0; i < hand.Capacity; i++)
		{
			hand.Add(GetRandomTetroid());
		}

		CurrentBoard = new();

		Score = 0;
	}

	public void PlacePiece()
	{
		activeTetroid = hand.FirstOrDefault();
		hand.Remove(activeTetroid);
		hand.Add(GetRandomTetroid());
	}

	public void AdvanceGameState()
	{
		MoveActivePieceDown();

		//Ltes just try this and display it!
	}

	public void MoveActivePieceDown()
	{
		RemoveActiveFromBoardDoSomethingThenAddBack(() => activeTetroid.MoveDown());
	}

	private void RemoveActiveFromBoardDoSomethingThenAddBack(TetroidMovement tetroidMovement)
	{
		CurrentBoard -= activeTetroid;
		tetroidMovement.Invoke();
		CurrentBoard += activeTetroid;
	}


	public void MoveActivePieceRight()
	{
		RemoveActiveFromBoardDoSomethingThenAddBack(() => activeTetroid.MoveRight());
	}

	public void MoveActivePieceLeft()
	{
		RemoveActiveFromBoardDoSomethingThenAddBack(() => activeTetroid.MoveLeft());
	}
	public void RotateActivePieceLeft()
	{
		RemoveActiveFromBoardDoSomethingThenAddBack(() => activeTetroid.RotateLeft());
	}

	public void RotateActivePieceRight()
	{
		RemoveActiveFromBoardDoSomethingThenAddBack(() => activeTetroid.RotateRight());
	}

	private ITetroid GetRandomTetroid()
	{
		switch (random.Next(0, 7))
		{
			case 0:
				return new I();
			case 1:
				return new L();
			case 2:
				return new Z();
			case 3:
				return new R();
			case 4:
				return new S();
			case 5:
				return new T();
			case 6:
				return new O();
		}
		throw new Exception("We just made a new tetroid");
	}
}

internal delegate void TetroidMovement();