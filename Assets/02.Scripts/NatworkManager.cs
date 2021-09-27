using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

//������ �̿��Ͽ� ���Ӽ������� ���� �ϰ� �ʹ�.
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
        print("�����ͼ��� ����");
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    public override void OnJoinedLobby()
    {
        print("�κ� ����");
        string roomName = "DefaultRoom";
        RoomOptions ro = new RoomOptions() {MaxPlayers = 5, IsVisible = true, IsOpen =true};

        //���Ӽ����� ����
        PhotonNetwork.JoinOrCreateRoom(roomName, ro, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        print("�� ����");
        Vector3 randPos = Random.insideUnitSphere * 10;
        randPos.y = 3;
        PhotonNetwork.Instantiate("Player", randPos, Quaternion.identity);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print("�� ���ӽ���");
    }
}
