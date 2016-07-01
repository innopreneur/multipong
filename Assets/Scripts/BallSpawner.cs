using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class BallSpawner : NetworkBehaviour {

    [SerializeField]
    private GameObject ballPrefab;

    GameObject ball;
    NetworkHash128 ballAssetId;

    void Start()
    {
        ballAssetId = ballPrefab.GetComponent<NetworkIdentity>().assetId;
        ball = Instantiate(ballPrefab, Vector3.zero, Quaternion.identity) as GameObject;
    }

    public override void OnStartServer()
    {
        NetworkServer.Spawn(ball);
        base.OnStartServer();
    }
}
