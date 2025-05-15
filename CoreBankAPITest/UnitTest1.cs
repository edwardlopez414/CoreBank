using CoreBankAPI.CoreDbContext;
using CoreBankAPI.Logic.Interfaces;
using CoreBankAPI.Logic.Validator;
using CoreBankAPI.Logic;
using CoreBankAPI.Models;
using Moq;
using System.Security.Principal;
using CoreBankAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace CoreBankAPITest
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class TransactionManagerTests
        {
            private Mock<ITransactionRepository> _mockTransactionRepository;
            private Mock<IAccountRepository> _mockAccountRepository;
            private CoreDb _dbContext;
            private TransactionManager _transactionManager;

            [TestInitialize]
            public void Setup()
            {
                // Configuración del DbContext en memoria
                var options = new DbContextOptionsBuilder<CoreDb>()
                                .UseInMemoryDatabase(databaseName: "TestDatabase")
                                .Options;

                _dbContext = new CoreDb(options); // Crear un DbContext en memoria

                // Crear mocks para los repositorios
                _mockTransactionRepository = new Mock<ITransactionRepository>();
                _mockAccountRepository = new Mock<IAccountRepository>();

                // Crear la instancia de TransactionManager
                _transactionManager = new TransactionManager(
                    _dbContext,
                    new ValidateRequest(),
                    _mockTransactionRepository.Object,
                    _mockAccountRepository.Object
                );
            }

            [TestMethod]
            public void ValidateDeposit()
            {
                
                var transactionDto = new TransactionDto
                {
                    Identifier = "12345",
                    Amount = 100,
                    Description = "Deposit test"
                };

                // Agregar una cuenta de prueba en la base de datos en memoria
                var mockAccount = new AccoutDta
                {
                    Id = 1,
                    Balance = 500,
                    identifier = "12345"
                };

                _dbContext.AccountDta.Add(mockAccount);
                _dbContext.SaveChanges();

                _mockAccountRepository.Setup(repo => repo.GetByIdentifier(It.IsAny<string>())).Returns(mockAccount);
                _mockAccountRepository.Setup(repo => repo.add(It.IsAny<AccoutDta>())).Verifiable();

                // Act
                var (isError, error, response) = _transactionManager.deposit(transactionDto);

                // Assert
                Assert.IsFalse(isError);
                Assert.AreEqual("completed", response.Status);
                Assert.AreEqual(600, response.BalanceAccount);  // El saldo debería ser actualizado
                _mockAccountRepository.Verify(repo => repo.add(It.IsAny<AccoutDta>()), Times.Once);
            }
        }
    }
}