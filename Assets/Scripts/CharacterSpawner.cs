using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class CharacterSpawner : NetworkBehaviour
{
    [SerializeField] GameObject[] character;
    public void TrySpawn()
    {
        CmdSpawn();
    }

    [Command]
    void CmdSpawn()
    {
        Transform t = SPNetworkManager.singleton.GetStartPosition();
        GameObject obj = Instantiate(character[Random.Range(0,2)], t.position, t.rotation);
        NetworkServer.Spawn(obj, this.gameObject);
    }
}
