using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

    public SequenciaController gameController;

    private void OnMouseDown()
    {
        StartCoroutine(gameController.StartGame());
    }

    public void StartTutorial(){
            StartCoroutine(gameController.StartGameTutorial());
    }
}
