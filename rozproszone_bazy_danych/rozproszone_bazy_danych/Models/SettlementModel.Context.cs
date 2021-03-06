﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class SettlementEntities : DbContext
    {
        public SettlementEntities()
            : base("name=SettlementEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public DbSet<City> City { get; set; }
        public DbSet<conflict_dbo_City> conflict_dbo_City { get; set; }
        public DbSet<conflict_dbo_Province> conflict_dbo_Province { get; set; }
        public DbSet<conflict_dbo_Settlement> conflict_dbo_Settlement { get; set; }
        public DbSet<conflict_dbo_Users> conflict_dbo_Users { get; set; }
        public DbSet<MSpeer_conflictdetectionconfigrequest> MSpeer_conflictdetectionconfigrequest { get; set; }
        public DbSet<MSpeer_conflictdetectionconfigresponse> MSpeer_conflictdetectionconfigresponse { get; set; }
        public DbSet<MSpeer_lsns> MSpeer_lsns { get; set; }
        public DbSet<MSpeer_originatorid_history> MSpeer_originatorid_history { get; set; }
        public DbSet<MSpeer_request> MSpeer_request { get; set; }
        public DbSet<MSpeer_response> MSpeer_response { get; set; }
        public DbSet<MSpeer_topologyrequest> MSpeer_topologyrequest { get; set; }
        public DbSet<MSpeer_topologyresponse> MSpeer_topologyresponse { get; set; }
        public DbSet<MSpub_identity_range> MSpub_identity_range { get; set; }
        public DbSet<MSreplication_objects> MSreplication_objects { get; set; }
        public DbSet<MSreplication_subscriptions> MSreplication_subscriptions { get; set; }
        public DbSet<MSsubscription_agents> MSsubscription_agents { get; set; }
        public DbSet<MSsubscription_articles> MSsubscription_articles { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<Settlement> Settlement { get; set; }
        public DbSet<sysarticlecolumns> sysarticlecolumns { get; set; }
        public DbSet<sysarticles> sysarticles { get; set; }
        public DbSet<sysarticleupdates> sysarticleupdates { get; set; }
        public DbSet<syspublications> syspublications { get; set; }
        public DbSet<sysreplservers> sysreplservers { get; set; }
        public DbSet<sysschemaarticles> sysschemaarticles { get; set; }
        public DbSet<syssubscriptions> syssubscriptions { get; set; }
        public DbSet<systranschemas> systranschemas { get; set; }
        public DbSet<Users> Users { get; set; }
    }

    public partial class SettlementS1Entities : DbContext
    {
        public SettlementS1Entities()
            : base("name=SettlementS1Entities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public DbSet<City> City { get; set; }
        public DbSet<conflict_dbo_City> conflict_dbo_City { get; set; }
        public DbSet<conflict_dbo_Province> conflict_dbo_Province { get; set; }
        public DbSet<conflict_dbo_Settlement> conflict_dbo_Settlement { get; set; }
        public DbSet<conflict_dbo_Users> conflict_dbo_Users { get; set; }
        public DbSet<MSpeer_conflictdetectionconfigrequest> MSpeer_conflictdetectionconfigrequest { get; set; }
        public DbSet<MSpeer_conflictdetectionconfigresponse> MSpeer_conflictdetectionconfigresponse { get; set; }
        public DbSet<MSpeer_lsns> MSpeer_lsns { get; set; }
        public DbSet<MSpeer_originatorid_history> MSpeer_originatorid_history { get; set; }
        public DbSet<MSpeer_request> MSpeer_request { get; set; }
        public DbSet<MSpeer_response> MSpeer_response { get; set; }
        public DbSet<MSpeer_topologyrequest> MSpeer_topologyrequest { get; set; }
        public DbSet<MSpeer_topologyresponse> MSpeer_topologyresponse { get; set; }
        public DbSet<MSpub_identity_range> MSpub_identity_range { get; set; }
        public DbSet<MSreplication_objects> MSreplication_objects { get; set; }
        public DbSet<MSreplication_subscriptions> MSreplication_subscriptions { get; set; }
        public DbSet<MSsubscription_agents> MSsubscription_agents { get; set; }
        public DbSet<MSsubscription_articles> MSsubscription_articles { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<Settlement> Settlement { get; set; }
        public DbSet<sysarticlecolumns> sysarticlecolumns { get; set; }
        public DbSet<sysarticles> sysarticles { get; set; }
        public DbSet<sysarticleupdates> sysarticleupdates { get; set; }
        public DbSet<syspublications> syspublications { get; set; }
        public DbSet<sysreplservers> sysreplservers { get; set; }
        public DbSet<sysschemaarticles> sysschemaarticles { get; set; }
        public DbSet<syssubscriptions> syssubscriptions { get; set; }
        public DbSet<systranschemas> systranschemas { get; set; }
        public DbSet<Users> Users { get; set; }
    }

    public partial class SettlementSsEntities : DbContext
    {
        public SettlementSsEntities()
            : base("name=SettlementSsEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public DbSet<City> City { get; set; }
        public DbSet<conflict_dbo_City> conflict_dbo_City { get; set; }
        public DbSet<conflict_dbo_Province> conflict_dbo_Province { get; set; }
        public DbSet<conflict_dbo_Settlement> conflict_dbo_Settlement { get; set; }
        public DbSet<conflict_dbo_Users> conflict_dbo_Users { get; set; }
        public DbSet<MSpeer_conflictdetectionconfigrequest> MSpeer_conflictdetectionconfigrequest { get; set; }
        public DbSet<MSpeer_conflictdetectionconfigresponse> MSpeer_conflictdetectionconfigresponse { get; set; }
        public DbSet<MSpeer_lsns> MSpeer_lsns { get; set; }
        public DbSet<MSpeer_originatorid_history> MSpeer_originatorid_history { get; set; }
        public DbSet<MSpeer_request> MSpeer_request { get; set; }
        public DbSet<MSpeer_response> MSpeer_response { get; set; }
        public DbSet<MSpeer_topologyrequest> MSpeer_topologyrequest { get; set; }
        public DbSet<MSpeer_topologyresponse> MSpeer_topologyresponse { get; set; }
        public DbSet<MSpub_identity_range> MSpub_identity_range { get; set; }
        public DbSet<MSreplication_objects> MSreplication_objects { get; set; }
        public DbSet<MSreplication_subscriptions> MSreplication_subscriptions { get; set; }
        public DbSet<MSsubscription_agents> MSsubscription_agents { get; set; }
        public DbSet<MSsubscription_articles> MSsubscription_articles { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<Settlement> Settlement { get; set; }
        public DbSet<sysarticlecolumns> sysarticlecolumns { get; set; }
        public DbSet<sysarticles> sysarticles { get; set; }
        public DbSet<sysarticleupdates> sysarticleupdates { get; set; }
        public DbSet<syspublications> syspublications { get; set; }
        public DbSet<sysreplservers> sysreplservers { get; set; }
        public DbSet<sysschemaarticles> sysschemaarticles { get; set; }
        public DbSet<syssubscriptions> syssubscriptions { get; set; }
        public DbSet<systranschemas> systranschemas { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
