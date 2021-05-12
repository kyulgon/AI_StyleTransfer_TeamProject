/*
 * Copyright (c) 2017 VR Stuff
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dimension : MonoBehaviour // Portal을 이용한 Img, Vidoe 인터랙션에서 각자의 이미지를 보여주는 곳에 사용
{
	public Material customSkybox; // 

	[HideInInspector]
	public int layer; // layer를 인스벡터서 숨김

	[Tooltip("This designates this dimension as the original dimension from which the experience will start.")]
	public bool initialWorld = false; // 처음 보여줄 World 지정
	[Tooltip("This forces the Dimension to only affect the layers during rendering (thus keeping things like raycasting intact). Warning: This will break the automatic physics adjustment that keeps you from hitting things in other dimensions.")]
	public bool forceKeepInitialLayers = false;
	
	[HideInInspector]
	public List<Portal> connectedPortals;

	[HideInInspector]
	public Camera cam;

	private Dictionary<int, int> layerSwitchedChildren; // 딕션러니를 사용해 int, int형을 변수를 만듦

    private bool mainCameraNeedsSetup = true; // 카메라가 지정되어 있는지 확인

	void Awake() {
		connectedPortals = new List<Portal> (); // List 초기화

		layer = LayerManager.Instance ().CreateLayer (gameObject.name);	
		LayerManager.definedDimensions.Add (this);

		gameObject.layer = layer;

		int defaultLayer = LayerMask.NameToLayer("Default");
		if (!this.forceKeepInitialLayers) {
			Transform[] childrenTransforms = gameObject.GetComponentsInChildren<Transform> ();
			foreach (Transform t in childrenTransforms) {
				t.gameObject.layer = layer;
				if (t.gameObject.GetComponent<Light> ()) {
					Light light = t.gameObject.GetComponent<Light> ();
					light.cullingMask = defaultLayer;
					light.cullingMask |= 1 << layer;
				}		
			}
		}
			
        foreach (Camera camera in Camera.allCameras) {
            if (this.initialWorld)
            {
                CameraExtensions.LayerCullingShow(camera, layer);
                if (camera.GetComponent<Skybox>())
                {
                    camera.GetComponent<Skybox>().material = customSkybox;
                }
            }
            else
            {
                CameraExtensions.LayerCullingHide(camera, layer);
            }
        }
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /* This is used to enable VRTK kit builds*/
        
         if(mainCameraNeedsSetup)
        {
            if (Camera.main == null) {
                return;
            }            

            if (this.initialWorld)
            {
                CameraExtensions.LayerCullingShow(Camera.main, layer);
                Camera.main.gameObject.layer = layer;

                if (Camera.main.GetComponent<Skybox>())
                {
                    Camera.main.GetComponent<Skybox>().material = customSkybox;
                }
            } else {
                CameraExtensions.LayerCullingHide(Camera.main, layer);
            }

            this.mainCameraNeedsSetup = false;
        }
    }

	// You have just entered this dimension. All portals now point away from it.
	public void SwitchConnectingPortals() {
		foreach (Portal portal in connectedPortals) {
			if (portal.ToDimension () == this) {
				portal.SwitchPortalDimensions ();
			}
		}
	}

    public void showChildrenWithTag(string tag)
    {
        if (tag == "" || tag == null)
        {
            return;
        }

        int defaultLayer = LayerMask.NameToLayer("Default");
        Transform[] childrenTransforms = gameObject.GetComponentsInChildren<Transform>();
        foreach (Transform t in childrenTransforms)
        {
            if (t.CompareTag(tag))
            {
				t.gameObject.layer = defaultLayer;
            }
        }
    }


	// Handle layer switching during rendering if needed
	public void PreRender() {
		if (!forceKeepInitialLayers)
			return;

		if (layerSwitchedChildren == null) {
			layerSwitchedChildren = new Dictionary<int, int> ();
		}

		layerSwitchedChildren.Clear ();

		int defaultLayer = LayerMask.NameToLayer("Default");
		Transform[] childrenTransforms = gameObject.GetComponentsInChildren<Transform> ();
		foreach (Transform t in childrenTransforms) {
			layerSwitchedChildren.Add (t.gameObject.GetInstanceID (), t.gameObject.layer);
			t.gameObject.layer = layer;
			if (t.gameObject.GetComponent<Light> ()) {
				Light light = t.gameObject.GetComponent<Light> ();
				light.cullingMask = defaultLayer;
				light.cullingMask |= 1 << layer;
			}		
		}
	}

	public void PostRender() {
		if (!forceKeepInitialLayers)
			return;

		Transform[] childrenTransforms = gameObject.GetComponentsInChildren<Transform> ();
		foreach (Transform t in childrenTransforms) {
			int layer = layerSwitchedChildren [t.gameObject.GetInstanceID ()];
			t.gameObject.layer = layer;
		}
	}
}
