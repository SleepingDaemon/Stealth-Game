using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayableDirector _introCutscene = null;
    [SerializeField] private GameObject[] _soundSources = null;
    
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
                Debug.Log("GameManager is null");
            
            return _instance;
        }
    }

    private bool _hasCard = false;

    public bool HasCard
    {
        get { return _hasCard; }
        set { _hasCard = value; }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _introCutscene.time = 60f;
            _soundSources[0].SetActive(false);
            _soundSources[1].SetActive(false);
            _soundSources[2].SetActive(false);
        }
    }
}
