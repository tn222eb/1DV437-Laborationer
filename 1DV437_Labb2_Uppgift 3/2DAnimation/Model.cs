    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2DAnimation
{
    class Model
    {
        private float timeElapsed;
        private float maxTime = 5.0f;
        private float numberOfFrames = 24;

        public int Update(float elapsedTime)
        {
            timeElapsed += elapsedTime;
            float percentAnimated = timeElapsed / maxTime;
            int frame = (int)(percentAnimated * numberOfFrames);

            return frame;
        }
    }
}
