using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiveLogger.Views
{

    public class LogPageMenuItem
    {
       
        public LogPageMenuItem()
        {
            TargetType = typeof(DiveLogPage);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}