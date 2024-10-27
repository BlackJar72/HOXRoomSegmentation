using System.Collections.Generic;
using System.Collections;
using UnityEngine;


namespace kfutils.hox {

    [System.Serializable]
    [CreateAssetMenu(menuName = "HOX/Simple Feature", fileName = "Feature", order = 101)]
    public class HOXSimpleFeature : HOXAbstractFeature {
        [SerializeField] GameObject feature;
        [SerializeField] Vector2 footprint;

        public override Vector2 GetFootprint() => footprint;
        public override GameObject GetObject() => feature;

    }
}