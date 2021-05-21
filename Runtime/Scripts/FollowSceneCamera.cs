//Draw reference from http://wiki.unity3d.com/index.php/SceneViewCameraFollower
using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class FollowSceneCamera : MonoBehaviour {

#if UNITY_EDITOR
 
	void LateUpdate() {
		if(Application.isPlaying)
			Follow();
	}
 
	public void OnDrawGizmos() {
		if(!Application.isPlaying)
			Follow();
	}
	
//----------------------------------------------------------------------------------------------------------------------	
 
	//Make Camera.main follow the first SceneView camera
	void Follow() {
		ArrayList sceneViews = UnityEditor.SceneView.sceneViews;
		if(sceneViews.Count == 0) 
			return;

		Camera gameCamera = Camera.main;
		if (null == gameCamera)
			return;

		Transform gameCameraT = gameCamera.transform;
		if (sceneViews.Count <= 0)
			return;
		
		UnityEditor.SceneView sceneView = (UnityEditor.SceneView) sceneViews[0];
		if(null==sceneView)
			return;
		
		Camera curSceneCam = sceneView.camera;
		if (null==curSceneCam)
			return;

		Transform curSceneCamT = curSceneCam.transform;			
		gameCamera.orthographic = sceneView.orthographic;
		gameCameraT.position    = curSceneCamT.position;
		gameCameraT.rotation    = curSceneCamT.rotation;
	}
 
 
#endif
}
