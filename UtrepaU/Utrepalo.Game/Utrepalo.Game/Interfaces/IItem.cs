﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utrepalo.Game.Interfaces
{
    public interface IItem
    {
        int AttackEffect { get; }
        int DefenceEffect { get; }
        int HealingEffect { get; }
    }
}
