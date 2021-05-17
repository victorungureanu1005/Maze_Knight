﻿using Maze_Knight.Models.EnemyModels;
using Maze_Knight.StaticClasses;
using Maze_Knight.ViewModels;
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
        private MapGridCell _currentMapGridCell;

        //Battle report string sent to the ExploreViewModel and three ints to store battle report information
        private string _battleReport = "";
        private int _totalDamageTaken = 0;
        private int _totalDamageDealt = 0;
        private int _roundNumber = 1;
        #endregion

        #region Constructor
        //Constructor taking in player instance, enemy instance and mapGridCell instance where the battle is taking place
        public BattleSystem(Player currentPlayer, Enemy enemyEngaged, MapGridCell mapGridCell)
        {
            _player = currentPlayer;
            _enemy = enemyEngaged;
            _currentMapGridCell = mapGridCell;
        }
        #endregion

        #region Main Methods
        //Calculate Battle
        public void Battle()
        {
            //While loop to run while player and enemy still alive
            while (_player.IsAlive == true && _enemy.IsAlive==true)
            {
                //If both are still alive after the previous battle round (or initially) have a new battle round.
                BattleRound();
                _roundNumber++;
            }

            //After the while loop finishes the win or lose condition is ran
            if (_player.IsAlive==true)
            {
                BattleConsequencesIfWon();
            }
            else
            {
                BattleConsequencesIfLost();
            }
            //Send the battle report string to the view model's property to be printed on the view
            ((ExploreViewModel)Mediator.theApp.SelectedViewModel).BattleReport = _battleReport;
        }

        //Method to handle what happened if battle was won
        public void BattleConsequencesIfWon()
        {
            //Battle report updates
            _battleReport += "\x0A You won this battle!";
            if (_roundNumber>4) _battleReport += $"\x0A After a long battle you finally won, time to move on!";
            else _battleReport += $"\x0A This was easy, you won!";
            _battleReport += $"\x0A You dealt {_totalDamageDealt} damage with you nice {_player.PlayerSelectedWeapon} and you took {_totalDamageTaken} damage from the {_enemy.EnemySubType}";

            //Modify player stats and map grid cell property
            _player.ReceiveExperience(_enemy.EnemyExperienceGiven);
            _player.ReceiveGoldDust(_enemy.GoldDustDrop);
            _currentMapGridCell.EnemyIsHere= false;
        }

        //Method to handle what happened if battle was lost
        public void BattleConsequencesIfLost()
        {
            //Update battle report string before sending it to the view model property. 
            _battleReport += " Well, you died, not sure how you read this, but apparently you do..." +
                             $"\x0A Anyways, just for the sake of you knowing what happened and maybe improving! You dealt {_totalDamageDealt} " +
                             $"damage and you took {_totalDamageTaken} damage from the {_enemy.EnemySubType}";
            Console.WriteLine("YOU LOST!");
        }

        #endregion

        #region Helper Functions

        private void BattleRound()
        {
            //Store the damage calculated in local ints
            int damageDealtToEnemy = CalculatePlayerDamageDone();
            int damageDealtToPlayer = CalculateEnemyDamageDone();
            //Store the damage in the total damage 
            _totalDamageDealt += damageDealtToEnemy;
            _totalDamageTaken += damageDealtToPlayer;

            _enemy.DecreaseHealth(damageDealtToEnemy);
            if (_enemy.IsAlive)
            {
                _player.DecreaseHealth(damageDealtToPlayer);
            }
            else
            {
                return;
            }
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
                case Enums.PlayerSelectedWeapon.Bow:
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