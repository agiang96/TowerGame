using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TargetController : MonoBehaviour 
{

    [SerializeField]
    private Text scoreText;

    private int score = 0;

    /*
    [SerializeField]
    private Transform _explosionSpawn;
    [SerializeField]
    private Transform _explosionPrefab;
    */

    private void Start()
    {
        UpdateScore();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("cannonball"))
        {
            score++;
            UpdateScore();

            /*****************************************
             * This is for the particle effect
             ****************************************** 
             * var ex = Instantiate(_explosionPrefab, _explosionSpawn.position, Quaternion.identity) as GameObject;
             * ex.GetComponent<ParticleSystem().Play();
             ****************************************** 
             */
        }
    }

    void UpdateScore()
    {
        scoreText.text = "" + score;
    }
}
