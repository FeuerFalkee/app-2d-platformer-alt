using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public AnimationCurve curve;

   Vector3 startPosition;

   public float height = 1;

   public float speed = 1;

    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPosition + new Vector3(0, curve. Evaluate(Time.time * speed) * height, 0);
    }
}
