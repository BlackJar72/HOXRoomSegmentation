using System.Collections.Generic;
using System.Collections;
using UnityEngine;


namespace kfutils.hox {

    [System.Serializable]
    [CreateAssetMenu(menuName = "HOX/HOX Template", fileName = "HOXTemplate", order = 0)]
    public class HOXTemplate : ScriptableObject {
        /// <summary>The layers to be generated; multiple allowed, so allow overlapping patterns.  Analogous to HOX gene
        /// duplications that allow more complex body plans in vertibrates. </summary>
        [SerializeField] List<HOXLayer> hoxLayers;


        void Awake() {}


        public void Build(HOXObject hox) {
            foreach(HOXLayer layer in hoxLayers) {
                layer.Build(hox);
            }
        }

    }

}
