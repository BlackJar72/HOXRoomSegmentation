using System.Collections.Generic;
using System.Collections;
using UnityEngine;


namespace kfutils.hox {

    [System.Serializable]
    public class HOXObject : MonoBehaviour {
        /// <summary>The layers to be generated; multiple allowed, so allow overlapping patterns.  Analogous to HOX gene
        /// duplications that allow more complex body plans in vertibrates. </summary>
        [SerializeField] HOXTemplate template;


        void Awake() {}


        void Start() {
            // This will be removed later, but good for testing during early development
            Build();
        }


        public void Build() {
            template.Build(this);
        }

    }

}
