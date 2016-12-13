using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour {

    [SerializeField]private string Destination;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(Destination);
        }
    }
}
