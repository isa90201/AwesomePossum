using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    class CharacterManager
    {
        public Character User { get; set; }
        public List<Character> Enemies { get; set; }


        public CharacterManager()
        {
            Enemies = new List<Character>();
        }

        public IEnumerable<Character> All
        {
            get
            {
                yield return User;

                foreach (var e in Enemies)
                {
                    yield return e;
                }
            }
        }

        public IEnumerable<IController> Controllers
        {
            get
            {
                foreach (var c in All)
                    yield return c.Controller;
            }
        }

        public void ClearEnemies()
        {
            Enemies.Clear();
        }

        public void RemoveDeadEnemies()
        {
            Enemies.RemoveAll(c => !c.IsAlive);
        }

        public void AddEnemy(Character c)
        {
            Enemies.Add(c);
        }
    }
}
