using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

//포톤을 이용하여 게임서버까지 들어가게 하고 싶다.
public class NatworkManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.GameVersion = "0.1";
        PhotonNetwork.NickName = "Jhoo";
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        print("마스터서버 접속");
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    public override void OnJoinedLobby()
    {
        print("로비 접속");
        string roomName = "DefaultRoom";
        RoomOptions ro = new RoomOptions() {MaxPlayers = 5, IsVisible = true, IsOpen =true};

        //게임서버로 접속
        PhotonNetwork.JoinOrCreateRoom(roomName, ro, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        print("룸 접속");
        Vector3 randPos = Random.insideUnitSphere * 10;
        randPos.y = 3;
        PhotonNetwork.Instantiate("Player", randPos, Quaternion.identity);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print("방 접속실패");
    }
}
