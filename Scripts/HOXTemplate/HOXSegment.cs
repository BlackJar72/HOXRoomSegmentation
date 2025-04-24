using System.Collections.Generic;
using System.Collections;
using UnityEngine;


namespace kfutils.hox {

    [System.Serializable]
    [CreateAssetMenu(menuName = "HOX/HOX Segment", fileName = "HOXSegment", order = 40)]
    public class HOXSegment : ScriptableObject {

        // length and position are along the axis of progression (i.e., axis of symmetry); with is perpendicular to it
        // FIXME: Some of this should be stored else where to allow mutability!!!
        [SerializeField] float width;
        [SerializeField] float length;
        [SerializeField] List<HOXRealizedFeature> features;
        [SerializeField] bool symmetrical = true;
        
        public float Width => width;
        public float Length => length;
        public List<HOXRealizedFeature> Features => features;
        public bool Symmetrical => Symmetrical;

        
        public List<HOXRealizedPlacer> GetPlacers() {
            List<HOXRealizedPlacer> output = new List<HOXRealizedPlacer>();
            foreach(HOXRealizedFeature feature in features) {
               output.Add(feature.GetPlacer());
            }
            return output;
        }


        public void Build(HOXObject parent, HOXRegion region, List<HOXRealizedPlacer> placers, Vector3 location) {
            foreach(HOXRealizedPlacer feature in placers) {
                GameObject placed = GameObject.Instantiate(feature.placer.GetObject(), parent.transform);
                placed.transform.localPosition += location + feature.position;
                placed.transform.localRotation = Quaternion.Euler(feature.rotation);
                placed.transform.localScale = feature.scale;
                if(symmetrical && (feature.position.x != 0)) {
                    GameObject mirrored = GameObject.Instantiate(feature.placer.GetObject(), parent.transform);
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
