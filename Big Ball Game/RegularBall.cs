using System.Collections.Generic;

namespace Big_Ball_Game
{
    internal class RegularBall : AbstractBall<RegularBall>
    {
        public new static int Count => 150;

        public static void InitializeBalls()
        {
            for (int i = 0; i < Count; i++)
                Balls.Add(new RegularBall());
        }

        public static void CollisionWith(List<RegularBall> regularBalls)
        {
            for (int i = 0; i < Balls.Count - 1; i++)
            {
                for (int j = i + 1; j < Balls.Count; j++)

                    if (Balls[i].IntersectsWith(Balls[j]))
                        if (Balls[i].Radius > Balls[j].Radius)
                            Balls[i].Eats(Balls[j]);
                        else
                            Balls[j--].Eats(Balls[i]);
            }
        }

        public static void CollisionWith(List<MonsterBall> monsterBalls)
        {
            for (int i = 0; i < Balls.Count; i++)
                for (int j = 0; j < monsterBalls.Count; j++)
                    if (Balls[i].IntersectsWith(monsterBalls[j]))
                    {
                        monsterBalls[j].Eats(Balls[i]);
                        i--;
                        break;
                    }
        }

        public static void CollisionWith(List<RepellentBall> repellentBalls)
        {
            for (int i = 0; i < Balls.Count; i++)
                for (int j = 0; j < repellentBalls.Count; j++)
                    if (Balls[i].IntersectsWith(repellentBalls[j]))
                        repellentBalls[j].Eats(Balls[i]);
        }
        
        public override void Eats(RegularBall ball)
        {
            BallGrowth += ball.Radius;
            OutOfBoundsFix();
            Balls.Remove(ball);
        }

        public override void Eats(MonsterBall ball) => ball.Eats(this);
        public override void Eats(RepellentBall ball) => ball.Eats(this);
    }
}