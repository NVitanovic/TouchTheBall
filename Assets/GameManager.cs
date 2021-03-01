using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player1;
    public GameObject player2;
    public GameObject ball;
    public GameObject obstacle;
    public ParticleSystem winParticles;
    public UnityEngine.UI.Text scoreText;
    private float initialBallHeight;
    private float lastObstacleSpawn;
    private int score { get; set; }
    private Vector3 scaleChange;
    void Start()
    {
        score = 0;
        winParticles.Stop();
        var main = winParticles.main;
        main.loop = false;
        main.startLifetime = 0.5f;
        initialBallHeight = ball.transform.position.y;
        scaleChange = new Vector3(-0.1f, -0.1f, -0.1f);
        lastObstacleSpawn = 0;
    }
    public void ReinitializeGame()
    {
        winParticles.Stop();
        winParticles.Play();
        score++;
        ball.SetActive(true);
        winParticles.transform.SetPositionAndRotation(ball.transform.position, winParticles.transform.rotation);

        //Reset player positions and rotations
        //Respawn new ball object and set new reference
        Vector3 randomBallPosition = new Vector3(Random.Range(-6, 6), initialBallHeight, Random.Range(-6, 6));
        Vector3 randomPlayer1Position = new Vector3(Random.Range(-6, 6), 0, Random.Range(-6, 6));
        Vector3 randomPlayer2Position = new Vector3(Random.Range(-6, 6), 0, Random.Range(-6, 6));
        ball.transform.SetPositionAndRotation(randomBallPosition, ball.transform.rotation);

        // Change ball scale only if magnitude of scale vector is greater than 0.5
        // this limits the ball size to a minimum scale, so it does not dissapear.
        if (ball.transform.localScale.magnitude >= 0.5)
            ball.transform.localScale += scaleChange;
        
        player1.transform.position = randomPlayer1Position;
        player2.transform.position = randomPlayer2Position;
    }
    void Update()
    {
        
        scoreText.text = string.Format("Score: {0}", score);
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        // Spawn obstacles to annoy the player
        lastObstacleSpawn += Time.deltaTime;
        if (lastObstacleSpawn > 10)
        {
            lastObstacleSpawn = 0;
            Instantiate(obstacle, new Vector3(Random.Range(-6, 6), 0, Random.Range(-6, 6)), Quaternion.identity);

            //Periodically apply a ranodm force to a ball to annoy the player even more
                ball.GetComponent<Rigidbody>().AddForce(score, score, score);
        }
    }
}
