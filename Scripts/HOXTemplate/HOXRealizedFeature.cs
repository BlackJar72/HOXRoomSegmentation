using System.Collections.Generic;
using System.Collections;
using UnityEngine;


namespace kfutils.hox {

    [System.Serializable]
    public class HOXRealizedFeature {
        public HOXAbstractFeature feature;
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 scale = Vector3.one;
        public bool mirrorRotations = true;
        public HOXRealizedPlacer GetPlacer() => new(this);
    }


    public class HOXRealizedPlacer {
        public HOXAbstractPlacer placer;
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 scale = Vector3.one;
        public bool mirrorRotations;
        public HOXRealizedPlacer(HOXRealizedFeature feature) {
            placer = feature.feature.GetPlacer();
            position = feature.position;
            rotation = feature.rotation;
            scale = feature.scale;
            mirrorRotations = feature.mirrorRotations;
        }
    }


}