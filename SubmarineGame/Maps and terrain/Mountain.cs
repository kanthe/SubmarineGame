using Microsoft.Xna.Framework;

namespace Model
{
    class Mountain
    {
        private float _lowHeight;
        private float _highHeight;
        private float _length;
        private Vector2[] _lowPositions;
        private float[] _yPositionsHigh;

        public Mountain(float xPosition, float lowHeight, float highHeight, float length)
        {
            _lowHeight = lowHeight;
            _highHeight = highHeight;
            _length = length;

            float startheight = lowHeight + (highHeight - lowHeight) / 2;
            int noOfElements = (int)((float)MapL1.NO_GROUND_ELEMENTS * (_length / MapL1.MAP_WIDTH));
            LowPositions = new Vector2[noOfElements];
            LowPositions[0] = new Vector2(xPosition, startheight);
            YPositionsHigh = new float[noOfElements];
            YPositionsHigh[0] = startheight;

            for (int i = 1; i < noOfElements; i++)
            {
                LowPositions[i] = new Vector2(LowPositions[i - 1].X + length / noOfElements, LowPositions[i - 1].Y + (float)Mathematics.RAND.NextDouble() * 0.02f - 0.01f);
                YPositionsHigh[i] = YPositionsHigh[i - 1] + (float)Mathematics.RAND.NextDouble() * 0.02f;

                if (LowPositions[i].Y < lowHeight)
                {
                    LowPositions[i].Y = lowHeight;
                }
                if (YPositionsHigh[i] > highHeight)
                {
                    YPositionsHigh[i] = highHeight;
                }
                if (LowPositions[i].Y > YPositionsHigh[i])
                {
                    LowPositions[i].Y = YPositionsHigh[i];
                }
            }
        }
        
        #region Properties
        public float LowHeight
        {
            get
            {
                return _lowHeight;
            }

            set
            {
                _lowHeight = value;
            }
        }

        public float HighHeight
        {
            get
            {
                return _highHeight;
            }

            set
            {
                _highHeight = value;
            }
        }

        public float Length
        {
            get
            {
                return _length;
            }

            set
            {
                _length = value;
            }
        }

        public Vector2[] LowPositions
        {
            get
            {
                return _lowPositions;
            }

            set
            {
                _lowPositions = value;
            }
        }

        public float[] YPositionsHigh
        {
            get
            {
                return _yPositionsHigh;
            }

            set
            {
                _yPositionsHigh = value;
            }
        }
        #endregion
    }
}
