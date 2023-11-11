using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    GameObject playerPrefab;

    public static Player Player
    {
        get;
        private set;
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (Player == null && playerPrefab != null)
        {
            GameObject newPlayer = Instantiate(playerPrefab, transform.position, Quaternion.identity);
            Player = newPlayer.GetComponent<Player>();
        }
    }
}
