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
    
    public partial class MSpeer_conflictdetectionconfigresponse
    {
        public int request_id { get; set; }
        public string peer_node { get; set; }
        public string peer_db { get; set; }
        public Nullable<int> peer_version { get; set; }
        public Nullable<int> peer_db_version { get; set; }
        public Nullable<bool> is_peer { get; set; }
        public Nullable<bool> conflictdetection_enabled { get; set; }
        public Nullable<int> originator_id { get; set; }
        public Nullable<int> peer_conflict_retention { get; set; }
        public Nullable<bool> peer_continue_onconflict { get; set; }
        public string peer_subscriptions { get; set; }
        public string progress_phase { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
    }
}
