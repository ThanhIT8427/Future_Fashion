﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Future_Fashion_API.attributes;
using System;
using System.Collections.Generic;

namespace Future_Fashion_API.Models
{
    public partial class TblProductSizeQuantity
    {
        [PrimaryKey]
        public int PrdSizeQuantId { get; set; }
        public int? Pid { get; set; }
        public int? SizeId { get; set; }
        public int? Quantity { get; set; }

        
    }
}