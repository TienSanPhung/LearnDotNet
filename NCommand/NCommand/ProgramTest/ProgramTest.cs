using JetBrains.Annotations;
using NFind;

namespace ProgramTest;

[TestClass]
[TestSubject(typeof(Program))]
public class ProgramTest
{
    [TestMethod]
    public void BuildOptionsTest()
    {
        string s = Guid.NewGuid().ToString();
        string p = Guid.NewGuid().ToString();
        string[] args = ["/v", "/c", "/n", "/i", "/?","/off",s,p];
        var options = Program.BuildOptions(args);
        Assert.IsNotNull(options);
        Assert.IsTrue(options.FindDontConstain);
        Assert.IsTrue(options.CountMode);
        Assert.IsFalse(options.IsCaseSensitive);
        Assert.IsTrue(options.ShowLineNumeber);
        Assert.IsTrue(options.HelpMode);
        Assert.IsFalse(options.SkipOfflineFile);
        Assert.AreEqual(s, options.StringToFind);
        Assert.AreEqual(p, options.Path);
    }
}