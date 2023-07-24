using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private static MusicController McInstance;

    private void Awake()
    {
        if (McInstance == null)
        {
            McInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(McInstance != this) 
        {
            Destroy(gameObject);
        }
    }
}
