using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{


    [SerializeField]
    private float movementSpeed = 5f;

    private Rigidbody2D rgbd;

    [SerializeField]
    private KeyCode moveDown;

    [SerializeField]
    private KeyCode moveUp;

    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //move the player up and down
        if (Input.GetKey(moveUp))
        {
            rgbd.velocity = new Vector2(0, movementSpeed);
        }
        else if (Input.GetKey(moveDown))
        {
            rgbd.velocity = new Vector2(0, -movementSpeed);
        }
        else
        {
            rgbd.velocity = Vector2.zero;
        }
    }
}
