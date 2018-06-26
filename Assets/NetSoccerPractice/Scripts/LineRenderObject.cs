using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LineRenderObject : MonoBehaviour {

    GameObject ObjectCylinder;

    private float deltaTime = 0.0f;
    private float touchInterval = 0.10f;
    private bool touchEnable = false;

    private LineRenderer lineRenderer;
    private int lineIndex = 1;

    private bool controll = true;

    public bool clickEventFlag;
    public bool enterEventFlag;
    public bool oneDrawFlag;


    float StartTimer = 0;

    Transform target;//目標地点//使わないかも
    public List<Vector3> targetPoints;

    SoccerPlayerClick refCylinderObj;
    SoccerPlayerLineTrack refCylinderLineTrack;


    // Use this for initialization
    void Start () {
        ObjectCylinder = GameObject.Find("SoccerPlayerPrefab");
        refCylinderObj = ObjectCylinder.GetComponent<SoccerPlayerClick>();
        refCylinderLineTrack = ObjectCylinder.GetComponent<SoccerPlayerLineTrack>(); 


        lineRenderer = GetComponent<LineRenderer>();
        Debug.Log(lineRenderer);
        lineRenderer.enabled = false;
        targetPoints = new List<Vector3>();
        clickEventFlag = refCylinderObj.clickEventFlag;
        enterEventFlag = refCylinderObj.onPointerEnterFlag;

        oneDrawFlag = true;
    }

	
	// Update is called once per frame
	public void Update () {
        clickEventFlag = refCylinderObj.clickEventFlag;
        enterEventFlag = refCylinderObj.onPointerEnterFlag;

        //Debug.Log(clickEventFlag);

        if(enterEventFlag && Input.GetMouseButtonDown(0))//マウスを押してエンターを押すと、
        {
            //lineRenderer.positionCount = 0;
            lineIndex = 1;
            targetPoints.Clear();
            lineRenderer.positionCount = 0;
            Touch();
            oneDrawFlag = true;
        }
        if(targetPoints.Count != 0 && Input.GetMouseButton(0) && oneDrawFlag)//一筆書きをフラグ、タッチして
        {
            Touch();
        }

        if (Input.GetMouseButton(0) != true)//タッチが離れたら一筆書きフラグがfalse
        {
            oneDrawFlag = false;
        }

        if(targetPoints.Count >= 1 && oneDrawFlag == false)
        {
            if (refCylinderLineTrack.agent.remainingDistance < 0.7)
            {
                targetPoints.RemoveAt(0);
                Debug.Log(targetPoints.Count);

                foreach (var item in targetPoints.Select((Value, Index)=> new {Value, Index})) {//ここで辿った線を消している
                    lineRenderer.SetPosition(item.Index, item.Value);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            controll = false;
        }

        deltaTime += Time.deltaTime;
        if(deltaTime > touchInterval)
        {
            deltaTime = 0;
            touchEnable = true;
            controll = true;
        }


        //StartTimer += Time.deltaTime;
        //if (StartTimer > 10 && StartTimer < 11)
        //{
        //    lineRenderer.positionCount = 0;
        //    lineIndex = 1;
        //}
    }

    void Touch()
    {
        Debug.Log("Touch");
        Vector3 screenPoint = Input.mousePosition;
        screenPoint.z = 10.0f;
        //Camera camera = GetComponent<Camera>();
        Camera camera = Camera.main;
        Vector3 worldPoint;// = camera.ScreenToWorldPoint(screenPoint);

        Ray ray = camera.ScreenPointToRay(screenPoint);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            worldPoint = hit.point;
            worldPoint.y = 0.3f;

            targetPoints.Add(worldPoint);

            lineRenderer.enabled = true;
            lineRenderer.positionCount = lineIndex;
            lineRenderer.SetPosition(lineIndex - 1, worldPoint);
            lineIndex++;
        }
    }

    //なにもないここは
    public void EventTouch()
    {
        Vector3 screenPoint = Input.mousePosition;
        screenPoint.z = 10.0f;
        //Camera camera = GetComponent<Camera>();
        Camera camera = Camera.main;
        Vector3 worldPoint;// = camera.ScreenToWorldPoint(screenPoint);
        //Debug.Log(worldPoint);

        Ray ray = camera.ScreenPointToRay(screenPoint);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            //最初の一点はオブジェクトの近くでないと発生しない。
            worldPoint = hit.point;
            worldPoint.y = 0.3f;

            Debug.Log(worldPoint);

            targetPoints.Add(hit.point);

            lineRenderer.enabled = true;
            lineRenderer.positionCount = lineIndex;
            lineRenderer.SetPosition(lineIndex - 1, worldPoint);
            lineIndex++;
        }
    }
}
