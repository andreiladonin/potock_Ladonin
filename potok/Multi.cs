using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace potok
{
    public class Multi
    {
        public bool cancelled = false;

        public void Cancel()
        {
            cancelled = false;
        }

        public void Work()
        {
            for (int i = 0; i <= 100; i++)
            {
                if (cancelled)
                    break;
                Thread.Sleep(50);

                ProcessChanged(i);
            }

            WorkCompletd(cancelled);
        }


        public event Action<int> ProcessChanged;

        public event Action<bool> WorkCompletd;
    }
}
