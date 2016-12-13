using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    [SerializeField]private int _movementSpeed = 10;

    void Update()
    {
        transform.Translate(Vector3.right * _movementSpeed * Time.deltaTime);
    }
}
