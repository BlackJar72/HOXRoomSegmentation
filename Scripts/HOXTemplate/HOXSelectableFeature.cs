using System.Collections.Generic;
using System.Collections;
using UnityEngine;


namespace kfutils.hox {



    [System.Serializable]
    [CreateAssetMenu(menuName = "HOX/Randomized Feature", fileName = "Features", order = 102)]
    public class HOXSelectableFeature : HOXAbstractFeature {

        [System.Serializable]
        public struct PotentialFeature {
            [SerializeField] public GameObject feature;
            [SerializeField] [Range(1, 100)] public int chance;
        }


        [SerializeField] PotentialFeature[] features;
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