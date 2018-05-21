using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmsAreLegs : MonoBehaviour
{

    public Transform leftArm, leftElbow, leftHand, rightArm, rightElbow, rightHand;
    public Transform leftBackHip, leftBackKnee, leftBackToe, rightBackHip, rightBackKnee, rightBackToe;

    public Transform leftLeg, leftKnee, rightLeg, rightKnee;
    public Transform spine;
    private Transform spineLower;

    private float [] initialToeHeight;
    private float spineRotation ;
     Vector3 initialSpineLowerRot, initialSpineRot;
    //public Transform leftShoulder, rightShoulder;

    public Quaternion leftLegOffset, leftKneeOffset, rightLegOffset, rightKneeOffset  ;

    int currentBone = 0, boneAmmount;
    private Transform[] giraffeBones;

    // Use this for initialization
    void Start()
    {
        if (spine != null)
        {
            spineLower = spine.GetChild(0);
            initialSpineRot = spine.localEulerAngles;
            initialSpineLowerRot = spineLower.localEulerAngles;
        }
        initialToeHeight = new float[2];
        initialToeHeight[0] = rightBackToe.transform.position.y;
        initialToeHeight[1] = leftBackToe.transform.position.y;
        Debug.Log(initialToeHeight[0]);
        Debug.Log(initialToeHeight[1]);

        giraffeBones = new Transform[boneAmmount];
    }

    // Update is called once per frame
    void LateUpdate()
    {
        currentBone = 0;


        //leftBackHip.localEulerAngles = leftLeg.localEulerAngles;
        //rightBackHip.localEulerAngles = rightLeg.localEulerAngles;
        //leftBackKnee.localEulerAngles = -leftKnee.localEulerAngles;
        //rightBackKnee.localEulerAngles = -rightKnee.localEulerAngles;

        /*
        leftLeg.localEulerAngles = leftArm.localEulerAngles;
        leftKnee.localEulerAngles = leftElbow.localEulerAngles;

        rightLeg.localEulerAngles = rightArm.localEulerAngles;
        rightKnee.localEulerAngles = rightElbow.localEulerAngles;




        leftBackHip.localEulerAngles = leftBackHip.localEulerAngles;
        rightBackHip.localEulerAngles = rightBackHip.localEulerAngles;
        leftBackKnee.localEulerAngles = leftBackKnee.localEulerAngles;
        rightBackKnee.localEulerAngles = rightBackKnee.localEulerAngles;

        */

        /*
        //Debug.Log(leftArm.transform.rotation); //= leftArm.transform.localEulerAngles + checkValue;

        leftBackHip.transform.rotation = leftArm.transform.rotation * leftLegOffset;
        //leftBackKnee.transform.rotation = leftElbow.transform.rotation * leftKneeOffset;

        rightBackHip.transform.rotation = rightArm.transform.rotation * rightLegOffset;
        //rightBackKnee.transform.rotation = rightElbow.transform.rotation * rightKneeOffset;
        //rightBackHip.transform.localRotation = rightArm.transform.localRotation * new Quaternion(-90, -90, 0, 0);

        //leftArm.transform.localRotation *= checkCalue;
        //rightArm.transform.localRotation *= new Quaternion(-90, -90, 0, 0);
        //leftBackKnee.transform.localRotation = leftElbow.transform.localRotation;
        //leftBackToe.transform.localRotation = leftHand.transform.localRotation;

        
        if(initialToeHeight[0] < rightBackToe.position.y && initialToeHeight[1] < leftBackToe.position.y)
        {
            spineRotation = - (Mathf.Abs(initialToeHeight[1] - rightBackToe.position.y) + Mathf.Abs(initialToeHeight[0] - leftBackToe.position.y)) / 2 * 30;
            Debug.Log(spineRotation);

            spineLower.localEulerAngles = new Vector3(spineLower.localEulerAngles.x, spineLower.localEulerAngles.y, spineRotation);
            spine.localEulerAngles = new Vector3(spine.localEulerAngles.x, spine.localEulerAngles.y, spineRotation);
        }

    */
    }
}
