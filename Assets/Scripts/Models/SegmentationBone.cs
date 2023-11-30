using UnityEngine;

namespace VRMBehavior {
    public enum SegmentationBoneType {
        Nose,
        LeftEyeInner, LeftEye, leftEyeOuter,
        RightEyeInner, RightEye, RightEyeOuter,
        LeftEar, RightEar,
        MouthLeft, MouthRight,
        LeftShoulder, RightShoulder,
        LeftElbow, RightElbow,
        LeftWrist, RightWrist,
        LeftPinky, RightPinky,
        LeftIndex, RightIndex,
        LeftThumb, RightThumb,
        LeftHip, RightHip,
        LeftKnee, RightKnee,
        LeftAnkle, RightAnkle,
        LeftHeel, RightHeel,
        LeftFootIndex, rightFootIndex,
    }

    public class SegmentationBone {
        SegmentationBoneType boneId;
        Vector3 position;

        public SegmentationBoneType BoneId => boneId;
        public Vector3 Position => position;

        public SegmentationBone(SegmentationBoneType boneId, Vector3 position) {
            this.boneId = boneId;
            this.position = position;

        }
    }
}