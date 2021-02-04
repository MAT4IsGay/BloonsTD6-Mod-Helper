﻿using System;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Simulation.Towers.Projectiles;
using Assets.Scripts.Simulation.Towers.Weapons;
using MelonLoader;
using UnhollowerBaseLib;
using UnityEngine;

namespace BloonsTD6_Mod_Helper
{
    /// <summary>
    /// Extend this Class instead of MelonMod to gain access to dozens of easy to use built-in hooks
    /// </summary>
    public abstract class BloonsTD6Mod : MelonMod
    {
        /// <summary>
        /// Called when you go to the main menu screen
        ///
        /// Equivalent to a HarmonyPostFix on MainMenu.OnEnable
        /// </summary>
        public virtual void OnMainMenu()
        {
        }


        #region Input Hooks

        /// <summary>
        /// Called on the frame that a key starts being held
        ///
        /// Equivalent to a HarmonyPostFix on Input.GetKeyDown
        /// </summary>
        public virtual void OnKeyDown(KeyCode keyCode)
        {
        }

        /// <summary>
        /// Called on the frame that a key stops being held
        ///
        /// Equivalent to a HarmonyPostFix on Input.GetKeyUp
        /// </summary>
        public virtual void OnKeyUp(KeyCode keyCode)
        {
        }

        /// <summary>
        /// Called every frame that a key is being held 
        ///
        /// Equivalent to a HarmonyPostFix on Input.GetKey
        /// </summary>
        public virtual void OnKeyHeld(KeyCode keyCode)
        {
        }

        #endregion

        #region Bloon Hooks

        /// <summary>
        /// Called right before a Bloon would leak.
        /// Return 'false' to prevent the leak from happening
        ///
        /// Equivalent to a HarmonyPreFix on Bloon.Leaked
        /// </summary>
        public virtual bool PreBloonLeaked(Bloon bloon)
        {
            return true;
        }

        /// <summary>
        /// Called right after a Bloon leaks.
        /// Return 'false' to prevent the leak from happening
        /// 
        /// Equivalent to a HarmonyPostFix on Bloon.Leaked
        /// </summary>
        public virtual void PostBloonLeaked(Bloon bloon)
        {
        }


        /// <summary>
        /// Called right after a Bloon is first created
        /// 
        /// Equivalent to a HarmonyPostFix on Bloon.Initialise
        /// </summary>
        public virtual void OnBloonCreated(Bloon bloon)
        {
        }


        /// <summary>
        /// Called right after a Bloon is destroyed
        /// 
        /// Equivalent to a HarmonyPostFix on Bloon.OnDestroy
        /// </summary>
        public virtual void OnBloonDestroy(Bloon bloon)
        {
        }
        
        /// <summary>
        /// Called right after a Bloon is damaged
        /// 
        /// Equivalent to a HarmonyPostFix on Bloon.Damaged
        /// </summary>
        public virtual void PostBloonDamaged(Bloon bloon, float totalAmount, Il2CppStringArray types,
            Projectile projectile, bool distributeToChildren, bool overrideDistributeBlocker, bool createEffect,
            Tower tower, Il2CppStringArray ignoreImmunityForBloonTypes, bool ignoreNonTargetable = false,
            bool blockSpawnChildren = false, bool canDestroyProjectile = true)
        {
        }

        /// <summary>
        /// Called right after a Bloon is damaged
        /// 
        /// Equivalent to a HarmonyPostFix on Bloon.Damaged
        /// </summary>
        public virtual void PostBloonDamaged(Bloon bloon, float totalAmount, bool ignoreNonTargetable = false)
        {
        }

        #endregion

        #region Tower Hooks

        /// <summary>
        /// Called right after a Tower is initialized
        /// 
        /// Equivalent to a HarmonyPostFix on Tower.Initialise
        /// </summary>
        public virtual void OnTowerCreated(Tower tower, Entity target, Model modelToUse)
        {
        }
        
        /// <summary>
        /// Called right after a Tower is destroyed
        /// 
        /// Equivalent to a HarmonyPostFix on Tower.Destroyed
        /// </summary>
        public virtual void OnTowerDestroyed(Tower tower)
        {
        }
        
        /// <summary>
        /// Called right after a Tower is sold
        /// 
        /// Equivalent to a HarmonyPostFix on Tower.OnSold
        /// </summary>
        public virtual void OnTowerSold(Tower tower, float amount)
        {
        }
        
        /// <summary>
        /// Called right after a Tower is selected by the player
        /// 
        /// Equivalent to a HarmonyPostFix on Tower.Highlight
        /// </summary>
        public virtual void OnTowerSelected(Tower tower)
        {
        }

        /// <summary>
        /// Called right after a Tower is deselected by the player
        /// 
        /// Equivalent to a HarmonyPostFix on Tower.UnHighlight
        /// </summary>
        public virtual void OnTowerDeselected(Tower tower)
        {
        }
        
        /// <summary>
        /// Called right after a Tower is upgraded
        /// </summary>
        public virtual void OnTowerUpgraded(Tower tower, String upgradeName, TowerModel newBaseTowerModel)
        {
        }
        
        /// <summary>
        /// Called right after a Tower's TowerModel is changed for any reason (creation, upgrading, etc.)
        ///
        /// Equivalent to a HarmonyPostFix on Tower.UpdatedModel
        /// </summary>
        public virtual void OnTowerModelChanged(Tower tower, Model newModel)
        {
        }
        
        #endregion

        #region Simulation Hooks

        /// <summary>
        /// Called right after Cash is added in a game
        /// Tower might be null
        /// 
        /// Equivalent to a HarmonyPostFix on Simulation.AddCash
        /// </summary>
        public virtual void OnCashAdded(double amount, Simulation.CashType from,
            int cashIndex, Simulation.CashSource source, Tower tower)
        {
            
        }
        
        /// <summary>
        /// Called right after Cash is removed in a game
        /// 
        /// Equivalent to a HarmonyPostFix on Simulation.RemoveCash
        /// </summary>
        public virtual void OnCashRemoved(double amount, Simulation.CashType from, int cashIndex, Simulation.CashSource source)
        {
            
        }
        
        /// <summary>
        /// Called right after a round starts
        /// 
        /// Equivalent to a HarmonyPostFix on Simulation.OnRoundStart
        /// </summary>
        public virtual void OnRoundStart()
        {
            
        }
        
        /// <summary>
        /// Called right after a round starts
        /// 
        /// Equivalent to a HarmonyPostFix on Simulation.OnRoundEnd
        /// </summary>
        public virtual void OnRoundEnd()
        {
            
        }
        
        /// <summary>
        /// Called right after a match ends in defeat
        /// 
        /// Equivalent to a HarmonyPostFix on Simulation.OnDefeat
        /// </summary>
        public virtual void OnDefeat()
        {
            
        }

        #endregion
        
        /// <summary>
        /// Called right after a match ends in victory
        /// 
        /// Equivalent to a HarmonyPostFix on InGame.OnVictory
        /// </summary>
        public virtual void OnVictory()
        {
            
        }
        
        /// <summary>
        /// Called right after a match starts
        /// 
        /// Equivalent to a HarmonyPostFix on InGame.StartMatch
        /// </summary>
        public virtual void OnMatchStarted()
        {
            
        }
        
        /// <summary>
        /// Called right after a game ends in victory
        /// 
        /// Equivalent to a HarmonyPostFix on InGame.OnVictory
        /// </summary>
        public virtual void OnFastForwardChanged(bool newValue)
        {
            
        }
        
        
        /// <summary>
        /// Called right after a Weapon is created
        ///
        /// Equivalent to a HarmonyPostFix on Weapon.Initialise
        /// </summary>
        public virtual void OnWeaponCreated(Weapon weapon, Entity entity, Model modelToUse)
        {
        }

        
        /// <summary>
        /// Called right after a Tower's TowerModel is changed for any reason (creation, upgrading, etc.)
        ///
        /// Equivalent to a HarmonyPostFix on Weapon.UpdatedModel
        /// </summary>
        public virtual void OnWeaponModelChanged(Weapon weapon, Model newModel)
        {
        }
        
        /// <summary>
        /// Called right after a Projectile is created
        ///
        /// Equivalent to a HarmonyPostFix on Projectile.Initialise
        /// </summary>
        public virtual void OnProjectileCreated(Projectile projectile, Entity entity, Model modelToUse)
        {
        }

        
        /// <summary>
        /// Called right after a Tower's TowerModel is changed for any reason (creation, upgrading, etc.)
        ///
        /// Equivalent to a HarmonyPostFix on Projectile.UpdatedModel
        /// </summary>
        public virtual void OnProjectileModelChanged(Projectile projectile, Model newModel)
        {
        }

    }
}