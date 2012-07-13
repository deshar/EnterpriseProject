using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace TestPlan1
{
    /// <summary>
    /// The test checks every field on the database to ensure the validation rules have not been bypassed
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext context;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return context;
            }
            set
            {
                context = value;
            }
        }

        Regex illcharpattern = new Regex("^[^\u003c\u003e\u0026\u0022\u0027\u002f]{1,50}$");
        Regex datepattern = new Regex("^((((0[1-9])|([1-2][0-9])|(3[0-1]))|([1-9]))\x2d(((0[1-9])|(1[0-2]))|([1-9]))\x2d(([0-9]{2})|(((19)|([2]([0]{1})))([0-9]{2}))))$");
        Regex addresspattern = new Regex("^[a-zA-Z0-9-\u002e\u0020]{1,50}$");
        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [DataSource("System.Data.SqlServerCE.4.0", 
            "Data Source=D:\\EnterpriseRepo\\CS - WIP0207-mail-unittV7\\Plan1\\Plan1\\App_Data\\DHPerm.sdf",
             "Permissions", DataAccessMethod.Sequential), DeploymentItem("Permtest\\DHPerm.sdf"), TestMethod()]

        public void T8_IllegalCharacterTest()
        {
            string permTypeActualString = System.Convert.ToString(context.DataRow["permType"]);
            StringAssert.Matches(permTypeActualString, illcharpattern, "permType: " + permTypeActualString + "contains invalid characters");
            string postalAddrActualString = System.Convert.ToString(context.DataRow["postalAddr"]);
            StringAssert.Matches(postalAddrActualString, addresspattern, "postalAddr: " + postalAddrActualString + "contains invalid characters");
            string appNameActualString = System.Convert.ToString(context.DataRow["appName"]);
            StringAssert.Matches(appNameActualString, illcharpattern, "appName: " + appNameActualString + "contains invalid characters");
            string appDateActualString = System.Convert.ToString(context.DataRow["appDate"]);
            StringAssert.Matches(appDateActualString, datepattern, "appDate: " + appDateActualString + "contains invalid characters");
            string archNameActualString = System.Convert.ToString(context.DataRow["archName"]);
            StringAssert.Matches(archNameActualString, illcharpattern, "archName: " + archNameActualString + "contains invalid characters");
            string devDescActualString = System.Convert.ToString(context.DataRow["devDesc"]);
            StringAssert.Matches(devDescActualString, illcharpattern, "devDesc: " + devDescActualString + "contains invalid characters");
            string ownerNameActualString = System.Convert.ToString(context.DataRow["ownerName"]);
            StringAssert.Matches(ownerNameActualString, illcharpattern, "ownerName: " + ownerNameActualString + "contains invalid characters");
            string retBldAddrActualString = System.Convert.ToString(context.DataRow["retBldAddr"]);
            StringAssert.Matches(retBldAddrActualString, addresspattern, "retBldAddr: " + retBldAddrActualString + "contains invalid characters");
            string addrDrawerActualString = System.Convert.ToString(context.DataRow["addrDrawer"]);
            StringAssert.Matches(addrDrawerActualString, addresspattern, "addrDrawer: " + addrDrawerActualString + "contains invalid characters");
        }
    }
}
