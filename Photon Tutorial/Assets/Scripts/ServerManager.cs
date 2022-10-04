using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ServerManager : Singleton<ServerManager>
{
    [SerializeField]
    private byte inRoomMaxPlayer;

    private RoomOptions roomOption;

    void Start()
    {
        ConnectToServer();
    }

    protected override void Initialize()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        roomOption = new RoomOptions();
        roomOption.MaxPlayers = inRoomMaxPlayer;
    }

    public void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void ConnectToRoom()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            Debug.Log("Photon 서버에 접속되어 있지 않습니다!");
        }
    }

    #region IConnectionCallbacks

    public override void OnConnected()
    {

    }

    public override void OnConnectedToMaster()
    {

    }

    public override void OnDisconnected(DisconnectCause cause)
    {

    }

    public override void OnRegionListReceived(RegionHandler regionHandler)
    {

    }

    public override void OnCustomAuthenticationResponse(Dictionary<string, object> data)
    {

    }

    public override void OnCustomAuthenticationFailed(string debugMessage)
    {

    }

    #endregion

    #region IMatchmakingCallbacks

    public override void OnFriendListUpdate(List<FriendInfo> friendList)
    {

    }

    public override void OnCreatedRoom()
    {

    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {

    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("LobbyScene");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {

    }

    public override void OnJoinRandomFailed(short returnCodd, string message)
    {
        PhotonNetwork.CreateRoom(null, roomOption);
    }

    public override void OnLeftRoom()
    {

    }

    #endregion
}