//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace rozproszone_bazy_danych.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Settlement
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public System.DateTime Current_date { get; set; }
        public double energy_usage { get; set; }
        public System.DateTime settlement_date { get; set; }
    
        public virtual Users Users { get; set; }
    }
}
