using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using UnityEngine.UI;

namespace shooting_game_ncku
{
    public class attack : MonoBehaviourPunCallbacks, IPunObservable
    {
        // Start is called before the first frame update
        [Tooltip("指標- GameObject Beams")]
        [SerializeField]
        private GameObject beams;
        bool IsFiring;
        [Tooltip("玩家的血量")]
        public float Health = 1f;
        [Tooltip("玩家角色的 instance")]
        public static GameObject LocalPlayerInstance;
        
        void Awake()
        {
            if (beams == null)
            {
                Debug.LogError(
           "<Color=Red><a>指標- GameObject Beams 為空值</a></Color>",
           this);
            }
            else
            {
                beams.SetActive(false);
            }
            // 記錄玩家角色的 instance, 避免在重載場景時, 又再生成一次
            if (photonView.IsMine)
            {
                PlayerManager.LocalPlayerInstance = this.gameObject;
               
            }

            // 標註玩家角色的 instance 不會在重載場景時被砍殺掉
          //  DontDestroyOnLoad(this.gameObject);
        }
        void Start()
        {
            CameraWork _cameraWork =
                this.gameObject.GetComponent<CameraWork>();
            Camera camera = this.gameObject.GetComponentInChildren<Camera>();
            
            

            if (_cameraWork != null)
            {
                if (photonView.IsMine)
                {
                    _cameraWork.OnStartFollowing();
                    camera.depth = 3;


                    //rawImage.transform.parent = GameObject.Find("Canvas").transform;
                }
            }
            else
            {
                Debug.LogError("playerPrefab- CameraWork component 遺失",
                    this);
            }
        }
        
        void Update()
        {
            
            if (photonView.IsMine)
            {
                ProcessInputs();
                

            }
            if (beams != null && IsFiring != beams.activeSelf)
            {
                beams.SetActive(IsFiring);
            }
            if (Health <= 0f)
            {
                Game_Manager.Instance.LeaveRoom();
            }
        }

        void ProcessInputs()
        {
            // 按下發射鈕
            if (Input.GetButtonDown("Fire1"))
            {
                if (!IsFiring)
                {
                    IsFiring = true;
                }
            }
            // 放開發射鈕
            if (Input.GetButtonUp("Fire1"))
            {
                if (IsFiring)
                {
                    IsFiring = false;
                }
            }
        }
        void OnTriggerEnter(Collider other)
        {
            if (!photonView.IsMine)
            {
                return;
            }
            if (!other.name.Contains("Beam"))
            {
                return;
            }
            Health -= 0.1f;
        }

        void OnTriggerStay(Collider other)
        {
            if (!photonView.IsMine)
            {
                return;
            }
            if (!other.name.Contains("Beam"))
            {
                return;
            }
            Health -= 0.1f * Time.deltaTime;
        }

        public void OnPhotonSerializeView(PhotonStream stream,
    PhotonMessageInfo info)
        {
            if(stream.IsWriting)
    {
                // 為玩家本人的狀態, 將 IsFiring 的狀態更新給其他玩家
                stream.SendNext(IsFiring);
                stream.SendNext(Health);
            }
    else
            {
                // 非為玩家本人的狀態, 單純接收更新的資料
                this.IsFiring = (bool)stream.ReceiveNext();
                this.Health = (float)stream.ReceiveNext();
            }
        }
    }
}
