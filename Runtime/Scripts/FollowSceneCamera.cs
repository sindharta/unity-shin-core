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
		
		for(int i=0;i<sceneViews.Count;++i) {	
			UnityEditor.SceneView sceneView = (UnityEditor.SceneView) sceneViews[i];
			if(null==sceneView)
				continue;
			
			Camera curSceneCam = sceneView.camera;
			if (null==curSceneCam)
				continue;

			Transform curSceneCamT = curSceneCam.transform;			
			gameCamera.orthographic = sceneView.orthographic;
			gameCameraT.position    = curSceneCamT.position;
			gameCameraT.rotation    = curSceneCamT.rotation;
			return;
		}	
	}
 
 
#endif
}
