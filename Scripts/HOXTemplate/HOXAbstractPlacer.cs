using System.Collections.Generic;
using System.Collections;
using UnityEngine;


namespace kfutils.hox {

    [System.Serializable]
    public abstract class HOXAbstractPlacer : ScriptableObject {

        /// <summary>
        /// Returns the prefab to be instantiated.
        /// </summary>
        /// <returns>Prefab for feature.</returns>
        public abstract GameObject GetObject();

        /// <summary>
        /// The 2D area taken up by the feature, with X as the width and Y as the depth.
        /// This is intended to be used for generation algorithms, particularly segment
        /// factories, to for use in determining placement within the segment.
        /// </summary>
        /// <returns>A vector where X is width and Y is depth.</returns>
        public abstract Vector2 GetFootprint();
        
    }

}