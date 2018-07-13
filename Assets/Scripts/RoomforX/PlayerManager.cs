using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace SoccerLikeGame
{
    /// <summary>
    /// Player manager.
    /// Handles fire Input and Beams.
    /// </summary>
    public class PlayerManager : Photon.PunBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {

        #region Public Variables
        [Tooltip("The local player instance. Use this to know if the local player is represented in the Scene")]
        public static GameObject LocalPlayerInstance;
        public NavMeshAgent agent = null;
        NavMeshPath navtDestinationPath;
        //プレーヤーの目指す点
        //todo:Listはphotonで同期できる？ そもそも実装重いようだし固定サイズの配列に
        public List<Vector3> destinationPoints;

        #endregion

        #region Private Variables
        [SerializeField]
        private LayerMask layerMask;
        Coroutine coroutine;
        //LineRender
        private LineRenderer lineRenderer;
        private int linePointCount = 1;//必要ないかもしれない//関数のスコープに落とそう
        private bool playerPointerClickFlag;//
        private bool playerPointerEnterFlag;//
        private bool nowDrawingFlag;
        #endregion

        #region MonoBehaviour CallBacks

        /// <summary>
        /// MonoBehaviour method called on GameObject by Unity during early initialization phase.
        /// </summary>
        void Awake()
        {
            // #Important
         // used in GameManager.cs: we keep track of the localPlayer instance to prevent instantiation when levels are synchronized
            if (photonView.isMine)
            {
                PlayerManager.LocalPlayerInstance = this.gameObject;
            }
            // #Critical
            // we flag as don't destroy on load so that instance survives level synchronization, thus giving a seamless experience when levels load.
            DontDestroyOnLoad(this.gameObject);

        }

        private void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.enabled = false;
            destinationPoints = new List<Vector3>();
            playerPointerClickFlag = false;
            playerPointerEnterFlag = false;
            nowDrawingFlag = false;
            navtDestinationPath = new NavMeshPath();
            agent = GetComponent<NavMeshAgent>();
        }

        /// <summary>
        /// MonoBehaviour method called on GameObject by Unity on every frame.
        /// </summary>
        void Update()
        {
            // ネットワーク接続時自分がマスターではないオブジェクトに関しては操作をしない
            if (photonView.isMine == false && PhotonNetwork.connected == true)
            {
                return;
            }

            LineManagement();

            NavGoToDestination();

            playerPointerClickFlag = false;//使っていない
        }

        #endregion

        #region private my method
        /// <summary>
        /// Navを用いて目的地に向かう関数
        /// </summary>
        private void NavGoToDestination()
        {
            if(destinationPoints.Count > 0)
            {
                //todo?:動かされたとき元いた位置に移動する実装になっている
                agent.SetDestination(destinationPoints[0]);
            }
        }

        /// <summary>
        /// 目的地の入ったリストとラインレンダーの管理
        /// </summary>
        private void LineManagement()
        {
            if (Input.GetMouseButton(0) != true)//タッチが離れたとき一筆書きフラグがfalse
            {//TODO?:マルチタップのときには使えない？
                nowDrawingFlag = false;
            }

            //一筆書きを行っているとき
            if(nowDrawingFlag == true)
            {
                SetDestinationPoint(lineRenderer, destinationPoints);
            }

            //最初にプレイヤーをクリックした時
            if (playerPointerEnterFlag == true && Input.GetMouseButtonDown(0))
            {
                //Debug.Log("最初にプレイヤーをクリックした時");
                linePointCount = 1;
                destinationPoints.Clear();
                lineRenderer.positionCount = 0;

                SetDestinationPoint(lineRenderer,destinationPoints);
                nowDrawingFlag = true;
            }

            //目的地の遷移、ライン描画
            if (destinationPoints.Count > 0 && nowDrawingFlag == false)
            {
                if (agent.remainingDistance < 0.5)
                {
                    destinationPoints.RemoveAt(0);
                }
                foreach (var item in destinationPoints.Select((Value, Index) => new { Value, Index }))
                {
                    //再描画
                    lineRenderer.SetPosition(item.Index, item.Value);
                }
            }

        }

        /// <summary>
        /// 目的地のリストと描画するラインに点を追加する
        /// </summary>
        /// <param name="lineRenderer"></param>
        /// <param name="destinationPoints"></param>
        private void SetDestinationPoint(LineRenderer lineRenderer, List<Vector3> destinationPoints)
        {
        //TODO:目的地のとり方が逐次的に細かく点を取りすぎていると思うので、距離を開けないと取れないように修正しよう
            Vector3 screenPoint = Input.mousePosition;
            screenPoint.z = 10.0f;
            Camera camera = Camera.main;//TODO?:ネット対戦で複数メインカメラがあるときはどうなる？
            Ray ray = camera.ScreenPointToRay(screenPoint);
            RaycastHit hit = new RaycastHit();

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Vector3 worldPoint = hit.point;
                worldPoint.y = 1.2f;

                destinationPoints.Add(worldPoint);

                lineRenderer.enabled = true;
                lineRenderer.positionCount = linePointCount;
                lineRenderer.SetPosition(linePointCount - 1, worldPoint);
                linePointCount++;
            }

        }
        #endregion

        #region public my method
        public void OnPointerClick(PointerEventData eventData)
        {
            //Debug.Log("OnPointerClick");
            playerPointerClickFlag = true;
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            //Debug.Log("OnPointerEnter");
            playerPointerEnterFlag = true;
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            //Debug.Log("OnPointerExit");
            playerPointerEnterFlag = false;
        }
        #endregion

        #region Custom

        #endregion

    }
}

