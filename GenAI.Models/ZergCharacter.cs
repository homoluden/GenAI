using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenAI.Core.Enums;
using GenAI.Core.Interfaces;

namespace GenAI.Models
{
    public class ZergCharacter : BaseCharacter, IAmAlive, IHavePosition
    {
        public ZergCharacter(Dictionary<GeneKey, uint> genes) : base(genes)
        {
            X = Y = Angle = 0.0;
        }
    }
}
