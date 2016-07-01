using UnityEngine;
using System.Collections;

public class Networking : MonoBehaviour {

    //game name for the server (it should be unique)
    private const string typeName = "UniqueGameName";

    //host name where game is hosted
    private const string gameName = "RoomName";
    private HostData[] hostList;
    private int maxConnections = 2;
    private int portNo = 25000;

    //start the server
    private void StartServer()
    {
        //set master server address to localhost
        MasterServer.ipAddress = "127.0.0.1";
        MasterServer.port = 25000;

        Debug.Log("Starting StartServer()");

        //initialize server
        Network.InitializeServer(maxConnections, portNo, !Network.HavePublicAddress());

        //register as host
        MasterServer.RegisterHost(typeName, gameName);

        Debug.Log("Ending StartServer()");
    }

    //called when server is initialized successfully
    void OnServerInitialized()
    {
        Debug.Log("In OnServerInitialized()");
    }

    //called every frame
    void OnGUI()
    {
        if (!Network.isClient && !Network.isServer)
        {
            //if true (button clicked), then start server
            if (GUI.Button(new Rect(100, 100, 250, 100), "Start Server"))
                StartServer();
            //if true (button clicked), then query all host entries
            if (GUI.Button(new Rect(100, 250, 250, 100), "Refresh Hosts"))
                RefreshHostList();

            if (hostList != null)
            {
                for (int i = 0; i < hostList.Length; i++)
                {
                    //if true (button clicked and there is a host), then connect to that existing host
                    if (GUI.Button(new Rect(400, 100 + (110 * i), 300, 100), hostList[i].gameName))
                        JoinServer(hostList[i]);
                }
            }
        }
    }

    private void RefreshHostList()
    {
        Debug.Log("Starting RefreshHostLíst()");

        //requests all registered host list for particular game
        MasterServer.RequestHostList(typeName);

        Debug.Log("Ending RefreshHostLíst()");
    }

    //called for several master server events
    void OnMasterServerEvent(MasterServerEvent msEvent)
    {
        Debug.Log("Starting OnMasterServerEvent()");

        //true if event is about received host list
        if (msEvent == MasterServerEvent.HostListReceived)

            Debug.Log("OnMasterServerEvent() is of type HostListReceived");

        //store host list in local list
        hostList = MasterServer.PollHostList();
    }

    private void JoinServer(HostData hostData)
    {
        Debug.Log("Starting JoinServer()");
        
        //connect to exisiting host
        Network.Connect(hostData);

        Debug.Log("Ending JoinServer()");
    }

    void OnConnectedToServer()
    {
        Debug.Log("In OnConnectedToServer()");
    }
}
