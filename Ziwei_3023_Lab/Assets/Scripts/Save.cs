using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Save : MonoBehaviour
{
    public GameObject PlayerFile;

    public void SaveGame()
    {
        SaveSystem.SavePlayer(PlayerFile.GetComponent<Player>());
        EditorSceneManager.LoadScene("StartMenu", UnityEngine.SceneManagement.LoadSceneMode.Single);
    }

}
