using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDBApp
{
    class PostData
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Date
        {
            get; set;
        }
    }
}
