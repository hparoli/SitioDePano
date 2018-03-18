using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour {

    public int idButton;

    public GameController gameController;


    private void OnMouseDown()
    {
        if(gameController.gameState == GameState.RESPONDER)
            gameController.StartCoroutine("Responder", idButton);
    }
}
