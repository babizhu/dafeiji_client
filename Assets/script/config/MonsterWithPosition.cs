using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

   public class EnemyWithPosition
    {
        private EnemyTemplet enemyTemplet;
        
        private float x,y;

        public EnemyTemplet EnemyTemplet
        {
            set { enemyTemplet = value; }
            get { return enemyTemplet; }
        }
       

        public override string ToString()
        {
            string result = "enemyTemplet=" + enemyTemplet.Id + ",x=" + x + ",y=" + y;
            return result;
        }

        public float X
        {
            set { x = value; }
            get { return x; }
        }

        public float Y
        {
            set { y = value; }
            get { return y; }
        }

    }

