using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    private Rigidbody rb;
    private Vector3 move;
    private Vector3 pos;
    private Vector3 init;
    private Vector3 dest;
    private float speed = 0.2f;
    private int changeDirection;
    private bool changeX;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        init = transform.position;
        move = new Vector3(0, 0, 0);
        dest = new Vector3(3, 0, 7);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(dest.x, dest.z) * Mathf.Rad2Deg, transform.eulerAngles.z);

    }

    // Update is called once per frame
    void Update () {
        float step = speed * Time.deltaTime;

        if (dest == transform.position)
        {
            dest = getRandomPoint();
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(dest.x, dest.z) * Mathf.Rad2Deg, transform.eulerAngles.z);
        }

        pos = transform.position;
        Debug.Log(rb.position);

        //rb.SetPosition((transform.eulerAngles * speed) + rb.GetPosition());
        //rb.velocity = Vector3.MoveTowards * speed;
       
        rb.position = Vector3.MoveTowards(transform.position, dest, speed);
        //rb.position += (transform.eulerAngles * speed);
    }


    Vector3 getRandomPoint()
    {
        Random rand = new Random();
        var x = Random.Range(0, 26);
        var y = Random.Range(0, 26);

        return new Vector3(x - 13, 0 ,y - 13);
    }
}
