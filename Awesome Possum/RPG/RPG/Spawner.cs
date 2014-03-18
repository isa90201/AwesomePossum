using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class Spawner
    {
        public int Difficulty { get; set; }
        public List<SpriteCollection> Sprites { get; set; }
        public int SpawnCount { get; set; }
        private Random rand;

        public Spawner()
        {
            rand = new Random();
        }

        public bool CanSpawn()
        {
            return SpawnCount > 0;
        }
        public Character GetEnemy(int x, int y, Character target)
        {
            if (CanSpawn())
            {
                --SpawnCount;
                var i = rand.Next(Sprites.Count);
                var spriteSheet = Sprites[i];

                return StaticSpawn(spriteSheet, rand.Next(Difficulty * 20, Difficulty * 30), 50 * Difficulty, 2 * Difficulty, x, y, rand.Next(1, 4), target, rand);
            }
            return null;
        }

        public static Character StaticSpawn(SpriteCollection spriteSheet, int aiDifficulty, int health, int attack, int x, int y, int speed, Character target, Random r)
        {
            var ai = new AIController(new EnemyAI(aiDifficulty, r));
            var c = new Character("Enemy", health, attack)
            {
                Controller = ai,
                X = x,
                Y = y,
                Speed = speed
            };

            ai.Self = c;
            ai.Enemy = target;

            c.Sprites = spriteSheet;

            return c;
        }

        public static int GetLocation(Random r, int totalWidth, int screenStart, int screenWidth)
        {
            var loc = r.Next(0, totalWidth - screenWidth);

            if (loc < screenStart)
                return loc;

            return loc + screenWidth;
        }
    }
}
