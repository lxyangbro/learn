using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLaunch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        XLuaManager.Instance.StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
