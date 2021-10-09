using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileDataServices.Adapters.FileDetails.Models;
using FileData.Implementer;

namespace FileDataTests
{
    [TestClass]
    public class Test_FileDetailsImplementer
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
            bool result = new FileDetailsImplementer(_fileDetails.Object).IsValidArguments(args);

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
            bool result = new FileDetailsImplementer(_fileDetails.Object).IsValidArguments(args);

            //Assert - Result 
            Assert.IsFalse(result);            
        }

        [TestMethod]
        public void Test_ValidateArguments_BlankFirstArgument()
        {
            string[] args = new string[] { "", "abc" };

            // Moq
            _fileDetails.Setup(x => x.GetVersion(It.IsAny<string>())).Returns("someVersion");

            //act
            bool result = new FileDetailsImplementer(_fileDetails.Object).IsValidArguments(args);

            //Assert - Result 
            Assert.IsFalse(result);            
        }                

        [TestMethod]
        public void Test_ValidateArguments_ArgumentNotSupported()
        {
            string[] args = new string[] { "-k", "C:/test.txt" };

            // Moq
            _fileDetails.Setup(x => x.GetVersion(It.IsAny<string>())).Returns("someVersion");

            //act
            new FileDetailsImplementer(_fileDetails.Object).GetFileDetails(args);

            //Assert - GetVersion method should NOT get callaed
            _fileDetails.Verify(s => s.GetVersion("C:/test.txt"), Times.Never());

            //Assert - GetSize method should NOT get callaed
            _fileDetails.Verify(s => s.GetSize("C:/test.txt"), Times.Never());
        }

        [TestMethod]
        public void Test_ValidateArguments_Version()
        {
            string[] args = new string[] { "-v", "C:/test.txt" };

            // Moq
            _fileDetails.Setup(x => x.GetVersion(It.IsAny<string>())).Returns("someVersion");

            //act
            new FileDetailsImplementer(_fileDetails.Object).GetFileDetails(args);

            //Assert - GetVersion method should get callaed
            _fileDetails.Verify(s => s.GetVersion("C:/test.txt"), Times.Once());
        }

        [TestMethod]
        public void Test_ValidateArguments_Size()
        {
            string[] args = new string[] { "-s", "C:/test.txt" };

            // Moq
            _fileDetails.Setup(x => x.GetSize(It.IsAny<string>())).Returns(11);

            //act
            new FileDetailsImplementer(_fileDetails.Object).GetFileDetails(args);

            //Assert - GetSize method should get callaed
            _fileDetails.Verify(s => s.GetSize("C:/test.txt"), Times.Once());
        }        
    }
}
