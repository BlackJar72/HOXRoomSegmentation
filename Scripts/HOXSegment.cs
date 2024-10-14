using System.Collections.Generic;
using System.Collections;
using UnityEngine;


namespace kfutils.hox {

    [System.Serializable]
    public class HOXSegment {
        // length and position are along the axis of progression (i.e., axis of symmetry); with is perpendicular to it
        public float width, length;
        public List<HOXFeature> features;
        public bool symmetrical = true;


        public void Build(HOXRegion region, Vector3 location) {
            HOXObject parent = region.Parent;
            foreach(HOXFeature feature in features) {
                GameObject placed = GameObject.Instantiate(feature.feature, parent.transform);
                placed.transform.localPosition += location + feature.position;
                placed.transform.localRotation = Quaternion.Euler(feature.rotation);
                placed.transform.localScale = feature.scale;
                if(symmetrical) {
                    GameObject mirrored = GameObject.Instantiate(feature.feature, parent.transform);
                    mirrored.transform.localPosition += location - feature.position;
                    mirrored.transform.localRotation = Quaternion.Euler(feature.rotation);
                    mirrored.transform.localScale = feature.scale;
                }
            }
        }
    }

}
