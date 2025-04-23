using System.Collections.Generic;
using System.Collections;
using UnityEngine;


namespace kfutils.hox {

    [System.Serializable]
    [CreateAssetMenu(menuName = "HOX/HOX Segment", fileName = "HOXSegment", order = 40)]
    public class HOXSegment : ScriptableObject {

        // length and position are along the axis of progression (i.e., axis of symmetry); with is perpendicular to it
        [SerializeField] float width;
        [SerializeField] float length;
        [SerializeField] List<HOXRealizedFeature> features;
        [SerializeField] bool symmetrical = true;
        
        public float Width => width;
        public float Length => length;
        public List<HOXRealizedFeature> Features => features;
        public bool Symmetrical => Symmetrical;



        public void Build(HOXObject parent, HOXRegion region, Vector3 location) {
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
