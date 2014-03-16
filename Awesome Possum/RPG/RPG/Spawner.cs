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
        public Character GetEnemy(int levelWidth, int levelHeight, Character target)
        {
            if (CanSpawn())
            {
                --SpawnCount;
                var i = rand.Next(Sprites.Count);
                var spriteSheet = Sprites[i];

                var ai = new AIController(new EnemyAI(rand.Next(Difficulty * 20, Difficulty * 30)));
                var c = new Character("Enemy", 50 * Difficulty, 2 * Difficulty)
                {
                    Controller = ai,
                    X = rand.Next(levelWidth),
                    Y = rand.Next(levelHeight),
                    Speed = rand.Next(1, 5)
                };

                ai.Self = c;
                ai.Enemy = target;

                c.Sprites = spriteSheet;

                return c;
            }
            return null;
        }
    }
}
