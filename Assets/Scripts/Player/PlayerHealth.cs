using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]private int _playerHealth;
    public Text MyText;

	void Start () {
        _playerHealth = 3;
        MyText = MyText.GetComponent<Text>();
	}
	
	void Update ()
    {
        if (_playerHealth <= 0) 
        {
            SceneManager.LoadScene("Defeat");
        }
        MyText.text = "Lives left: " + _playerHealth;
	}
    void OnCollisionEnter2D(Collision2D coll) 
    {
        if (coll.gameObject.tag == "Enemy")
        {
            _playerHealth -= 1;
        }
        if (coll.gameObject.tag == "Border")
        {
            _playerHealth -= 3;
        }
    }
}
