using System;
using System.Collections.Generic;
using UnityEngine;

namespace VRMBehavior {
    public class HumanoidBehavior : MonoBehaviour {
        [SerializeField] private Animator humanoid;
        List<BoneBehavior> boneBehaviors = new ();
        Reader reader;

        void Awake() {
            foreach (var tupleData in BoneAxisData.instance.GetAxisData) {
                boneBehaviors.Add(new BoneBehavior(tupleData.Item1, humanoid, tupleData.Item2, tupleData.Item3));
            }
            reader = new CsvReader();
            reader.onReceivedDelegate += OnReceived;

        }

        void Start() {
            reader.Play();
        }

        private void OnReceived(List<String> lines) {
            var parser = new SegmentationBoneParser(lines);
            var bones = parser.GetBones();
            

            foreach (var boneBehavior in boneBehaviors) {
                boneBehavior.Look(bones);
            }
        }
    }
}
