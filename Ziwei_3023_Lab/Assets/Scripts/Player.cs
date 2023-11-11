using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Start()
    {
        Debug.Log(SaveSystem.SaveStart);
        if (SaveSystem.SaveStart)
        {
            PlayerData data = SaveSystem.LoadPlayer();
            Vector2 position = new Vector2(data.position[0], data.position[1]);
            transform.position = position;
        }
    }

}
