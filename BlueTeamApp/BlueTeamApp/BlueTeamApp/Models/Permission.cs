using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BlueTeamApp.Models
{
    public class Permission
    {
        public int permType                   { get; set; }
        public string postalAddr              { get; set; }
        public string appName                 { get; set; }
        public string archName                { get; set; }
        public string devDesc                 { get; set; }
        public string ownerName               { get; set; }
        public string retBldAddr              { get; set; }
        public int retFloorAream2             { get; set; }
        public string retUseToDate            { get; set; }
        public int retUseToDateAream2         { get; set; }
        public string retUseProposed          { get; set; }
        public int retUseProposedAream2       { get; set; }
        public string demolitionType          { get; set; }
        public int devTotalAream2             { get; set; }
        public int devFloorRetAream2          { get; set; }
        public int devFloorAreaNewm2          { get; set; }
        public int devTotalFloorAream2        { get; set; }
        public int devFloorAreaDemm2          { get; set; }
        public int devFloorAreaNonResm2       { get; set; }
        public decimal devPlotRatio           { get; set; }
        public decimal devSiteCoverage        { get; set; }
        public int crecheNoChild              { get; set; }
        public int crecheFloorAreram2         { get; set; }
        public int feePayableClass            { get; set; }
        public string feePayableCalc          { get; set; }
        public decimal feePayableAmt          { get; set; }
        public string noticePaper             { get; set; }
        public DateTime noticeDate            { get; set; }
        public DateTime siteNoticeDate        { get; set; }
        public string protStructure           { get; set; }
        public string archConsArea            { get; set; }
        public string prevPermissions         { get; set; }
        public string currentAppeals          { get; set; }
        public string archaelogicalInt        { get; set; }
        public string eisReqd                 { get; set; }
        public string majAccRegs              { get; set; }
        public string wasteLicReqd            { get; set; }
        public string statNoticesApply        { get; set; }
        public string prePlanConsult          { get; set; }
        public DateTime     prePlanDate       { get; set; }
        public string respDCC                 { get; set; }
        public string socHousingExempt        { get; set; }
        public string waterSupplyType         { get; set; }
        public string drainageDrawingLink     { get; set; }
        public string addrDrawer              { get; set; }
        public string addrNotification        { get; set; }
        public string addrApplicant           { get; set; }
        public string appPhone                { get; set; }
        public string appEmail                { get; set; }

    }

    public class PermissionDBContext : DbContext
    {
        public DbSet<Permission> Permissions { get; set; }
    }
}