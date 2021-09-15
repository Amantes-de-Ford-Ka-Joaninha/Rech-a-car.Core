﻿using iText.Kernel.Pdf;
using iText.Layout;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace EmailAluguelPDF
{
    public class EnviaEmail
    {
        private const string email = "rech.a.car.alugueldeveiculos@gmail.com";

        private static SmtpClient client = new("smtp.gmail.com", 587)
        {
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(email, "rech#admin"),
            EnableSsl = true
        };

        public static void EnviaPDFEmail()
        {
            var proxEnvio = new ControladorEmail().GetProxEnvio();

            if (proxEnvio == null)
                throw new FilaEmailVazia();

            var emailUsuario = proxEnvio.Aluguel.Cliente.Email;
            var message = new MailMessage(email, emailUsuario, "Resumo Aluguel Rech-a-car", "Confira o resumo do seu mais novo aluguel: ");
            Stream ms = PdfToStream(proxEnvio.Pdf);
            message.Attachments.Add(new Attachment(ms, "Pdf Resumo Aluguel.pdf"));

            client.Send(message);
            ControladorEmail.AlterarEnviado(proxEnvio.Id);
        }

        private static Stream PdfToStream(Document pdf)
        {
            var ms = pdf.GetPdfDocument().GetWriter().GetOutputStream();
            ms.Position = 0;
            return ms;
        }
    }
    [Serializable]
    public class FilaEmailVazia : Exception
    {
        public FilaEmailVazia()
        {
        }

        public FilaEmailVazia(string message) : base(message)
        {
        }
    }
}