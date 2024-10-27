using System.Collections.Generic;
using System.Collections;
using UnityEngine;


namespace kfutils.hox {

    [System.Serializable]
    public class HOXRealizedFeature {
        public HOXAbstractFeature feature;
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 scale = new Vector3(1, 1, 1);
        public bool mirrorRotations = true;
    }


}