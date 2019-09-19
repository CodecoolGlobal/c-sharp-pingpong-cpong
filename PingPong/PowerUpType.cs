using System.Collections.Generic;

namespace PingPong
{

    public class PowerUpType
    {

        public enum Type
        {
            Fast,
            Slow,
            Wide,
            Narrow
        }

        private static readonly List<Type> values = new List<Type>()
        {
            Type.Fast,
            Type.Slow,
            Type.Wide,
            Type.Narrow
        };
        private static readonly int size = values.Count;

        public static Type RandomType()
        {
            return values[Util.GetRandomNumber(0, size - 1)];
        }
    }
}