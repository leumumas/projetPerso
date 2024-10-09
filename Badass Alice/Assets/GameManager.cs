using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Serializable]
    public enum GameScenes
    {
        Hub,
        GymPlateformer
    }

    private static GameManager _gameManager;

    public static GameManager Instance
    {
        get
        {
            if (_gameManager == null)
            {
                _gameManager = new GameManager();
            }
            return _gameManager;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Hub");
    }
}
