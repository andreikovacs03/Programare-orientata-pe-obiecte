using System;
using System.Drawing;
using System.Collections.Generic;

namespace Big_Ball_Game
{
    class RegularBall : AbstractBall<RegularBall>
    {
        public static int Count { get => 150; }

        public RegularBall() : base() { }

        public static void InitializeBalls()
        {
            for (int i = 0; i < Count; i++)
                Balls.Add(new RegularBall());
        } 
         
        public override void Eats(RegularBall ball)
        {
            BallGrowth += ball.Radius;
            OutOfBoundsFix();
            Balls.Remove(ball);
        }

        public override void Eats(MonsterBall ball) => ball.Eats(this);
        public override void Eats(RepellentBall ball) => ball.Eats(this);

        public static void OutOfBoundsFixBalls()
        {
            foreach (var ball in Balls)
                ball.OutOfBoundsFix();
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

        public static void CollisionWith(List<RepellentBall> repelentBalls)
        {
            for (int i = 0; i < Balls.Count; i++)
                for (int j = 0; j < repelentBalls.Count; j++)
                    if (Balls[i].IntersectsWith(repelentBalls[j]))
                        repelentBalls[j].Eats(Balls[i]);
        }
    }
}