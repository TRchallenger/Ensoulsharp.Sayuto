﻿using EnsoulSharp;
using EnsoulSharp.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoHungAIO.Helpers
{
    public  class Extensions
    {
        private static AIHeroClient Player = ObjectManager.Player;
        public static IDictionary<string, SpellSlot> BuffsList = new Dictionary<string, SpellSlot>()
        {
            {"deadlyvenom", SpellSlot.Unknown},
            {"toxicshotparticle", SpellSlot.E},
            {"dariushemo", SpellSlot.Unknown},
            {"brandablaze", SpellSlot.Unknown},
            {"summonerdot", SpellSlot.Unknown},
            {"cassiopeiamiasmapoison", SpellSlot.W},
            {"cassiopeianoxiousblastpoison", SpellSlot.Q},
            {"bantamtraptarget", SpellSlot.R},
            {"tristanaechargesound", SpellSlot.E},
            {"TrundlePain", SpellSlot.E},
            {"swainbeamdamage", SpellSlot.Q},
            {"SwainTorment", SpellSlot.Unknown},
            {"AlZaharMaleficVisions", SpellSlot.E},
            {"fizzmarinerdoombomb", SpellSlot.R},
            {"karthusfallenonecastsound", SpellSlot.R},
            {"CaitlynAceintheHole", SpellSlot.R},
            {"zedulttargetmark", SpellSlot.R},
            {"zileanqenemybomb", SpellSlot.R},
            {"VladimirHemoplague", SpellSlot.R},
        };
        public static bool CheckCriticalBuffs(AIHeroClient i)
        {
            double dmg = (from buff in i.Buffs
                          let b = BuffsList.FirstOrDefault(bd => bd.Key == buff.Name)
                          where b.GetType() != null
                          select Player.GetSpellDamage(i, b.Value, DamageStage.Buff)).FirstOrDefault();// b.GetSpellDamage(i, buff)).Sum();

            return dmg > i.Health;
        }
    }
}
