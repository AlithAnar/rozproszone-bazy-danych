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
    
    public partial class conflict_dbo_Users
    {
        public Nullable<int> C___originator_id { get; set; }
        public Nullable<int> C___origin_datasource { get; set; }
        public string C___tranid { get; set; }
        public Nullable<int> C___conflict_type { get; set; }
        public Nullable<bool> C___is_winner { get; set; }
        public byte[] C___pre_version { get; set; }
        public Nullable<int> C___reason_code { get; set; }
        public string C___reason_text { get; set; }
        public byte[] C___update_bitmap { get; set; }
        public System.DateTime C___inserted_date { get; set; }
        public byte[] C___row_id { get; set; }
        public byte[] C___change_id { get; set; }
        public Nullable<int> Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string SureName { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public Nullable<double> Last_energy_usage { get; set; }
        public Nullable<double> Pesel { get; set; }
        public Nullable<int> City_Id { get; set; }
        public string PasswordSalt { get; set; }
    }
}
