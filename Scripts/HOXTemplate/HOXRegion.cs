using System.Collections.Generic;
using System.Collections;
using UnityEngine;


namespace kfutils.hox {

    [System.Serializable]
    public class HOXRegion {
        private HOXLayer layer;
        private HOXObject parent;
        // length and position are along the axis of progression (i.e., axis of symmetry); with is perpendicular to it
        public float width, length, position;
        public HOXSegment segment;
        public uint numSegments;


        //Properties
        public HOXLayer Layer => layer;
        public HOXObject Parent => parent;


        public void SetParent(HOXLayer l) {
            layer = l;
            parent = l.Parent;
        }


        public void Build() {
            for(int i = 0; i < numSegments; i++) {
                Vector3 location = parent.transform.position + ((position + (segment.length * i)) * parent.transform.forward);
                segment.Build(this, location);
            }
        }


    }

}
