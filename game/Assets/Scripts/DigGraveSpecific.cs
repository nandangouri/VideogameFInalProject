﻿using UnityEngine;

public class DigGraveSpecific : MonoBehaviour
{
    bool objectMoving = false;
    public int direction = 0;
    public float speed;
    public Condition condition1;
    public Condition condition2;
    public Vector3 moveTarget;
    private GameObject dirtPile;
    private Transform dirtPileTransform;
    Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position + moveTarget;
        dirtPile = GameObject.Find("Pile O' Dirt");
        dirtPileTransform = dirtPile.transform;
    }

    public void moveObject()
    {
        if (condition1.satisfied && !condition2.satisfied)
        {
            objectMoving = true;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (objectMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }

        if (transform.position == targetPos)
        {
            moveTarget = -moveTarget;
            targetPos = transform.position + moveTarget;
            // Grave moving up
            if (direction == 1)
            {
                direction = 0;
                // Decrease size of dirt pile
                dirtPileTransform.localScale += new Vector3(-0.25f, -0.25f, -0.25f);
                dirtPileTransform.position += new Vector3(0, -0.05f, 0);
            }
            // Grave moving down
            else
            {
                direction = 1;
                // Increase side of dirt pile
                dirtPileTransform.localScale += new Vector3(0.25f, 0.25f, 0.25f);
                dirtPileTransform.position += new Vector3(0, 0.05f, 0);
            }
            objectMoving = false;
        }
    }
}
