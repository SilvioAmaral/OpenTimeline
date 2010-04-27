using System.Reflection;
using FluentNHibernate.Testing;
using OpenTimeline.Core.Domain;
using OpenTimeline.Core.NHibernate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using NHibernate;

namespace OpenTimeline.Core.Tests
{
    /// <summary>
    ///This is a test class for SessionFactoryConfigTest and is intended
    ///to contain all SessionFactoryConfigTest Unit Tests
    ///</summary>
    [TestClass()]
    public class NHibernateTest : InMemoryDatabaseTest
    {


        private TestContext testContextInstance;

        public NHibernateTest() : base(typeof(Timeline).Assembly)
        {
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for CreateSessionFactory
        ///</summary>
        [TestMethod()]
        public void CreateSessionFactoryTest()
        {
            var sessionFactory = SessionFactoryConfig.CreateSessionFactory();
            Assert.IsNotNull(sessionFactory);
        }

        [TestMethod]
        public void Can_Correctly_Map_Employee()
        {
            new PersistenceSpecification<Timeline>(_session)
                .CheckProperty(x => x.Id, new Guid("16DADAB1-C4F1-410D-8D0C-2752DEBCFEA1"))
                .CheckProperty(x => x.Name, "Canada")
                .CheckProperty(x => x.Description, "New Timeline")
                .VerifyTheMappings();
        }
    }
}
