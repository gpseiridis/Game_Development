using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		
		Application.LoadLevel (name);
	}

	public void QuitRequest(){
		Debug.Log ("Game eXited");
		Application.Quit ();
	}

    public void LoadNextLevel()
    {
        //pass level based on the build settings and index.
        // level 1 ---> level 2 ---> .... ---> level N ---> Win Screen
        Application.LoadLevel(Application.loadedLevel + 1);
    }

}
 