using System.Collections.Generic;
using System.Collections;
using UnityEngine;


namespace kfutils.hox {

    /// The represents a list of similar and related prefabs that may represent a certain feature and may
    /// vary between segments (or within them).  This is intented for varations of the same things, such as
    /// intact and broken pillars in a ruin.  Usually, all should be alterted forms of the same initial form.
    ///
    /// Variations representing different constrcuction should typically be handled in generated the segments,
    /// not here (though special exceptions could exist).
    [System.Serializable]
    [CreateAssetMenu(menuName = "HOX/Randomized Placer", fileName = "FeaturePlacers", order = 202)]
    public class HOXSelectablePlacer : HOXAbstractPlacer {

        [System.Serializable]
        public struct PotentialFeature {
            [SerializeField] public GameObject feature;
            [SerializeField] [Range(1, 100)] public int chance;
        }

        /// <summary>The a list of prefabs to select from, along with the relative chance for each to be used.</summary>
        [SerializeField] PotentialFeature[] features;
        /// <summary>The width(x) and depth(y) it should be considered to occupy (for generating segments)</summary>
        [SerializeField] Vector2 footprint;


        public override Vector2 GetFootprint() => footprint;


        public override GameObject GetObject() {
            int chances = 1;
            foreach (PotentialFeature f in features) {
                chances += f.chance;
            }
            int roll = Random.Range(0, chances);
            int i = 0;
            GameObject output = null;
            //Debug.Log(chances + ", " + roll);
            while((output == null) && roll > -1) {
                if(roll <= features[i].chance) {
                    output = features[i].feature;
                } else {
                    roll -= features[i].chance;
                    i++;
                }
            }
            #if UNITY_ASSERTIONS
            Debug.Assert((output != null), "HOXSelectableFeature.GetObject(): Failed to find feature GameObject; output is still null!");
            #elif UNITY_EDITOR
            if(output == null) Debug.Log("HOXSelectableFeature.GetObject(): Failed to find feature GameObject; output is still null!");
            #endif
            return output;
        }


    }
}