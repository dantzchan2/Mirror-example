using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SPNetworkManager : NetworkManager
{
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        // Transform startPos = GetStartPosition();
        GameObject player = Instantiate(playerPrefab);
        NetworkServer.AddPlayerForConnection(conn, player);
    }


}
