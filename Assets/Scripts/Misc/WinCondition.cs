using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour {

    private Score _score;

    void Start()
    {
        _score = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<Score>();
    }
	
	void Update ()
    {
        if (_score.MyScore == 500)
            SceneManager.LoadScene("level2");
	}
}
