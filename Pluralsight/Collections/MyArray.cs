using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class MyArray
    {
        private int[] Data { get; }

        public MyArray(IEnumerable<int> values)
        {
            Data = values.ToArray();
        }

        public int Maximum()
        {
            // Assume length is > 0
            int max = this.Data[0];
            for (int i = 1; i < this.Data.Length; i++)
            {
                if (this.Data[i] > max)
                {
                    max = this.Data[i];
                }
            }
            return max;
        }
    }
}
