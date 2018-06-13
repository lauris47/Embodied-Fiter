using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneReference : MonoBehaviour
{
    public Transform RokokoBones;
    private int boneAmmount, currentBone;
    private Transform[] giraffeBones;
    private Transform[] humanBones;
    private Transform[] humanBonesClear;
    //public Transform leftLeg, leftKnee, leftToe, rightLeg, rightKnee, rightToe;
    public Transform leftFrontLeg, leftFrontKnee, leftFrontToe, rightFrontLeg, rightFrontKnee, rightFrontToe;
   // public Transform hips, head, neck, spine;
    private Transform spineLower;
    public Quaternion spineOffset;
    public Vector3 leftLegOffset, rightLegOffset;
    int index;

    public Transform[] boneReference;
    public Transform [] offsetBone;
    public Vector3[] offsetBoneRotation;
    // Use this for initialization
    void Start()
    {
        boneAmmount = 57;
        humanBones = new Transform[boneAmmount];
        giraffeBones = new Transform[boneAmmount];
        //Debug.Log(giraffeBones.Length);


        foreach (Transform bones in RokokoBones.GetComponentsInChildren<Transform>())
        {
            if (currentBone < boneAmmount)
            {
                if (bones.name.Length >= 10 && bones.name.Substring(0, 10) == "RokokoGuy_")
                {
                    //giraffeBones[currentBone] = bones;
                    //humanBones[currentBone] = giraffeBones[currentBone];
                    humanBones[currentBone] = bones;
                    Debug.Log(humanBones[currentBone].name + " index " + currentBone);
                    currentBone++;
                }
            }
        }

        //humanBonesClear = new Transform[giraffeBones.Length];
        for (int i = 0; i < giraffeBones.Length; i++)
        {

            //Debug.Log(giraffeBones[i].name);
        }
        //Debug.Log(giraffeBones.Length + " " + humanBones.Length);
        //Debug.Log(giraffeBones[67].name);
        index = 0;
        foreach (Transform bones in transform.GetComponentsInChildren<Transform>())
        {
            if (bones.name == "head")
            {
                // Debug.Log(bones.name + "index " + index);
            }
            index++;
            //Debug.Log(transform.Find("RokokoGuy_Hips/Spine/Spine_Lower/RokokoGuy_Spine/RokokoGuy_Spine2"));
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < offsetBone.Length; i++)
        {
            offsetBone[i].localEulerAngles = new Vector3(0,0, offsetBoneRotation[i].y + boneReference[i].eulerAngles.y);
                    //  if (transform.GetChild(i).name.Length >= 10 && transform.GetChild(i).name.Substring(0, 10) == "RokokoGuy_")
                    // {
                    //bones.localPosition = humanBones[currentBone].localPosition;
                    //transform.GetChild(i).localEulerAngles = humanBones[i].localEulerAngles;
                    //Debug.Log(transform.GetChild(i).name + " ?= " + humanBones[i].name);
                    //Debug.Log(humanBones[currentBone].name);
                    currentBone++;
                //}
            
        }


        /*
        hips.rotation = humanBones[0].rotation;
        hips.position = humanBones[0].position;
        leftLeg.localPosition = humanBones[1].localPosition;
        leftKnee.localPosition = humanBones[2].localPosition;
        leftFrontToe.localPosition = humanBones[4].localPosition;

        rightLeg.localPosition = humanBones[6].localPosition;
        rightKnee.localPosition = humanBones[7].localPosition;
        rightToe.localPosition = humanBones[9].localPosition;
        //neck.localEulerAngles = humanBones[17].localEulerAngles;
        //head.localEulerAngles = humanBones[18].localEulerAngles;
        //spine.rotation = humanBones[12].rotation * spineOffset;



        /*
        //spine.position = humanBones[25].position;
        leftLeg.localEulerAngles = humanBones[1].localEulerAngles ;
        leftLeg.localPosition = humanBones[1].localPosition;

        humanBones[2].localEulerAngles = leftKnee.localEulerAngles;
        humanBones[2].localPosition = leftKnee.localPosition;

        humanBones[3].localEulerAngles = leftToe.localEulerAngles;

        humanBones[3].localPosition = leftToe.localPosition;


        humanBones[7].localEulerAngles = rightLeg.localEulerAngles;  
        humanBones[7].localPosition = rightLeg.localPosition;
        humanBones[8].localEulerAngles = rightKnee.localEulerAngles;
        humanBones[8].localPosition = rightKnee.localPosition;
        humanBones[9].localEulerAngles = rightToe.localEulerAngles;
        humanBones[9].localPosition = rightToe.localPosition;


        humanBones[16].localEulerAngles = leftFrontLeg.localEulerAngles + rightLegOffset;
        //leftFrontLeg.localPosition = humanBones[16].localPosition;
        humanBones[17].localEulerAngles = leftFrontKnee.localEulerAngles;
        //leftFrontKnee.localPosition = humanBones[17].localPosition;
        humanBones[18].localEulerAngles = leftFrontToe.localEulerAngles;
        //leftFrontToe.localPosition = humanBones[18].localPosition;
        humanBones[44].localEulerAngles = rightFrontLeg.localEulerAngles + leftLegOffset;
        //rightFrontLeg.localPosition = humanBones[44].localPosition;
        humanBones[45].localEulerAngles = rightFrontKnee.localEulerAngles;
        //rightFrontKnee.localPosition = humanBones[45].localPosition;
        humanBones[46].localEulerAngles =  rightFrontToe.localEulerAngles;
        //rightFrontToe.localPosition = humanBones[46].localPosition;
        /*
        //giraffeBones[0].transform.position += new Vector3(0.1f, 0.1f, 0.1f);
        //Debug.Log(giraffeBones[0].name);
        currentBone = 0;
        foreach (Transform giraffeBone in humanBones)
        {
            //Debug.Log(giraffeBone.name);
            if (currentBone < boneAmmount)
            {
                //Debug.Log(currentBone);
                giraffeBones[currentBone].transform.localRotation = giraffeBone.localRotation;
                giraffeBones[currentBone].localPosition = giraffeBone.localPosition;
                currentBone++;
            }
        }
        */
    }
}
