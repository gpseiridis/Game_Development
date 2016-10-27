using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
    static MusicPlayer musicPlayerInstance = null;
	
    void Awake()
    {
        if (musicPlayerInstance != null)
        {
            Destroy(gameObject);
            print("destroyed duplicated music player");
        }
        else
        {
            musicPlayerInstance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }


	
	// Update is called once per frame
	void Update () {
	
	}
}
