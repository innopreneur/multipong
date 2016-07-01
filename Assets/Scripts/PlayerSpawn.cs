using UnityEngine;
using UnityEngine.Networking;


public class PlayerSpawn : NetworkBehaviour {

    
    NetworkStartPosition startPosition;
    [SerializeField]
    private float startPositionFactor;

    void Awake()
    {
        startPosition = gameObject.AddComponent<NetworkStartPosition>();
    }
    
     void Start() {

        Resolution[] resolutions = Screen.resolutions;
        foreach (Resolution res in resolutions)
        {
            print(res.width + "x" + res.height);
        }
       
        startPosition.transform.position = new Vector2(startPositionFactor * Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x/2, 0f);

    }
	
	
}
