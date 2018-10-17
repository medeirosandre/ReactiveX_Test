using NFCeX;
using System;
using System.Reactive.Linq;

namespace ReactiveX_Test.tecnospeed
{
    public class NFCe400
    {
        private spdNFCeX spdNFCe;

        public NFCe400()
        {
            this.spdNFCe = new spdNFCeX();
        }

        private void initNFCe()
        {
            string path = "D:\\workspace\\ObjetoRelacional\\_tests\\ReactiveX_Test\\ReactiveX_Test\\bin\\Debug";
            string certificado = "CN=CASA DE FESTA DI MARIA LTDA - ME:29081992000100, OU=Certificado PJ A1, OU=AC SOLUTI Multipla, OU=AC SOLUTI, OU=Autoridade Certificadora Raiz Brasileira v2, O=ICP-Brasil, C=BR";

            spdNFCe.Ambiente = AmbienteKindNFCe.akHomologacao;
            spdNFCe.TokenNFCe = "D2A9D4F2-53F5-4F17-B4C0-3856212990BC";
            spdNFCe.IdTokenNFCe = "000001";

            spdNFCe.UF = "RN";
            spdNFCe.CNPJ = "29081992000100";
            spdNFCe.ArquivoServidoresHom = @"C:\Program Files\TecnoSpeed\NFCe\arquivos\nfceServidoresHom.ini";
            spdNFCe.ArquivoServidoresProd = @"C:\Program Files\TecnoSpeed\NFCe\arquivos\nfceServidoresProd.ini";
            spdNFCe.DiretorioEsquemas = @"C:\Program Files\TecnoSpeed\NFCe\arquivos\Esquemas\";
            spdNFCe.DiretorioTemplates = @"C:\Program Files\TecnoSpeed\NFCe\arquivos\Templates\";
            spdNFCe.DiretorioLog = path + @"Log\";
            spdNFCe.DiretorioLogErro = path + @"LogErro\";
            spdNFCe.DiretorioTemporario = path + @"Temporario\";
            spdNFCe.DiretorioXmlDestinatario = path + @"XmlDestinatario";
            spdNFCe.TipoCertificado = CertificadoKind.ctFile;
            spdNFCe.NomeCertificado = certificado;
            spdNFCe.VersaoManual = VersaoManualNFCe.vm60;

            spdNFCe.ConexaoSegura = true;
            spdNFCe.ValidarEsquemaAntesEnvio = true;
            spdNFCe.MaxSizeLoteEnvio = 500;
            spdNFCe.CaracteresRemoverAcentos = "áéíóúàèìòùâêîôûäëïöüãõñçÁÉÍÓÚÀÈÌÒÙÂÊÎÔÛÄËÏÖÜÃÕÑ";

            spdNFCe.AnexarDanfcePDF = true;
            spdNFCe.ServidorSmtp = "smtp.gmail.com";
            spdNFCe.EmailRemetente = "testedanfce@gmail.com";
            spdNFCe.EmailDestinatario = "teste@gmail.com";
            spdNFCe.AssuntoEmail = "Exemplo de envio de DANFE por email";
            spdNFCe.MensagemEmail = "O arquivo está anexo.";
            spdNFCe.UsuarioEmail = "testedanfce@gmail.com";
            spdNFCe.SenhaEmail = "SenhaTeste";
            spdNFCe.AutenticacaoEmail = true;
            spdNFCe.PortaEmail = 587;

            spdNFCe.LogotipoEmitente = "";
            spdNFCe.InfCPlMaxCol = 68;
            spdNFCe.InfCplMaxRow = 7;
            spdNFCe.FraseContingencia = "Danfe em contingência - Impresso em decorrência de problemas técnicos.";
            spdNFCe.FraseHomologacao = "SEM VALOR FISCAL";
            spdNFCe.ModeloDanfce = spdNFCe.DiretorioTemplates + "Danfce\\retrato.rtm";
            spdNFCe.QtdeCopias = 1;
        }

        public IObservable<string> consultarNFCe(string chave_nfce)
        {
            //string result = string.Empty;

            this.initNFCe();
            return Observable.Return<string>(spdNFCe.ConsultarNF(chave_nfce));

            //try
            //{
            //    result = spdNFCe.ConsultarNF(chave_nfce);
            //}
            //catch(Exception e)
            //{
            //    result = e.Message;
            //}

            //return result;
        }
    }
}
