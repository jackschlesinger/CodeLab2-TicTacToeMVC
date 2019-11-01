using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class View
{
    private GameObject _xPrefab, _oPrefab;
    private Model _model;
    private Transform spawnedObjectHolder;

    public void Initalize(Model model)
    {
        _xPrefab = Resources.Load<GameObject>("X");
        _oPrefab = Resources.Load<GameObject>("O");

        _model = model;
        
        spawnedObjectHolder = new GameObject("Current View").transform;
    }

    public void Destroy()
    {
        Object.Destroy(spawnedObjectHolder.gameObject);
    }

    public void ShowGameOver()
    {
        // draw line showing game is over
    }
    
    public void UpdateView()
    {
        foreach (Transform child in spawnedObjectHolder)
        {
            Object.Destroy(child.gameObject);
        }

        if (_model.gameIsOver) ShowGameOver();
        
        for (var x = 0; x < _model.width; x++)
        {
            for (var y = 0; y < _model.height; y++)
            {
                switch (_model.grid[x, y])
                {
                    case Model.GridSquare.Empty:
                        break;
                    case Model.GridSquare.X:
                        Object.Instantiate(_xPrefab, new Vector2(x, y), Quaternion.identity, spawnedObjectHolder);
                        break;
                    case Model.GridSquare.O:
                        Object.Instantiate(_oPrefab, new Vector2(x, y), Quaternion.identity, spawnedObjectHolder);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
            }
        }
    }
}
