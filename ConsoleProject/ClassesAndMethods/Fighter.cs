using System;

namespace AIE
{
    class Fighter
    {
        //required attributes
        //current hp/health
        //attack points
        //defense points
            //defense mitigates damage taken by subtracting itself from the attacker's attack points
        public int currentHP = 20;              //health
        public int attackPoints = 6;            //attack
        public int defensePoints = 2;           //defense
        private string fighterName = "";        //namespace for fighter
        public int healCooldown = 0;            //CD length of heal
        public bool isGuarding = false;         //checks if the fighter is already guarding
        private bool isDead = false;            //checks if the fighter is dead or not

        Random rnd = new Random();

        public Fighter()
        {
            this.fighterName = ("Fighter " + rnd.Next(100));
        }

        public Fighter (string name)
        {
            this.fighterName = name;
        }

        public void takeDamage(Fighter opponent)
        {
            int temp = rnd.Next(2, 7);
            if(temp == 2)
            {
                Console.WriteLine("Glancing Blow..");
                this.attackPoints = 4;
            }
            else if (temp == 6)
            {
                Console.WriteLine("CRIT!");
                this.attackPoints = 6;
            }
            else
            {
                Console.WriteLine("Solid Hit!");
                this.attackPoints = 5;
            }
            this.currentHP = (this.currentHP - (opponent.attackPoints - this.defensePoints));
            if (this.currentHP <= 0)
            {
                this.isDead = true;
            }
        }

        public void Guard()
        {
            isGuarding = !isGuarding;
            if (isGuarding)
            {
                this.defensePoints = 4;
            }
            else
            {
                this.defensePoints = 2;
            }
        }

        public void Heal()
        {
            this.currentHP += 5;
        }

        public string GetName()
        {
            return this.fighterName;
        }

        public bool IsDead()
        {
            return this.isDead;
        }

    }
}
