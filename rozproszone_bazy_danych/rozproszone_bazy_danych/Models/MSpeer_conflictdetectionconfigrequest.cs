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
    
    public partial class MSpeer_conflictdetectionconfigrequest
    {
        public int id { get; set; }
        public string publication { get; set; }
        public System.DateTime sent_date { get; set; }
        public int timeout { get; set; }
        public System.DateTime modified_date { get; set; }
        public string progress_phase { get; set; }
        public bool phase_timed_out { get; set; }
    }
}
