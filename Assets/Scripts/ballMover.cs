using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ballMover : MonoBehaviour
{
    [Tooltip("speed")]
    [SerializeField]
    float speed;

    [Tooltip("radius")]
    [SerializeField]
    float radius;

    float rx, ry, vx, vy;

    void Start()
    {
        // מהירות תזוזה אקראית על כל אחד מהצירים
        vx = UnityEngine.Random.Range(0.0f, 1.0f);
        vy = UnityEngine.Random.Range(0.0f, 1.0f);

        // מיקום התחלתי ארקאי על כל אחד מהצירים
        //rx = UnityEngine.Random.Range(0.0f, 1.0f);
        //ry = UnityEngine.Random.Range(0.0f, 1.0f);
        rx = transform.position.x;
        ry = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(radius, radius, transform.localScale.z);
        if (vx > 0)
            vx = speed;
        else
            vx = -speed;

        if (vy > 0)
            vy = speed;
        else
            vy = -speed;

        if (Math.Abs(rx + vx) + radius > 10)
            vx *= -1;
        if (Math.Abs(ry + vy) + radius > 5)
            vy *= -1;

        rx += vx;
        ry += vy;

        // הזזת הכדור למקומו החדש
        transform.position = new Vector3(
            // transform.position.x + direction * Time.deltaTime,
            rx,
            ry,
            transform.position.z);
    }
}
