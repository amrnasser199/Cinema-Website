﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly.Models;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> Membershiptypes { get; set; }
        public Customer customer { get; set; }

    }
}