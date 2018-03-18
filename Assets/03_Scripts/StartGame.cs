using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {


    public GameController gameController;

    private void OnMouseDown()
    {
        gameController.StartGame();
    }
}
