﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Future_Fashion_API.attributes;
using System;
using System.Collections.Generic;

namespace Future_Fashion_API.entities
{
    public partial class TblOrderProducts
    {
        [PrimaryKey]
        public int OrderProId { get; set; }
        public string OrderId { get; set; }
        public int? UserId { get; set; }
        public int? Pid { get; set; }
        public string Products { get; set; }
        public int? Quantity { get; set; }
        public DateTime? OrderDate { get; set; }
        public string Status { get; set; }

       
    }
}