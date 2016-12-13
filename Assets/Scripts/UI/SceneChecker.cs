using UnityEngine;
using System.Collections;

public class SceneChecker : MonoBehaviour {


	void Awake ()
    {
        LastScene.setLastLevel(Application.loadedLevelName);    
	}
	
}
