using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

// struct = class without functions
[System.Serializable]
public struct Gesture
{
    public string name;
    public List<Vector3> fingerDatas;
    public UnityEvent onRecognized;
}

public class GestureDetector : MonoBehaviour
{
    // How much accurate the recognize should be
    [Header("Threshold value")]
    public float threshold = 0.1f;

    // Add the component that refer to the skeleton hand ("OVRCustomHandPrefab_R" or "OVRCustomHandPrefab_L")
    [Header("Hand Skeleton")]
    public OVRSkeleton skeleton;

    // List that will be populated after we save some gestures
    [Header("List of Gestures")]
    public List<Gesture> gestures;

    // List of bones took from the OVRSkeleton
    private List<OVRBone> fingerbones = null;

    // Boolean for the debugMode duh!
    [Header("DebugMode")]
    public bool debugMode = true;

    // Other boolean to check if are working correctly
    private bool hasStarted = false;
    private bool hasRecognize = false;
    private bool done = false;


    private Gesture previousGesture;

    // Add an event if you want to make happen when a gesture is not identified
    [Header("Not Recognized Event")]
    public UnityEvent notRecognize;

    void Start()
    {
        // When the Oculus hand had his time to initialize hand, with a simple coroutine i start a delay of
        // a function to initialize the script
        StartCoroutine(DelayRoutine(2.5f, Initialize));
    }

    // Coroutine used for delay some function
    public IEnumerator DelayRoutine(float delay, Action actionToDo)
    {
        yield return new WaitForSeconds(delay);
        actionToDo.Invoke();
    }

    public void Initialize()
    {
        // Check the function for know what it does
        SetSkeleton();

        // After initialize the skeleton set a boolean to true to confirm the initialization
        hasStarted = true;
    }
    public void SetSkeleton()
    {
        // Populate the private list of fingerbones from the current hand we put in the skeleton
        fingerbones = new List<OVRBone>(skeleton.Bones);
    }

    void Update()
    {
        if (debugMode && Input.GetKeyDown(KeyCode.Space) && fingerbones.Count > 0)
        {
            Save();
        }

        //if the initialization was successful
        if (hasStarted.Equals(true))
        {
            // start to Recognize every gesture we make
            Gesture currentGesture = Recognize();
            // Debug.Log("Testing : " + currentGesture.name);
            // we will associate the recognize to a boolean to see if the Gesture
            // we are going to make is one of the gesture we already saved
            hasRecognize = !currentGesture.Equals(new Gesture());

            // and if the gesture is recognized
            if (hasRecognize)
            {
                // we change another boolean to avoid a loop of event
                done = true;
                Debug.Log("found : " + currentGesture.name);
                // after that i will invoke what put in the Event if is present
                currentGesture.onRecognized?.Invoke();
            }
            // if the gesture we done is no more recognized
            else
            {
                // and we just activated the boolean from earlier
                if (done)
                {
                    Debug.Log("Not Recognized");
                    // we set to false the boolean again, so this will not loop
                    done = false;

                    // and finally we will invoke an event when we end to make the previous gesture
                    notRecognize?.Invoke();
                }
            }
        }
    }

    void Save()
    {
        Gesture g = new Gesture();
        g.name = "New Gesture";
        List<Vector3> data = new List<Vector3>();
        foreach (var bone in fingerbones)
        {
            data.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
        }

        g.fingerDatas = data;
        gestures.Add(g);
    }

    Gesture Recognize()
    {
        Gesture currentGesture = new Gesture();
        float currentMin = Mathf.Infinity;

        foreach (var gesture in gestures)
        {
            float sumDistance = 0;
            bool isDiscarded = false;

            for (int i = 0; i < fingerbones.Count; i++)
            {
                Vector3 currentData = skeleton.transform.InverseTransformPoint(fingerbones[i].Transform.position);
                float distance = Vector3.Distance(currentData, gesture.fingerDatas[i]);

                if (distance > threshold)
                {
                    isDiscarded = true;
                    break;
                }

                sumDistance += distance;
            }

            if (!isDiscarded && sumDistance < currentMin)
            {
                currentMin = sumDistance;
                currentGesture = gesture;
            }
        }

        return currentGesture;
    }
}