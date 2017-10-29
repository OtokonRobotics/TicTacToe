using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map {

    private Moves[][] map;

	// Use this for initialization
    public Map()
    {
        this.map = new Moves[3][];
        for (int i = 0; i < 3; i++)
            this.map[i] = new Moves[3];
	}

    public void UpdateMap (int[] pos, Moves move){
        this.map[pos[0]][pos[1]] = move;
    }

    public bool IsGameFinished()
    {
        return (IsColumnSame(this.map) || IsRowSame(this.map)) || IsDigonalSame(this.map);
    }

    private bool IsThreeValueSame(Moves[] moves)
    {
        Moves _move = moves[0];
        if (_move == Moves.N)
            return false;

        foreach (var move in moves)
            if (move != _move)
                return false;
        return true;
    }

    private bool IsRowSame(Moves[][] map)
    {
        for (int row = 0; row < 3; row++){
            if (this.IsThreeValueSame(map[row]))
                return true;
        }
        return false;
    }

    private bool IsColumnSame(Moves[][] map)
    {
        Moves[][] transpose_map = Transpose(this.map);
        return IsRowSame(transpose_map);      
    }

    private bool IsDigonalSame(Moves[][] moves)
    {
        return IsThreeValueSame(FirstDiagonal(moves)) || IsThreeValueSame(SecondDiagonal(moves));
    }

    Moves[] FirstDiagonal(Moves[][] moves)
    {
        Moves[] diagonal = new Moves[3];
        for (int index = 0; index < moves.Length; index++)
            diagonal[index] = moves[index][index];
        return diagonal;
    }

    Moves[] SecondDiagonal(Moves[][] moves)
    {
        Moves[] diagonal = new Moves[3];
        for (int index = 0; index < moves.Length; index++)
            diagonal[index] = moves[index][2-index];
        return diagonal;
    }

    Moves[][] Transpose(Moves[][] moves)
    {
        Moves[][] result = new Moves[3][];
        for (int i = 0; i < 3; i++)
            result[i] = new Moves[3];

        for (int row = 0; row < moves.Length; row++)
            for (int column = 0; column < moves[0].Length; column++)
                result[column][row] = moves[row][column];

        return result;
    }
}
