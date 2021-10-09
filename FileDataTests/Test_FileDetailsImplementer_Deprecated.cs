using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileDataServices.Adapters.FileDetails.Models;
using FileData.Implementer;

namespace FileDataTests
{
    [TestClass]
    public class Test_FileDetailsImplementer_Deprecated
    {
        private Mock<IFileDetails> _fileDetails;

        [TestInitialize]
        public void Setup()
        {
            _fileDetails = new Mock<IFileDetails>();
        }

        [TestMethod]
        public void Test_ValidateArguments_NoArgumentSupplied()
        {
            string[] args = new string[] {};

            // Moq
            _fileDetails.Setup(x => x.GetVersion(It.IsAny<string>())).Returns("someVersion");            

            //act
            bool result = new FileDetailsImplementer_Deprecated(_fileDetails.Object).IsValidArguments(args);

            //Assert - Result 
            Assert.IsFalse(result);            
        }

        [TestMethod]
        public void Test_ValidateArguments_LessArgumentSupplied()
        {
            string[] args = new string[] {"-v"};

            // Moq
            _fileDetails.Setup(x => x.GetVersion(It.IsAny<string>())).Returns("someVersion");

            //act
            bool result = new FileDetailsImplementer_Deprecated(_fileDetails.Object).IsValidArguments(args);

            //Assert - Result 
            Assert.IsFalse(result);            
        }

        [TestMethod]
        public void Test_ValidateArguments_InvalidFirstArgument()
        {
            string[] args = new string[] { "-s", "abc" };

            // Moq
            _fileDetails.Setup(x => x.GetVersion(It.IsAny<string>())).Returns("someVersion");

            //act
            bool result = new FileDetailsImplementer_Deprecated(_fileDetails.Object).IsValidArguments(args);

            //Assert - Result 
            Assert.IsFalse(result);            
        }        

        [TestMethod]
        public void Test_ValidateArguments_Valid()
        {
            string[] args = new string[] { "-v", "C:/test.txt" };

            // Moq
            _fileDetails.Setup(x => x.GetVersion(It.IsAny<string>())).Returns("someVersion");

            //act
            bool result = new FileDetailsImplementer_Deprecated(_fileDetails.Object).IsValidArguments(args);

            //Assert - Result 
            Assert.IsTrue(result);            
        }

        [TestMethod]
        public void Test_GetVersion_Valid()
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
