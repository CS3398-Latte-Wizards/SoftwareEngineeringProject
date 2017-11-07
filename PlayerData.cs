using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour {

   public static PlayerData data;

    public int score;
    public int scoreValue;
    public bool gameOver;
	
	void Awake ()
    {
        DontDestroyOnLoad(this);
        if (data == null)
        {
            DontDestroyOnLoad(this);
            data = this;
            

        }
        else if (data != this)
        {
            Destroy(gameObject);
        }
        
    }

    


    /*void Update ()
    {
        
    }*/
}
