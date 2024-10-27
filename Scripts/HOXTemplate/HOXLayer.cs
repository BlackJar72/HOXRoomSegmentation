using System.Collections.Generic;
using System.Collections;
using UnityEngine;


namespace kfutils.hox {

    [System.Serializable]
    public class HOXLayer {
        private HOXObject parent;
        public List<HOXRegion> regions;


        // Properties
        public HOXObject Parent => parent;


        public void SetParent(HOXObject p) {
            parent = p;
            foreach(HOXRegion region in regions) {
                region.SetParent(this);
            }
        }


        public void Build() {
            foreach(HOXRegion region in regions) {
                region.Build();
            }
        }
    }

}
