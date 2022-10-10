using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 20.0f;

    // Update is called once per frame
    void Update()
    {

        var move = new Vector3(0, 0, Input.GetAxis("PlayerPong"));
        transform.position += move * moveSpeed * Time.deltaTime;

    }
}
