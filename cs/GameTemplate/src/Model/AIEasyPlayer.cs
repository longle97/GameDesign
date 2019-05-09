
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
//using System.Data;
using System.Diagnostics;

/// <summary>
/// The AIEasyPlayer will shoot randomly on the ship
/// </summary>
public class AIEasyPlayer : AIPlayer
{
	/// <summary>
	/// Private enumarator for AI states. There is only one state which will
	/// make the AI randomly shoot on the grid
	/// </summary>
	private enum AIStates
	{
		Searching
	}

	private AIStates _CurrentState = AIStates.Searching;

	private Stack<Location> _Targets = new Stack<Location>();
	public AIEasyPlayer(BattleShipsGame controller) : base(controller)
	{
	}

	/// <param name="row">the generated row</param>
	/// <param name="column">the generated column</param>
	protected override void GenerateCoords(ref int row, ref int column)
	{
		do {
			switch (_CurrentState) {
				case AIStates.Searching:
					SearchCoords(ref row, ref column);
					break;
				default:
					throw new ApplicationException("AI has gone in an imvalid state");
			}
		} while ((row < 0 || column < 0 || row >= EnemyGrid.Height || column >= EnemyGrid.Width || EnemyGrid[row, column] != TileView.Sea));
		//while inside the grid and not a sea tile do the search
	}

	/// <summary>
	/// SearchCoords will randomly generate shots within the grid as long as its not hit that tile already
	/// </summary>
	/// <param name="row">the generated row</param>
	/// <param name="column">the generated column</param>
	private void SearchCoords(ref int row, ref int column)
	{
		row = _Random.Next(0, EnemyGrid.Height);
		column = _Random.Next(0, EnemyGrid.Width);
	}

	protected override void ProcessShot(int row, int col, AttackResult result)
	{
		switch (result.Value) {
			case ResultOfAttack.Miss:
				break;
			case ResultOfAttack.Hit:
				break;
			case ResultOfAttack.Destroyed:
				break;
			case ResultOfAttack.ShotAlready:
				throw new ApplicationException("Error in AI");
		}

		if (_Targets.Count == 0)
			_CurrentState = AIStates.Searching;
	}
}
