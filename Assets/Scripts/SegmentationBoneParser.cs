using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;

namespace VRMBehavior {
    public class SegmentationBoneParser {
        private Dictionary<SegmentationBoneType, Vector3> boneDic;

        public SegmentationBoneParser(List<String> lines) {
            boneDic = new Dictionary<SegmentationBoneType, Vector3>();
            for (int i = 0; i < lines.Count; i++) {
                var type = (SegmentationBoneType)Enum.ToObject(typeof(SegmentationBoneType), i);
                List<float> values = lines[i].Split(',').Select(str => float.Parse(str, CultureInfo.InvariantCulture.NumberFormat)).ToList();
                if (values.Count == 3) {
                    boneDic.Add(type, new Vector3(values[0], - values[1], values[2]));
                } else {
                    break;
                }
            }
        }

        public List<SegmentationBone> GetBones() {
            var bones = new List<SegmentationBone>();
            foreach (SegmentationBoneType type in Enum.GetValues(typeof(SegmentationBoneType))) {
                bones.Add(GetBone(type));
            }
            return bones;
        }

        public SegmentationBone GetBone(SegmentationBoneType boneId) {
            
            return new SegmentationBone(boneId, boneDic[boneId]);
        }
}
}