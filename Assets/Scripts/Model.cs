using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model
{
    public enum GridSquare
    {
        Empty,
        X,
        O,
    }

    public GridSquare[,] grid;
    public int width, height;

    public bool isXTurn = false;

    public bool gameIsOver = false;
    
    public void Initialize()
    {
        width = 3;
        height = 3;

        grid = new GridSquare[width, height];
    }

    public bool MoveMade(int x, int y)
    {
        if (x < 0 || x >= width) return false;
        if (y < 0 || y >= height) return false;
        if (grid[x, y] != GridSquare.Empty) return false;
        if (gameIsOver) return false;
        
        grid[x, y] = isXTurn ? GridSquare.X : GridSquare.O;

        isXTurn = !isXTurn;

        _CheckWinCondition();

        return true;
    }

    private void _CheckWinCondition()
    {

        for (var i = 0; i < width; i++)
        {
            // Vertical win conditions
            if (grid[i,0] != GridSquare.Empty && 
                grid[i,0] == grid[i,1] && grid[i,0] == grid[i,2])
            {
                GameController.TransitionState(GameController.GameState.GameOver);
                GameController.PlayerWon(grid[i, 0]);
            }
            
            // Horizontal win conditions
            if (grid[0, i] != GridSquare.Empty && 
                grid[0, i] == grid[1,i] && grid[0,i] == grid[2,i])
            {
                GameController.TransitionState(GameController.GameState.GameOver);
                GameController.PlayerWon(grid[0, i]);
            }
        }
        
        // diagonal check
        
        if (grid[0,0] != GridSquare.Empty && grid[0,0] == grid[1,1] && grid[0,0] == grid[2,2])
        {
            GameController.TransitionState(GameController.GameState.GameOver);
            GameController.PlayerWon(grid[0, 0]);
        }

        if (grid[2,0] != GridSquare.Empty && grid[2,0] == grid[1,1] && grid[2,0] == grid[0,2])
        {
            GameController.TransitionState(GameController.GameState.GameOver);
            GameController.PlayerWon(grid[2, 0]);
        }

    }
}
