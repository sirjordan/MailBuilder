public class MailBuilder
    {
        private StringBuilder header;
        private StringBuilder body;
        private StringBuilder footer;

        private StringBuilder messageBody;
        private bool built;
        private System.Net.Mail.MailMessage result;

        public MailBuilder()
        {
            this.header = new StringBuilder();
            this.body = new StringBuilder();
            this.footer = new StringBuilder();
            this.built = false;
            this.messageBody = new StringBuilder();
            this.result = new System.Net.Mail.MailMessage();
        }

        public MailBuilder Subject(string subject)
        {
            this.result.Subject = subject;
            return this;
        }
        public MailBuilder From(string email)
        {
            this.result.From = new System.Net.Mail.MailAddress(email);
            return this;
        }
        public MailBuilder To(params string[] participants)
        {
            this.result.To.Clear();
            foreach (string mail in participants)
            {
                this.result.To.Add(mail);
            }
            return this;
        }
        public MailBuilder CC(params string[] participants)
        {
            this.result.CC.Clear();
            foreach (string mail in participants)
            {
                this.result.CC.Add(mail);
            }
            return this;
        }
        public MailBuilder Bcc(params string[] participants)
        {
            this.result.Bcc.Clear();
            foreach (string mail in participants)
            {
                this.result.CC.Add(mail);
            }
            return this;
        }
        public MailBuilder AddTo(string email)
        {
            this.result.To.Add(email);
            return this;
        }
        public MailBuilder AddCC(string email)
        {
            this.result.CC.Add(email);
            return this;
        }
        public MailBuilder AddBcc(string email)
        {
            this.result.Bcc.Add(email);
            return this;
        }
        public MailBuilder AddToHeader(string text)
        {
            string newLine = string.Empty;
            if (this.header.Length > 0)
            {
                newLine = "</br>";
            }

            this.header.AppendFormat("{1}<b>{0}</b>", text, newLine);
            return this;
        }
        public MailBuilder AddToBody(string text)
        {
            string newLine = string.Empty;
            if (this.body.Length > 0)
            {
                newLine = "</br>";
            }

            this.body.AppendFormat("{1}{0}", text, newLine);
            return this;
        }
        public MailBuilder AddToFooter(string text)
        {
            string newLine = string.Empty;
            if (this.footer.Length > 0)
            {
                newLine = "</br>";
            }

            this.footer.AppendFormat("{1}{0}", text, newLine);
            return this;
        }
        public MailBuilder Build()
        {
            this.messageBody.AppendFormat("{0}</br></br>{1}</br></br>{2}", this.header, this.body, this.footer);

            this.built = true;
            return this;
        }
        public System.Net.Mail.MailMessage GetResult()
        {
            if (!built)
            {
                return this.Build().GetResult();
            }

            this.result.Body = this.messageBody.ToString();
            return this.result;
        }
    }
