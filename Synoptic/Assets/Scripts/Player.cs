using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{


    [SerializeField] float moveSpeed = 10f;

    [SerializeField] float xpadding = 0.4f;

    [SerializeField] float ypadding = 1.8f;

    [SerializeField] GameObject footballPrefab;

    [SerializeField] float kickTime = 2f;

    [SerializeField] AudioClip music;

    [SerializeField] [Range(0, 1)] float musicVolume = 0.75f;

   

    float xMin, xMax, yMin, yMax;


    Coroutine kickCoroutine;



    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
        AudioSource.PlayClipAtPoint(music, Camera.main.transform.position, musicVolume);
    }


    // Update is called once per frame
    void Update()
    {
        Move();
        Kick();
    }

    private IEnumerator kickContinuously()
    {
        while (true)
        {
            //kick a ball
            GameObject football = Instantiate(footballPrefab, transform.position, Quaternion.identity);
            // Ask teacher tmrw 
            //gives velocity to each ball
            football.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 15f);

            yield return new WaitForSeconds(kickTime);



        }

    }




    private void Kick()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            kickCoroutine = StartCoroutine(kickContinuously());
        }

        if(Input.GetButtonUp("Fire1"))
        {

            StopCoroutine(kickCoroutine);
        }


    }


    




    //boundaries
    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + xpadding;

        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - xpadding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + ypadding;

        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - ypadding;

    }
    


    // Moves the player
    private void Move()
    {
        // deltax changes on player movment
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        //current x + deltaX
        var newXPos = transform.position.x + deltaX;
        newXPos = Mathf.Clamp(newXPos, xMin, xMax);

        // deltax changes on player movment
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        //current y + deltaY
        var newYPos = transform.position.y + deltaY;
        newYPos = Mathf.Clamp(newYPos, yMin, yMax);

        //move the player to the new x position
        this.transform.position = new Vector2(newXPos, newYPos);


    }




}
