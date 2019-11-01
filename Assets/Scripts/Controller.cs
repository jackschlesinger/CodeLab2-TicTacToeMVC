using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller
{
    private Model _model;

    public void Initialize(Model model)
    {
        _model = model;
    }
    
    public bool Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            return _model.MoveMade(0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            return _model.MoveMade(1, 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            return _model.MoveMade(2, 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            return _model.MoveMade(0, 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            return _model.MoveMade(1, 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            return _model.MoveMade(2, 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            return _model.MoveMade(0, 2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            return _model.MoveMade(1, 2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            return _model.MoveMade(2, 2);
        }

        if (Input.GetMouseButtonDown(0))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return _model.MoveMade(Mathf.RoundToInt(mousePos.x), Mathf.RoundToInt(mousePos.y));
        }

        return false;
    }
}
