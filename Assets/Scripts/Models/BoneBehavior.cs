using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VRMBehavior {
    public class BoneBehavior {
        private Transform tf;
        private HumanBodyBones boneId;
        private Vector3 lookAxis;
        private Vector3? rotateAxis;
        
        public BoneBehavior(HumanBodyBones boneId, Animator human, Vector3 lookAxis, Vector3? rotateAxis) {
            this.boneId = boneId;
            this.lookAxis = lookAxis;
            this.rotateAxis = rotateAxis;
            tf = human.GetBoneTransform(boneId);
        }

        public void Look(List<SegmentationBone> bones) {
            // Hip
            if (boneId == HumanBodyBones.Hips) {
                var leftHip = bones.Where(x => x.BoneId == SegmentationBoneType.LeftHip).ToList()[0].Position;
                var rightHip = bones.Where(x => x.BoneId == SegmentationBoneType.RightHip).ToList()[0].Position;
                var rotation = Quaternion.LookRotation(leftHip - rightHip);
                tf.rotation = rotation;
                tf.rotation *= Quaternion.AngleAxis(90, Vector3.up);
                return;
            }

            // Spine
            if (boneId == HumanBodyBones.Spine) {
                var leftShoulder = bones.Where(x => x.BoneId == SegmentationBoneType.LeftShoulder).ToList()[0].Position;
                var rightShoulder = bones.Where(x => x.BoneId == SegmentationBoneType.RightShoulder).ToList()[0].Position;
                var rotation = Quaternion.LookRotation(leftShoulder - rightShoulder);
                tf.rotation = rotation;
                tf.rotation *= Quaternion.AngleAxis(90, Vector3.up);
                return;
            }

            // Head
            if (boneId == HumanBodyBones.Head) {
                var leftEye = bones.Where(x => x.BoneId == SegmentationBoneType.leftEyeOuter).ToList()[0].Position;
                var rightEye = bones.Where(x => x.BoneId == SegmentationBoneType.RightEyeOuter).ToList()[0].Position;
                var centerEye = (rightEye + leftEye) * 0.5f;
                var leftEar = bones.Where(x => x.BoneId == SegmentationBoneType.LeftEar).ToList()[0].Position;
                var rightEar = bones.Where(x => x.BoneId == SegmentationBoneType.RightEar).ToList()[0].Position;
                var centerEar = (rightEar + leftEar) * 0.5f;
                var rotation = Quaternion.LookRotation(centerEye - centerEar);
                tf.rotation = rotation;
                return;
            }


            var targetPos = GetTarget(bones);
            tf.LookAt(targetPos + tf.position, lookAxis);
            if (rotateAxis != null) { 
                tf.rotation *= Quaternion.AngleAxis(90, rotateAxis ?? Vector3.zero);
            }
            
            // Hand
            if (boneId == HumanBodyBones.LeftHand || boneId == HumanBodyBones.RightHand) {
                SegmentationBoneType pinkyType = boneId == HumanBodyBones.LeftHand ? SegmentationBoneType.LeftPinky
                    : SegmentationBoneType.RightPinky;
                SegmentationBoneType thumbType = boneId == HumanBodyBones.RightHand ? SegmentationBoneType.LeftThumb
                    : SegmentationBoneType.RightThumb;
                var pinky = bones.Where(x => x.BoneId == pinkyType).ToList()[0].Position;
                var thumb = bones.Where(x => x.BoneId == thumbType).ToList()[0].Position;
                var rotation = Quaternion.LookRotation(pinky - thumb);
                Vector3 axis = boneId == HumanBodyBones.LeftHand ? Vector3.right : Vector3.right;
                tf.localRotation *= Quaternion.AngleAxis(rotation.eulerAngles.x - 90, axis);
            }
        }

        private Vector3 GetTarget(List<SegmentationBone> bones) {

            var targetDic = new Dictionary<HumanBodyBones, HumanBodyBones>() {
                {HumanBodyBones.LeftUpperArm, HumanBodyBones.LeftLowerArm},
                {HumanBodyBones.RightUpperArm, HumanBodyBones.RightLowerArm},
                {HumanBodyBones.LeftLowerArm, HumanBodyBones.LeftHand},
                {HumanBodyBones.RightLowerArm, HumanBodyBones.RightHand},
                {HumanBodyBones.LeftHand, HumanBodyBones.LeftIndexDistal},
                {HumanBodyBones.RightHand, HumanBodyBones.RightIndexDistal},
                
                {HumanBodyBones.LeftUpperLeg, HumanBodyBones.LeftLowerLeg},
                {HumanBodyBones.RightUpperLeg, HumanBodyBones.RightLowerLeg},
                {HumanBodyBones.LeftLowerLeg, HumanBodyBones.LeftFoot},
                {HumanBodyBones.RightLowerLeg, HumanBodyBones.RightFoot},
                {HumanBodyBones.LeftFoot, HumanBodyBones.LeftToes},
                {HumanBodyBones.RightFoot, HumanBodyBones.RightToes},
            };
            var startPos = bones.Where(x => x.BoneId == GetSegmentationType(boneId)).ToList()[0].Position;
            var targetId = targetDic[boneId];
            var targetPos = bones.Where(x => x.BoneId == GetSegmentationType(targetId)).ToList()[0].Position;
            return new Vector3(targetPos.x - startPos.x, targetPos.y - startPos.y, targetPos.z - startPos.z);
        }

        private SegmentationBoneType GetSegmentationType(HumanBodyBones boneId) {
            switch (boneId) {
                case HumanBodyBones.LeftUpperArm:
                    return SegmentationBoneType.LeftShoulder;

                case HumanBodyBones.RightUpperArm:
                    return SegmentationBoneType.RightShoulder;
                
                case HumanBodyBones.LeftLowerArm:
                    return SegmentationBoneType.LeftElbow;
                
                case HumanBodyBones.RightLowerArm:
                    return SegmentationBoneType.RightElbow;
                
                case HumanBodyBones.LeftHand:
                    return SegmentationBoneType.LeftWrist;

                case HumanBodyBones.RightHand:
                    return SegmentationBoneType.RightWrist;
                
                case HumanBodyBones.LeftThumbDistal:
                    return SegmentationBoneType.LeftThumb;

                case HumanBodyBones.RightThumbDistal:
                    return SegmentationBoneType.RightThumb;

                case HumanBodyBones.LeftIndexDistal:
                    return SegmentationBoneType.LeftIndex;

                case HumanBodyBones.RightIndexDistal:
                    return SegmentationBoneType.RightIndex;

                case HumanBodyBones.LeftLittleDistal:
                    return SegmentationBoneType.LeftPinky;

                case HumanBodyBones.RightLittleDistal:
                    return SegmentationBoneType.RightPinky;

                case HumanBodyBones.LeftUpperLeg:
                    return SegmentationBoneType.LeftHip;
                
                case HumanBodyBones.RightUpperLeg:
                    return SegmentationBoneType.RightHip;

                case HumanBodyBones.LeftLowerLeg:
                    return SegmentationBoneType.LeftKnee;

                case HumanBodyBones.RightLowerLeg:
                    return SegmentationBoneType.RightKnee;
                
                case HumanBodyBones.LeftFoot:
                    return SegmentationBoneType.LeftAnkle;

                case HumanBodyBones.RightFoot:
                    return SegmentationBoneType.RightAnkle;

                case HumanBodyBones.LeftToes:
                    return SegmentationBoneType.LeftFootIndex;

                case HumanBodyBones.RightToes:
                    return SegmentationBoneType.rightFootIndex;

                default:
                throw new Exception($"Argument {boneId} isn't denied with GetType method.");
                
            }
        }
    }
}