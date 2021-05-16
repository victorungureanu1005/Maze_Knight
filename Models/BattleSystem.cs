using Maze_Knight.Models.EnemyModels;
using Maze_Knight.StaticClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Knight.Models
{
    public class BattleSystem
    {
        #region ClassFields
        private Player _player;
        private Enemy _enemy;
        #endregion

        #region Constructor
        //Constructor taking in player instance and enemy instance
        public BattleSystem(Player currentPlayer, Enemy enemyEngaged)
        {
            _player = currentPlayer;
            _enemy = enemyEngaged;
        }
        #endregion

        #region Main Methods
        //Calculate Battle
        public void Battle()
        {
            while (_player.IsAlive == true && _enemy.IsAlive==true)
            {
                BattleRound();
            }
            if (_player.IsAlive==true)
            {
                BattleResultIfWon();
            }
            else
            {
                BattleResultIfLost();
            }
        }

        //Battle actions if won
        public void BattleResultIfWon()
        {
            Console.WriteLine("YOU WON");
        }

        //Battle actions if lost
        public void BattleResultIfLost()
        {
            Console.WriteLine("YOU LOST");
        }

        #endregion

        #region Helper Functions

        private void BattleRound()
        {
            _enemy.DecreaseHealth(CalculatePlayerDamageDone());
            if (_enemy.IsAlive)
            {
                _player.DecreaseHealth(CalculateEnemyDamageDone());
            }
            else return;
        }

        //Calculate Damage
        private int CalculatePlayerDamageDone()
        {
            //Check rune is active and provide damage factor to be divided to depending on resistance;
            double runeDamageFactor = 1;
            if (_player.RuneActive&&_player.RuneNumberOfTurnsActive >0)
            {
                runeDamageFactor = _enemy.RuneResistance;
                _player.RuneNumberOfTurnsActive--;
                if (_player.RuneNumberOfTurnsActive<=0)
                {
                    _player.RuneActive = false;
                }
            }

            //Calculate weaponDamageFactor
            //Default is set at 1 - as if there were no resistances, please note that to calculate the damage we will divide to this factor similar as for the runeDamageFactor
            //Decrease the enemy resistance depending on skill of the player by 0.02/skill (const, can be changed)
            double weaponDamageFactor = 1;
            const double RESISTANCE_DECREASE_DEPENDING_ON_SKILL = 0.02D;

            switch (_player.PlayerSelectedWeapon)
            {
                case Enums.PlayerSelectedWeapon.Sword:
                    weaponDamageFactor = _enemy.SwordResistance - (RESISTANCE_DECREASE_DEPENDING_ON_SKILL * _player.SwordSkillLevel);
                    break;
                case Enums.PlayerSelectedWeapon.BowAndArrow:
                    weaponDamageFactor = _enemy.ArrowResistance - (RESISTANCE_DECREASE_DEPENDING_ON_SKILL * _player.ArcherySillLevel);
                    break;
                case Enums.PlayerSelectedWeapon.Halberd:
                    weaponDamageFactor = _enemy.HalberdResistance - (RESISTANCE_DECREASE_DEPENDING_ON_SKILL * _player.HalberdSkillLevel);
                    break;
                default: break;
            }

            //Calculate damage by selecting a random damage dealt value between min and max (+1 as Random.Next takes exclusive the max value)...
            //...and divide by damage Factors to increase final damage dealt
            int damageDealt;
            damageDealt = (int)Math.Round(RandomGenerator.random.Next(_player.MinDamage, _player.MaxDamage + 1) / weaponDamageFactor / runeDamageFactor);
            return damageDealt;
        }

        private int CalculateEnemyDamageDone()
        {   
            //Calculate resistance to enemy type factor
            //Default is set at 1 - as if there were no resistances, please note that to calculate the damage we will divide to this factor 
            //Increase the resistance depending on player skill 0.03/skill (const, can be changed)
            double resistanceToEnemyTypeFactor = 1;
            const double RESISTANCE_INCREASE_DEPENDING_ON_SKILL = 0.03D;
            if (_enemy.EnemyType == EnemyTypes.HumanoidEnemies)
            {
                resistanceToEnemyTypeFactor = 1 - (RESISTANCE_INCREASE_DEPENDING_ON_SKILL * _player.HumanoidResistance);
            }
            if (_enemy.EnemyType == EnemyTypes.MysticalCreaturesEnemies)
            {
                resistanceToEnemyTypeFactor = 1 - (RESISTANCE_INCREASE_DEPENDING_ON_SKILL * _player.MysticalResistance);
            }

            //Calculate damage by selecting a random damage dealt value between min and max (+1 as Random.Next takes exclusive the max value)...
            //...and divide by resistance factor identified above
            int damageDealt;
            damageDealt = (int)Math.Round(RandomGenerator.random.Next(_enemy.MinDamage, _enemy.MaxDamage + 1) / resistanceToEnemyTypeFactor);
            return damageDealt;
        }


        #endregion




    }
}
