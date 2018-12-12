using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public enum GameState { play, pause, end};
    public GameState currentState = GameState.play;
    public GameObject pausedUI;
    public GameObject endUI;

    private static GameManager Instance;

    public static GameManager GetInstance()
    {
        return Instance;
    }
    
    // Use this for initialization
	void Start ()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;
	}
	
	// Update is called once per frame
	void Update ()
    {
        switch(currentState)
        {
            case GameState.play:
                Play();
                break;
            case GameState.pause:
                Pause();
                break;
            case GameState.end:
                End();
                break;
        }

        if(EnemyControl.numberofEns > 10)
        {

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentState == GameState.play)
            {
                currentState = GameState.pause;
            }
            else if (currentState == GameState.pause)
            {
                currentState = GameState.play;
            }
        }

        if(winStar.levelEnd == true)
        {
            if (currentState == GameState.play)
            {
                currentState = GameState.end;
            }
        }
		
	}

    void Play()
    {
        CharacterControl.instance.enabled = true;
        pausedUI.SetActive(false);
        Time.timeScale = 1;
    }

    void Pause()
    {
        CharacterControl.instance.enabled = false;
        pausedUI.SetActive(true);
        Time.timeScale = 0;
    }

    void End()
    {
        CharacterControl.instance.enabled = false;
        endUI.SetActive(true);
        Time.timeScale = 0;
    }
}
