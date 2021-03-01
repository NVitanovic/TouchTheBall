using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    private List<string> collisions;
    public GameManager gm;
    private float initialBallHeight;
    void Start()
    {
        collisions = new List<string>();
        initialBallHeight = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y <= 0)
        {
            Vector3 randomBallPosition = new Vector3(Random.Range(-6, 6), initialBallHeight, Random.Range(-6, 6));
            gameObject.transform.SetPositionAndRotation(randomBallPosition, gameObject.transform.rotation);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        collisions.Add(collision.transform.tag);

        if (collisions.Contains("P1") && collisions.Contains("P2"))
        {
            Debug.Log("Collision WIN!");
            gm.ReinitializeGame();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        collisions.Remove(collision.transform.tag);
    }
}
