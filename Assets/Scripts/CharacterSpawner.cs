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
        GameObject obj = Instantiate(character[Random.Range(0,2)], new Vector3(0,0,0), Quaternion.identity);
        NetworkServer.Spawn(obj, this.gameObject);
    }
}
