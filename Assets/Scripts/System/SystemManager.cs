using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.System
{
    public class SystemManager
    {
        protected Main main;
        public SystemManager(Main main)
        {
            this.main = main;
        }
        public virtual void OnInit()
        {
            
        }
        public virtual void OnDestroy()
        {

        }
    }
}