using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{

    public interface IRoll
    {
        bool IsNull { get; }
        int Pins { get; }
    }

    public class Roll : IRoll
    {
        public Roll(int pins)
        {
            Pins = pins;
        }

        public bool IsNull { get { return false; } }
        public int Pins { get; private set; }
    }

    public class NullRoll : IRoll
    {
        public int Pins { get { return 0; } }
        public bool IsNull { get { return true; } }
    }


    public interface IFrame
    {
        bool IsCompelete();
        int PinCount();
        void AddRoll(Roll roll);
        IRoll FirstRoll();
        int CalculateScore(IEnumerable<IRoll> futureRolls);
        IEnumerable<IRoll> Rolls { get; }
    }

    public class NullFrame : IFrame
    {

        public bool IsCompelete()
        {
            return true;
        }

        public int PinCount()
        {
            return 0;
        }

        public void AddRoll(Roll roll)
        {
        }

        public int CalculateScore(IEnumerable<IRoll> futureRolls)
        {
            return 0;
        }

        public IRoll FirstRoll()
        {
            return new NullRoll();
        }


        public IEnumerable<IRoll> Rolls
        {
            get { return Enumerable.Empty<IRoll>(); }
        }
    }

    public class OpenFrame : IFrame
    {
        protected List<IRoll> _rolls = new List<IRoll>();

        public virtual bool IsCompelete()
        {
            if (_rolls.Count == 2) return true;
            return PinCount() == 10; // strike condition
        }

        public int PinCount()
        {
            return _rolls.Sum(roll => roll.Pins);
        }

        public virtual void AddRoll(Roll roll)
        {
            _rolls.Add(roll);
        }

        public virtual int CalculateScore(IEnumerable<IRoll> futureRolls)
        {
            var oneRollAgo = futureRolls.ElementAtOrDefault(0) ?? new NullRoll();
            var twoRollAgo = futureRolls.ElementAtOrDefault(1) ?? new NullRoll();
            
            if (PinCount() == 10 && _rolls.Count == 1)
            {
                return PinCount() + oneRollAgo.Pins + twoRollAgo.Pins;
            }

            if (PinCount() == 10 && _rolls.Count == 2)
                return PinCount() + oneRollAgo.Pins;
            
            return PinCount();
        }


        public IRoll FirstRoll()
        {
            return _rolls.FirstOrDefault() ?? new NullRoll();
        }


        public IEnumerable<IRoll> Rolls
        {
            get { return _rolls; }
        }
    }

    public class TenthFrame : OpenFrame
    {
        public override bool IsCompelete()
        {
            if (PinCount() < 10 && _rolls.Count == 2)
            {
                return true;
            }
            return _rolls.Count == 3;
        }

        public override int CalculateScore(IEnumerable<IRoll> futureRolls)
        {
            return PinCount();
        }
        
    }
}
