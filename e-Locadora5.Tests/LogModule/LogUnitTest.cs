
using e_Locadora5.Infra.Log;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace e_Locadora5.Tests.LogModule
{
    [TestClass]
    public class LogUnitTest
    {
        GeradorDeLog geradorDeLog;
        public LogUnitTest()
        {
            geradorDeLog = new GeradorDeLog();
        }

        [TestMethod]
        public void EnviandoLogParaSeq()
        {
            //arrange
            string mensagem = "Tela abc aberta";
            //act
            var registrou = geradorDeLog.RegistrarLog(mensagem, NiveisSerilog.Information);
            //assert
            registrou.Should().Be(true);
        }

        [TestMethod]
        public void GravandoLogEmTxt()
        {          
            //arrange
            string mensagem = "Tela abc aberta salvando em txt";
            //act
            var registrou = geradorDeLog.RegistrarLog(mensagem, NiveisSerilog.Information);
            //assert
            registrou.Should().Be(true);
        }
    }
}
