﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Kvest
{
    public class UsersValue
    {
        public int ID { get; set; }
        public int min { get; set; }
        public int max { get; set; }

        public virtual KvestRoom KvestRoom { get; set; }
    }
}
