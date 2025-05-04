using ASample;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASample.Tests;

[TestClass]
[TestSubject(typeof(Program))]
public class ProgramTest
{
    [TestMethod]
    public void DbConnectionTest()
    {
        Program.DbConnection();
    }

}