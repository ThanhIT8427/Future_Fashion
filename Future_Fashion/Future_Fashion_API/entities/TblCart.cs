﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Future_Fashion_API.attributes;
using System;
using System.Collections.Generic;

namespace Future_Fashion_API.entities
{
    public partial class TblCart
    {
        [PrimaryKey]
        public int CartId { get; set; }
        public int? Uid { get; set; }
        public int? Pid { get; set; }
        public string Pname { get; set; }
        public decimal? Pprice { get; set; }
        public decimal? PselPrice { get; set; }
        public decimal? SubPamount { get; set; }
        public decimal? SubSamount { get; set; }
        public int? Qty { get; set; }
    }
}