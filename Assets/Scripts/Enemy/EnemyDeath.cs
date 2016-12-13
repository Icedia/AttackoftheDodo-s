using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour {

   [SerializeField]private int _health;
   private Score _score;

   void Start() 
   {
       _score = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<Score>();
   }

	void Update () 
    {
        checkHealth();
	}
    void OnMouseDown()
    {
        _health = _health - 10;
    }
    void checkHealth() 
    {
        if (_health <= 0)
        {
            _score.MyScore += 10;
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }

    }
}
