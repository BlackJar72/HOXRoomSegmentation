using System.Collections.Generic;
using System.Collections;
using UnityEngine;


namespace kfutils.hox {

    [System.Serializable]
    [CreateAssetMenu(menuName = "HOX/HOX Layer", fileName = "HOXLayer", order = 20)]
    public class HOXLayer : ScriptableObject {

        [SerializeField] List<HOXRegion> regions;


        // Properties
        public List<HOXRegion> Regions => regions;


        public void Build(HOXObject parent) {
            foreach(HOXRegion region in regions) {
                region.Build(parent);
            }
        }


    }

}
