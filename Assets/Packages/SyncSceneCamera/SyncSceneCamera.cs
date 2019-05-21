using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class SyncSceneCamera : MonoBehaviour
{
    #region Field

    public Camera target;

    #endregion Field

    #region Method

    protected virtual void OnEnable()
    {
        SceneView.duringSceneGui += SyncCameraTransform;
    }

    protected virtual void OnDisable()
    {
        SceneView.duringSceneGui -= SyncCameraTransform;
    }

    protected virtual void SyncCameraTransform(SceneView sceneView)
    {
        Handles.BeginGUI();

        if (GUILayout.Button("Sync Camera", GUILayout.Width(100)))
        {
            Camera camera = this.target ?? Camera.main;

            if (camera)
            {
                sceneView.AlignViewToObject(camera.transform);
            }
        }

        Handles.EndGUI();
    }

    #endregion Method
}