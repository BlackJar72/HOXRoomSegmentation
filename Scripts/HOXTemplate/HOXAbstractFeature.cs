using System.Collections.Generic;
using System.Collections;
using UnityEngine;


namespace kfutils.hox {

    [System.Serializable]
    public abstract class HOXAbstractFeature : ScriptableObject {
        public abstract GameObject GetObject();
        public abstract Vector2 GetFootprint();
    }

}