using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private Paddle paddle;
    private bool hasStarted=false;
    private Vector3 paddleToBallVector;
    private Rigidbody2D rigi;
    private void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        
	}

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            //paddle ro qofl mikone b ball!
            this.transform.position = paddle.transform.position + paddleToBallVector;
            //vaimise ta mouse ro click konim!topo bde hava.
            if (Input.GetMouseButtonDown(0))
            {
                hasStarted = true;
                this.rigi.velocity = new Vector2(2f, 10f);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 2f));
        if(hasStarted)
        {
            rigi.velocity += tweak;
        }
    }
}
