using System.Collections.Generic;
using UnityEngine;

namespace VRMBehavior {
    class BoneAxisData {
        static public BoneAxisData instance = new ();

        public List<(HumanBodyBones, Vector3, Vector3?)> GetAxisData => axisData; 

        private List<(HumanBodyBones, Vector3, Vector3?)> axisData = new () {
            (HumanBodyBones.Hips, Vector3.up, Vector3.up),
            (HumanBodyBones.Spine, Vector3.up, Vector3.up),
            (HumanBodyBones.Head, Vector3.up, Vector3.up),
            (HumanBodyBones.LeftUpperArm, Vector3.up, Vector3.up),
            (HumanBodyBones.RightUpperArm, Vector3.up, Vector3.down),
            (HumanBodyBones.LeftLowerArm, Vector3.up, Vector3.up),
            (HumanBodyBones.RightLowerArm, Vector3.up, Vector3.down),
            (HumanBodyBones.LeftHand, Vector3.up, Vector3.up),
            (HumanBodyBones.RightHand, Vector3.up, Vector3.down),
            (HumanBodyBones.LeftUpperLeg, Vector3.down, Vector3.left),
            (HumanBodyBones.RightUpperLeg, Vector3.down, Vector3.left),
            (HumanBodyBones.LeftLowerLeg, Vector3.down, Vector3.left),
            (HumanBodyBones.RightLowerLeg, Vector3.down, Vector3.left),
            (HumanBodyBones.LeftFoot, Vector3.up, null),
            (HumanBodyBones.RightFoot, Vector3.up, null),
        };
    }
}