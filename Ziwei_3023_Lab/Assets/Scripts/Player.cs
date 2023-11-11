using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public string LastSpawnPointName
    {
        get;
        set;
    } = "";
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(SaveSystem.SaveStart);
        if (SaveSystem.SaveStart)
        {
            PlayerData data = SaveSystem.LoadPlayer();
            Vector3 position = new Vector3(data.position[0], data.position[1], data.position[2]);
            transform.position = position;
        }

#if UNITY_EDITOR
        DestroySelfIfNotOriginal();
#endif


        SceneManager.sceneLoaded += OnSceneLoadAction;

    }

    private void DestroySelfIfNotOriginal()
    {
        if (SpawnPoint.Player != this)
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoadAction(Scene scene, LoadSceneMode loadMode)
    {
        if (LastSpawnPointName != "")
        {
            SpawnPoint[] spawnPoints = GameObject.FindObjectsOfType<SpawnPoint>();
            foreach (SpawnPoint spawn in spawnPoints)
            {
                if (spawn.name == LastSpawnPointName)
                {
                    transform.position = spawn.transform.position;
                }
            }
        }
    }
}