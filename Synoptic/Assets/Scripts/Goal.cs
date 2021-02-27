using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField] AudioClip scoreSound;

    [SerializeField] [Range(0, 1)] float scoreSoundVolume = 0.75f;

    void start()
    {
        AudioSource.PlayClipAtPoint(scoreSound, Camera.main.transform.position, scoreSoundVolume);

    }

    void update()
    {
        if (ScoreScript.scoreValue > 20){
            SceneManager.LoadScene(sceneBuildIndex:2);
        }
    }



    private void OnTriggerEnter2D(Collider2D football)
    {
        print("Collision with " + football.name);
        ScoreScript.scoreValue += 1;
        Destroy(football.gameObject);

    }
}
