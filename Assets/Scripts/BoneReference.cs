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

    public Transform leftLeg, leftKnee, leftToe, rightLeg, rightKnee, rightToe;
    public Transform leftFrontLeg, leftFrontKnee, leftFrontToe, rightFrontLeg, rightFrontKnee, rightFrontToe;

    public Transform hips, head, neck, spine;
    private Transform spineLower;

    public Quaternion spineOffset;

    public Vector3 leftLegOffset, rightLegOffset;

    int index;

    // Use this for initialization
    void Start()
    {
        boneAmmount = 57;
        humanBones = new Transform[boneAmmount];
        giraffeBones = new Transform[boneAmmount];

        //Debug.Log(giraffeBones.Length);

        /*
        foreach (Transform bones in transform.GetComponentsInChildren<Transform>())
        {
            if (currentBone < boneAmmount)
            {
                if (bones.name.Length >= 10 && bones.name.Substring(0, 10) == "RokokoGuy_")
                {
                    giraffeBones[currentBone] = bones;
                    Debug.Log(giraffeBones[currentBone].name);
                    currentBone++;
                }
            }
        }

        //Debug.Log(RokokoBones.transform.GetComponentsInChildren<Transform>().Length);
        */

        currentBone = 0;
        foreach (Transform bones in RokokoBones.transform.GetComponentsInChildren<Transform>())
        {
            if (currentBone < boneAmmount)
            {
                if (bones.name.Length >= 10 && bones.name.Substring(0, 10) == "RokokoGuy_")
                {
                    humanBones[currentBone] = bones;
                    //Debug.Log(humanBones[currentBone].name);
                    currentBone++;
                }
            }
        }

        humanBonesClear = new Transform[giraffeBones.Length];

        for (int i = 0; i < giraffeBones.Length; i++)
        {

            //Debug.Log(giraffeBones[i].name);
        }

        //Debug.Log(giraffeBones.Length + " " + humanBones.Length);
        //Debug.Log(giraffeBones[67].name);

        index = 0;
        foreach (Transform bones in transform.GetComponentsInChildren<Transform>())
        {
            if(bones.name == "head")
            {
                Debug.Log(bones.name + "index " + index);

            }
            index++;
            //Debug.Log(transform.Find("RokokoGuy_Hips/Spine/Spine_Lower/RokokoGuy_Spine/RokokoGuy_Spine2"));
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hips.rotation = humanBones[0].rotation;
        hips.position = humanBones[0].position;

        neck.localEulerAngles = humanBones[46].localEulerAngles;
        head.localEulerAngles = humanBones[47].localEulerAngles;
        //spine.rotation = humanBones[26].rotation * spineOffset;
        //spine.position = humanBones[25].position;



        leftLeg.localEulerAngles = humanBones[1].localEulerAngles;
        leftLeg.localPosition = humanBones[1].localPosition;
        leftKnee.localEulerAngles = humanBones[2].localEulerAngles;
        leftKnee.localPosition = humanBones[2].localPosition;
        leftToe.localEulerAngles = humanBones[3].localEulerAngles;
        leftToe.localPosition = humanBones[3].localPosition;

        rightLeg.localEulerAngles = humanBones[7].localEulerAngles;
        rightLeg.localPosition = humanBones[7].localPosition;
        rightKnee.localEulerAngles = humanBones[8].localEulerAngles;
        rightKnee.localPosition = humanBones[8].localPosition;
        rightToe.localEulerAngles = humanBones[9].localEulerAngles;
        rightToe.localPosition = humanBones[9].localPosition;

        leftFrontLeg.localEulerAngles = humanBones[16].localEulerAngles + rightLegOffset;
        //leftFrontLeg.localPosition = humanBones[16].localPosition;
        leftFrontKnee.localEulerAngles = humanBones[17].localEulerAngles;
        //leftFrontKnee.localPosition = humanBones[17].localPosition;
        leftFrontToe.localEulerAngles = humanBones[18].localEulerAngles;
        //leftFrontToe.localPosition = humanBones[18].localPosition;

        rightFrontLeg.localEulerAngles = humanBones[44].localEulerAngles + leftLegOffset;
        //rightFrontLeg.localPosition = humanBones[44].localPosition;
        rightFrontKnee.localEulerAngles = humanBones[45].localEulerAngles;
        //rightFrontKnee.localPosition = humanBones[45].localPosition;
        rightFrontToe.localEulerAngles = humanBones[46].localEulerAngles;
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
