using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AttTypeDefine
{
    public struct GlobalLevel
    {
        private GameObject whiteball;
        public GameObject WhiteBall
        {
            get
            {
                return whiteball;
            }
        }

        private GameObject table;
        public GameObject Table
        {
            get
            {
                return table;
            }
        }

        public void Initialized(GameObject wb,GameObject t)
        {
            table = t;
            whiteball = wb;
        }
    }
}
