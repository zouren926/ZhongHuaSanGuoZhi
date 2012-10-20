﻿namespace GameObjects
{
    using System;

    public class TroopDamage
    {
        public bool AntiArrowAttack;
        public bool AntiAttack;
        public bool AntiCounterAttack;
        public bool BeCountered;
        public Person ChallengeDestinationPerson;
        public bool ChallengeHappened;
        public bool ChallengeResult;
        public Person ChallengeSourcePerson;
        public bool Chaos;
        public int CombativityDown;
        public bool Counter;
        public int CounterCombativityDown;
        public int CounterDamage;
        public int CounterInjury;
        public bool Critical;
        public int Damage;
        public int DestinationMoraleChange;
        public Troop DestinationTroop;
        public int FireDamage;
        public int Injury;
        public bool OnFire;
        public int SourceMoraleChange;
        public int SourceOffence;
        public Troop SourceTroop;
        public TroopList SurroudingList = new TroopList();
        public bool Surround;
        public bool Waylay;
    }
}
