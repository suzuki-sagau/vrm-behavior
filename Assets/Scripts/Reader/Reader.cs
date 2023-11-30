using System;
using System.Collections.Generic;

namespace VRMBehavior {
    public abstract class Reader {
        public delegate void OnReceivedDelegate(List<String> lines);
        public OnReceivedDelegate onReceivedDelegate = delegate(List<string> lines) {};

        public abstract void Play();
    }
}