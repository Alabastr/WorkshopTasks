using System;
using System.Collections.Generic;

namespace AngryBirds.Logic
{
    internal interface IGameModel
    {
        event EventHandler Changed;
        List<Bullet> Bullets { get; set; }
        public List<Ernie> Ernies { get; set; }
    }
}