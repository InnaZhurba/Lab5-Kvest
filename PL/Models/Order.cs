﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int SertificateId { get; set; }
        public int NumberOfUsers { get; set; }
    }
}
