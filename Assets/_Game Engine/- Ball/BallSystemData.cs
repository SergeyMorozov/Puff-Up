using System;
using System.Collections.Generic;

namespace GAME
{
    [Serializable]
    public class BallSystemData
    {
        public CheckPlace CheckPlace;
        public BallObject CreatedBall;
        public List<BallObject> Balls;
    }
}
