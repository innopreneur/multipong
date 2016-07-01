using UnityEngine;
using System.Collections;

public class GameSetup : MonoBehaviour
{

    private Camera mainCam;
    private BoxCollider2D topBorder;
    private BoxCollider2D bottomBorder;
    private BoxCollider2D leftBorder;
    private BoxCollider2D rightBorder;

    private PhysicsMaterial2D bouncy;


    // Use this for initialization
    void Start()
    {

        Debug.Log("GameSetup start method called");
        //set bouncy material
        bouncy = new PhysicsMaterial2D();
        bouncy.friction = 0;
        bouncy.bounciness = 1;

        mainCam = Camera.main;


        //add box colliders to borders
        topBorder = gameObject.AddComponent<BoxCollider2D>();
        bottomBorder = gameObject.AddComponent<BoxCollider2D>();
        leftBorder = gameObject.AddComponent<BoxCollider2D>();
        rightBorder = gameObject.AddComponent<BoxCollider2D>();

        //add bounciness to borders
        topBorder.sharedMaterial = bouncy;
        bottomBorder.sharedMaterial = bouncy;
        leftBorder.sharedMaterial = bouncy;
        rightBorder.sharedMaterial = bouncy;

        topBorder.size = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width * 2, 0f, 0f)).x, 1f);
        topBorder.offset = new Vector2(0f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y + 2f);

        bottomBorder.size = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width * 2, 0f, 0f)).x, 1f);
        bottomBorder.offset = new Vector2(0f, mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y - 2f);


        leftBorder.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y); ;
        leftBorder.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x + 2f, 0f);

        rightBorder.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        rightBorder.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x - 2f, 0f);


    }

}