using Moq;
using FileDataServices.Adapters.FileDetails.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileDataTests
{
    [TestClass]
    public class FileDetailsImplementer
    {
        private Mock<IFileDetails> _fileDetails;

        [TestInitialize]
        public void Setup()
        {
            _fileDetails = new Mock<IFileDetails>();;
        }

        [TestMethod]
        public void Test_GetVersion_InvalidArguments_NoArgumentSupplied()
        {
            string[] args = new string[] {};

            // Moq
            _fileDetails.Setup(x => x.GetVersion(It.IsAny<string>())).Returns("someVersion");

            //act
            string result = new FileDetailsImplementer_Deprecated(_fileDetails.Object).GetVersion(args);

            //Assert - Result 
            Assert.AreEqual("Invalid arguments: Minimum 2 parameters required", result);

            //Assert - Version method should NOT get callaed
            _fileDetails.Verify(s => s.GetVersion("someInput"), Times.Never());
        }

        [TestMethod]
        public void Test_GetVersion_InvalidArguments_LessArgumentSupplied()
        {
            string[] args = new string[] {"-v"};

            // Moq
            _fileDetails.Setup(x => x.GetVersion(It.IsAny<string>())).Returns("someVersion");

            //act
            string result = new FileDetailsImplementer_Deprecated(_fileDetails.Object).GetVersion(args);

            //Assert - Result 
            Assert.AreEqual("Invalid arguments: Minimum 2 parameters required", result);

            //Assert - Version method should NOT get callaed
            _fileDetails.Verify(s => s.GetVersion("someInput"), Times.Never());
        }

        [TestMethod]
        public void Test_GetVersion_InvalidArguments_InvalidFirstArgument()
        {
            string[] args = new string[] { "-s", "abc" };

            // Moq
            _fileDetails.Setup(x => x.GetVersion(It.IsAny<string>())).Returns("someVersion");

            //act
            string result = new FileDetailsImplementer_Deprecated(_fileDetails.Object).GetVersion(args);

            //Assert - Result 
            Assert.AreEqual("Invalid arguments: Please ensure first parameter is '-v'", result);

            //Assert - Version method should NOT get callaed
            _fileDetails.Verify(s => s.GetVersion("someInput"), Times.Never());
        }

        [TestMethod]
        public void Test_GetVersion_InvalidArguments_InvalidSecondArgument()
        {
            string[] args = new string[] { "-v", "abc" };

            // Moq
            _fileDetails.Setup(x => x.GetVersion(It.IsAny<string>())).Returns("someVersion");

            //act
            string result = new FileDetailsImplementer_Deprecated().GetVersion(args);

            //Assert - Result 
            Assert.AreEqual("Invalid arguments: File not found, please provide a valid file", result);

            //Assert - Version method should NOT get callaed
            _fileDetails.Verify(s => s.GetVersion("someInput"), Times.Never());
        }

        [TestMethod]
        public void Test_GetVersion_Success()
        {
            string[] args = new string[] { "-v", "C:/test.txt" };

            // Moq
            _fileDetails.Setup(x => x.GetVersion(It.IsAny<string>())).Returns("someVersion");

            //act
            string result = new FileDetailsImplementer_Deprecated(_fileDetails.Object).GetVersion(args);

            //Assert - Result 
            Assert.AreEqual("someVersion", result);

            //Assert - Version method should NOT get callaed
            _fileDetails.Verify(s => s.GetVersion("C:/test.txt"), Times.Once());
        }
    }
}
