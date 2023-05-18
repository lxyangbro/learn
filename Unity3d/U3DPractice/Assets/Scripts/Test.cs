using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // PlayerModel.Instance.Show();
            // PlayerModel.Instance.Add();
            // PlayerModel.Instance.Show();
            
            MyUIManager.Instance.Show();
            MyUIManager.Instance.Hide();
        }
    }
}
