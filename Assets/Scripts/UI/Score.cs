using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text MyText;
    private int _score;
    public int MyScore
    {
        get { return _score; }
        set { _score = value; }
    }

    void Start()
    {
        MyText = MyText.GetComponent<Text>();
        _score = 0;
    }

    void Update()
    {
        MyText.text = "Score:" + _score;
    }

}
