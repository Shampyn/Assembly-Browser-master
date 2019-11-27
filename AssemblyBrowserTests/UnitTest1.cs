using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssemblyBrowserLibrary;
using System.Collections.Generic;

namespace AssemblyBrowserTests
{
    [TestClass]
    public class AssemblyBrowserUnitTest
    {
        private AssemblyBrowserModel assemblyBrowser;
        private List<Namespace> namespaces { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            assemblyBrowser = new AssemblyBrowserModel();
            namespaces = assemblyBrowser.LoadAssembly("C:\\Users\\ваня\\Desktop\\БГУИР\\Assembly-Browser-master\\ClassLibraryForTest\\ClassLibraryForTest\\bin\\Debug\\ClassLibraryForTest.dll");
        }

        [TestMethod]
        public void DLLLoad_ShouldLoadDLL()
        {
            Assert.IsNotNull(namespaces);
        }

        [TestMethod]
        public void NamespaceParse_ShouldReturnOneNamespace()
        {
            Assert.AreEqual(1, namespaces.Count);
        }

        public void ClassParse_ShouldReturnTwoClasses()
        {
            Assert.AreEqual(2, namespaces[0].Classes.Count);
        }

        [TestMethod]
        public void ClassParse_ShouldReturnpublicclassClass1()
        {
            Assert.AreEqual("public class Class1", namespaces[0].Classes[0].Name);
        }

        [TestMethod]
        public void ClassParse_ShouldReturnTwoConstructors()
        {
            Assert.AreEqual(2, namespaces[0].Classes[0].Constructors.Count);
        }

        [TestMethod]
        public void ClassParse_ShouldReturnFieldPublicInt32a()
        {
            Assert.AreEqual("public Int32 a", namespaces[0].Classes[0].Fields[0].Signature);
        }

        [TestMethod]
        public void ClassParse_ShouldReturnOneProperty()
        {
            Assert.AreEqual(1, namespaces[0].Classes[0].Properties.Count);
        }
       
        [TestMethod]
        public void ClassParse_ShouldReturnOneMethod()
        {
            Assert.AreEqual(1, namespaces[0].Classes[0].Methods.Count);
        }
    }
}

