using System.Collections.Generic;
using System.Collections;
using UnityEngine;


namespace kfutils.hox {

    [System.Serializable]
    public class HOXSegment {
        // length and position are along the axis of progression (i.e., axis of symmetry); with is perpendicular to it
        public float width, length;
        public List<HOXRealizedFeature> features;
        public bool symmetrical = true;


        public void Build(HOXRegion region, Vector3 location) {
            HOXObject parent = region.Parent;
            foreach(HOXRealizedFeature feature in features) {
                GameObject placed = GameObject.Instantiate(feature.feature.GetObject(), parent.transform);
                placed.transform.localPosition += location + feature.position;
                placed.transform.localRotation = Quaternion.Euler(feature.rotation);
                placed.transform.localScale = feature.scale;
                if(symmetrical && (feature.position.x != 0)) {
                    GameObject mirrored = GameObject.Instantiate(feature.feature.GetObject(), parent.transform);
                    mirrored.transform.localPosition += location - feature.position;
                    Vector3 mirroredRot = feature.rotation;
                    if(feature.mirrorRotations) {
                        mirroredRot.y *= -1;
                        mirroredRot.z *= -1;
                    }
                    mirrored.transform.localRotation = Quaternion.Euler(mirroredRot);
                    mirrored.transform.localScale = feature.scale;
                }
            }
        }
    }

}
