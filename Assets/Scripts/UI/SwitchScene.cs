using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour {

    [SerializeField]private string Destination;

    public void LoadScene() 
    {
        SceneManager.LoadScene(Destination);
    }
    public void RetryScene()
    {
        LastScene.getLastLevel();
        LastScene.changeToPreviousLvl();
    }
}
