using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {


    public float speed = 30;
    private Rigidbody2D rigiBody;
    private AudioSource audiosource;

	// Use this for initialization
	void Start () {
        rigiBody = GetComponent<Rigidbody2D>();
        rigiBody.velocity = Vector2.right * speed;
	}


    private void OnCollisionEnter2D(Collision2D collision)
    {

        //LeftPaddle or RigtPddale
        if((collision.gameObject.name=="LeftPaddle") || (collision.gameObject.name=="RightPaddle"))
        {

            handlePaddleHit(collision);

        }
        //WallBattom or Walltop
        if ((collision.gameObject.name == "WallBottom") || (collision.gameObject.name == "WallTop"))
        {

            SoundManager.Instant.PlayOneShoot(SoundManager.Instant.wallBloop);

        }

        //Left Goal or Right Goal
        if ((collision.gameObject.name == "LeftGoal") || (collision.gameObject.name == "RightGoal"))
        {

            SoundManager.Instant.PlayOneShoot(SoundManager.Instant.goolBloop);


            if(collision.gameObject.name=="LeftGoal")
            {
                IncreaseScore("RightScoreUI");
            }
            else
            {
                IncreaseScore("LeftScoreUI");
            }
            transform.position = new Vector2(0, 0);

        }

    }


    void handlePaddleHit(Collision2D col)
    {
        float y = ballHitPaddleWhere(transform.position, col.transform.position, col.collider.bounds.size.y);

        Vector2 dir = new Vector2();

        if (col.gameObject.name=="LeftPaddle")
        {
            dir = new Vector2(1, y).normalized;
        }
        if (col.gameObject.name == "RightPaddle")
        {
            dir = new Vector2(-1, y).normalized;
        }

        rigiBody.velocity = dir * speed;
        SoundManager.Instant.PlayOneShoot(SoundManager.Instant.hitPaddleBloop);
    }


    float ballHitPaddleWhere(Vector2 ball,Vector2 paddle,float paddleHeight)
    {

        return (ball.y - paddle.y) / paddleHeight;

    }
    // Update is called once per frame
    void Update () {
		
	}


    void IncreaseScore(string TextUIName)
    {
        var textUIComp = GameObject.Find(TextUIName).GetComponent<Text>();

        int score = int.Parse(textUIComp.text);

        score++;

        textUIComp.text = score.ToString();
    }
}
