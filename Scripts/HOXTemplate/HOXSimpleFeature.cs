using System.Collections.Generic;
using System.Collections;
using UnityEngine;


namespace kfutils.hox {

    /// This represents a single prefab, and is intended to be the typical representaion.
    [System.Serializable]
    [CreateAssetMenu(menuName = "HOX/Simple Feature", fileName = "Feature", order = 101)]
    public class HOXSimpleFeature : HOXAbstractFeature {
        /// <summary>The prefbab to be used.</summary>
        [SerializeField] GameObject feature;
        /// <summary>The width(x) and depth(y) it should be considered to occupy (for generating segments)</summary>
        [SerializeField] Vector2 footprint;

        public override Vector2 GetFootprint() => footprint;
        public override GameObject GetObject() => feature;

    }
}