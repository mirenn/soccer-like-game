using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SoccerLikeGame
{
    public class GameManager : Photon.PunBehaviour
    {
        #region Public variables
        [Tooltip("The prefab to use for representing the player")]
        public GameObject playerPrefab;
        public GameObject ballPrefab;
        static public GameManager Instance;

        //プレイヤーインスタンス
        GameObject PlayerInstance1;
        GameObject PlayerInstance2;
        GameObject PlayerInstance3;

        //Xの負側で設定されるプリファブ
        GameObject NegativeXPlayerPrefab1;
        GameObject NegativeXPlayerPrefab2;
        GameObject NegativeXPlayerPrefab3;

        //Xの正側で設定されるプリファブ
        GameObject PositiveXPlayerPrefab1;
        GameObject PositiveXPlayerPrefab2;
        GameObject PositiveXPlayerPrefab3;
        #endregion

        #region Photon Messages

        /// <summary>
        /// Called when the local player left the room. We need to load the launcher scene.
        /// </summary>
        public override void OnLeftRoom()// => + override
        {
            SceneManager.LoadScene(0);
        }

        #endregion

        #region Public Methods

        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

        #endregion

        #region Private Methods

        void LoadArena()
        {
            //TODO:三人以上も許容しているがシーンを用意していない。許容するプレーヤー数を変更しよう
            //fixme?:ほぼ同時に接続すると二人とも同じ部屋に接続される
            if (!PhotonNetwork.isMasterClient)
            {
                Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
            }
            Debug.Log("PhotonNetwork : Loading Level : " + PhotonNetwork.room.PlayerCount);
            PhotonNetwork.LoadLevel("Roomfor" + PhotonNetwork.room.PlayerCount);//Roomforの間のスペースを除いた

        }

        #endregion

        #region Photon Messages

        public override void OnPhotonPlayerConnected(PhotonPlayer other)
        {
            Debug.Log("OnPhotonPlayerConnected() " + other.NickName); // not seen if you're the player connecting

            if (PhotonNetwork.isMasterClient)
            {
                Debug.Log("OnPhotonPlayerConnected isMasterClient " + PhotonNetwork.isMasterClient); // called before OnPhotonPlayerDisconnected

                LoadArena();
            }
        }

        public override void OnPhotonPlayerDisconnected(PhotonPlayer other)
        {
            Debug.Log("OnPhotonPlayerDisconnected() " + other.NickName); // seen when other disconnects

            if (PhotonNetwork.isMasterClient)
            {
                Debug.Log("OnPhotonPlayerConnected isMasterClient " + PhotonNetwork.isMasterClient); // called before OnPhotonPlayerDisconnected

                LoadArena();
            }
        }

        #endregion
        #region MonoBehabior

        private void Start()
        {
            Instance = this;
            if (playerPrefab == null)
            {
                Debug.LogError("<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this);
            }
            else
            {
                if (PlayerManager.LocalPlayerInstance == null)
                {
                    Debug.Log("We are Instantiating LocalPlayer from " + Application.loadedLevelName);
                    // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
                    //マスタークライアントはx負側、x正側
                    if (PhotonNetwork.isMasterClient == true)
                    {
                        PlayerInstance1 = PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(-8f, 5f, 1.5f), Quaternion.identity, 0);
                        PlayerInstance2 = PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(-8f, 5f, 0f), Quaternion.identity, 0);
                        PlayerInstance3 = PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(-8f, 5f, -1.5f), Quaternion.identity, 0);
                    }
                    else
                    {
                        PlayerInstance1 = PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(8f, 5f, 1.5f), Quaternion.identity, 0);
                        PlayerInstance2 = PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(8f, 5f, 0f), Quaternion.identity, 0);
                        PlayerInstance3 = PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(8f, 5f, -1.5f), Quaternion.identity, 0);
                    }

                }
                else
                {
                    Debug.Log("Ignoring scene load for " + Application.loadedLevelName);
                }
            }
            //ボール生成
            if(PhotonNetwork.isMasterClient == true)
            {
                PhotonNetwork.Instantiate(this.ballPrefab.name, new Vector3(-5f, 5f, 0f), Quaternion.identity, 0);
            }
        }
        #endregion
        #region MonoBehavior Callbacks
        void OnLevelWasLoaded(int level)
        {
            // check if we are outside the Arena and if it's the case, spawn around the center of the arena in a safe zone
            if (!Physics.Raycast(transform.position, -Vector3.up, 5f))
            {
                transform.position = new Vector3(0f, 0f, 5f);//効果がないように思える
            }
        }
        #endregion
    }
} 

