using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float thrust = 500.0f;
    public Vector3 initialImpulse;
    public GameController Controller;
    public AudioClip cheer;
    public AudioClip aww;
    AudioSource audioSource;


    public void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.right * -thrust);
        GetComponent<Rigidbody>().AddForce(initialImpulse, ForceMode.Impulse);
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerGoal")
        {
            Controller.IncrementCompScore();
            Controller.ResetBall();
            audioSource.PlayOneShot(aww, 0.5f);
        }
        else if (other.gameObject.tag == "CompGoal")
        {
            Controller.IncrementPlayerScore();
            Controller.ResetBall();
            audioSource.PlayOneShot(cheer, 0.5f);
        }

        
    }
}

