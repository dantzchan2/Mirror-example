using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class RoundSystem : NetworkBehaviour
{
    [SerializeField] private Animator animator = null;


    private SPNetworkManager spNetworkManager;

    private SPNetworkManager SPnetworkManager
    {
        get
        {
            if (spNetworkManager != null) { return spNetworkManager; }
            return NetworkManager.singleton as SPNetworkManager;
        }
    }
    public void CounddownEnded() {
        animator.enabled = false;
    }

    #region Server

    public override void OnStartServer()
    {
        SPNetworkManager.OnServerReadied += CheckToStartRound;
        SPNetworkManager.OnServerStopped += CleanUpServer;
    }

    [ServerCallback]
    private void OnDestroy() => CleanUpServer();

    [Server]
    private void CleanUpServer() {
        SPNetworkManager.OnServerReadied -= CheckToStartRound;
        SPNetworkManager.OnServerStopped -= CleanUpServer;
    }

    [ServerCallback]
    public void StartRound() {
        RpcStartRound();
    }

    [Server]
    private void CheckToStartRound(NetworkConnection conn) {
        
        animator.enabled = true;
        RpcStartCountdown();
    }

    #endregion

    #region Client
    [TargetRpc]
    void RpcStartRound() {
        Debug.Log("Start game");
    }

    [TargetRpc]
    void RpcStartCountdown() {
        animator.enabled = true;
    }
    #endregion
}
