using System.Collections.Generic;
using System.Collections;
using UnityEngine;


namespace kfutils.hox {

    [System.Serializable]
    [CreateAssetMenu(menuName = "HOX/HOX Region", fileName = "HOXRegion", order = 30)]
    public class HOXRegion : ScriptableObject {

        [SerializeField] float width;
        [SerializeField] float length;
        [SerializeField] float position;
        [SerializeField] HOXSegment segment;
        [SerializeField] uint numSegments;


        public void Build(HOXObject parent) {
            for(int i = 0; i < numSegments; i++) {
                Vector3 location = parent.transform.position + ((position + (segment.Length * i)) * parent.transform.forward);
                segment.Build(parent, this, location);
            }
        }


    }

}
