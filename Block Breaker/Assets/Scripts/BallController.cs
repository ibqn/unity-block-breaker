using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] PaddleController paddle;

    [SerializeField] Vector2 startVelocity;
    private Vector3 paddleToBall;

    private bool ballLaunched;

    private AudioSource audioSource;

    [SerializeField] AudioClip wallSound;
    [SerializeField] AudioClip paddleSound;
    [SerializeField] AudioClip blockSound;

    void Start()
    {
        paddleToBall = transform.position - paddle.transform.position;
        paddleToBall.x = 0f;

        ballLaunched = false;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ballLaunched)
        {
            LockBallToPaddle();
            LaunchBallOnClick();
        }
    }

    private void LaunchBallOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ballLaunched = true;
            GetComponent<Rigidbody2D>().velocity = startVelocity;
        }
    }

    private void LockBallToPaddle()
    {
        transform.position = paddle.transform.position + paddleToBall;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ballLaunched)
        {
            var clip = collision.gameObject.tag switch
            {
                "Paddle" => paddleSound,
                "Block" => blockSound,
                "Wall" => wallSound,
                _ => null
            };

            if (clip != null)
            {
                audioSource.PlayOneShot(clip);
            }
        }
    }
}
