using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    [SerializeField]
    Transform inactiveChildTransform;
    [SerializeField]
    Transform activeChildTransform;
    [SerializeField]
    Transform[] activeSubFrameTransforms;
    public bool IsGrabbed = false;
    public bool IsRotatable = false;
    public bool IsToggleCut = false;
    public Transform CuttingEdge;
    public WorkingBehaviour WorkingBehaviour;
    public enum ToolTypes { Mirror, Clipper, Razor, Scissors};
    public ToolTypes ToolType;

    public void Grab()
    {
        if (IsGrabbed)
            return;

        if (WorkingBehaviour.GrabbedTool != null)
            WorkingBehaviour.GrabbedTool.Drop();

        WorkingBehaviour.GrabbedTool = this;
        IsGrabbed = true;

        inactiveChildTransform.gameObject.SetActive(false);
        activeChildTransform.gameObject.SetActive(true);
    }

    public void Drop()
    {
        IsGrabbed = false;
        inactiveChildTransform.localPosition = Vector3.zero;
        activeChildTransform.localPosition = Vector3.zero;
        activeChildTransform.rotation = Quaternion.identity;
        activeChildTransform.gameObject.SetActive(false);
        inactiveChildTransform.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (IsGrabbed)
        {
            Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            vec.z = 0;
            activeChildTransform.position = vec;

            if (IsRotatable)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    activeChildTransform.RotateAround(vec, Vector3.forward, 0.3f);
                }
                else if (Input.mouseScrollDelta.y > 0)
                {
                    activeChildTransform.RotateAround(vec, Vector3.forward, 5f);
                }

                if (Input.GetKey(KeyCode.D))
                {
                    activeChildTransform.RotateAround(vec, Vector3.forward, -0.3f);
                }
                else if (Input.mouseScrollDelta.y < 0)
                {
                    activeChildTransform.RotateAround(vec, Vector3.forward, -5f);
                }

                if (IsToggleCut)
                {
                    vec = CuttingEdge.localPosition;
                    if (Input.GetMouseButton(0))
                        vec.z = 0;

                    if (Input.GetMouseButtonDown(0))
                    {
                        vec.z = 0.3f;
                        activeSubFrameTransforms[0].gameObject.SetActive(true);
                        activeSubFrameTransforms[1].gameObject.SetActive(false);
                    }

                    if (Input.GetMouseButtonUp(0))
                    {
                        vec.z = 0;
                        activeSubFrameTransforms[0].gameObject.SetActive(false);
                        activeSubFrameTransforms[1].gameObject.SetActive(true);
                    }
                    CuttingEdge.localPosition = vec;
                }
                else
                {
                    vec = CuttingEdge.localPosition;
                    vec.z = Input.GetMouseButton(0)? 0.3f: 0;
                    CuttingEdge.localPosition = vec;
                }

                switch (ToolType)
                {
                    case ToolTypes.Clipper:
                        if (Input.GetMouseButtonDown(0))
                        {
                            AudioManager._.SFXPlayer.clip = AudioManager._.ClipperBuzz;
                            AudioManager._.SFXPlayer.Play();
                        }
                        if (Input.GetMouseButtonUp(0))
                        {
                            AudioManager._.SFXPlayer.Stop();
                        }
                        break;

                    case ToolTypes.Scissors:
                        if (Input.GetMouseButtonDown(0))
                        {
                            AudioManager._.SFXPlayer.clip = AudioManager._.ScissorSnip;
                            AudioManager._.SFXPlayer.Play();
                        }
                        break;
                }
            }
        }
    }
}
