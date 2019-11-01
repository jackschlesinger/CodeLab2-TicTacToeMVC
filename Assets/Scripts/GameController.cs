using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Model _model;
    private View _view;
    private Controller _controller;
    private static int XWins, OWins;

    public enum GameState
    {
        GameInProgress,
        GameOver
    }

    private static GameState currentState = GameState.GameInProgress;
    
    // Start is called before the first frame update
    void Start()
    {
        _StartGame();
    }

    public static void PlayerWon(Model.GridSquare winner)
    {
        switch (winner)
        {
            case Model.GridSquare.X:
                XWins++;
                break;
            case Model.GridSquare.O:
                OWins++;
                break;
        }

        Debug.Log("X: " + XWins + " | O: " + OWins);
    }

    private void _StartGame()
    {
        _model = new Model();
        _model.Initialize();

        if (_view != null) 
            _view.Destroy();
        
        _view = new View();
        _view.Initalize(_model);

        _controller = new Controller();
        _controller.Initialize(_model);
        
        currentState = GameState.GameInProgress;
    }

    public static void TransitionState(GameState toTransitionTo)
    {
        currentState = toTransitionTo;
    }

    // Update is called once per frame
    private void Update()
    {
        switch (currentState)
        {
            case GameState.GameInProgress:
                if (_controller.Update())
                    _view.UpdateView();
                break;
            case GameState.GameOver:
                if (Input.GetKeyDown(KeyCode.R))
                    _StartGame();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
