# MailBuilder


    static void Main(string[] args)
    {
        var mail = new MailBuilder()
            .From("mmarinov@gmail.com")
            .To(new [] {"ivan@ivanbook.com", "pesho@gmail.com"})
            .CC(new [] {"someoneElse@xyz.com"})
            .AddToHeader("Head Line 1")
            .AddToHeader("Head Line 1")
            .AddToBody("Body line 1")
            .AddToBody("Body line 1")
            .AddToFooter("Signature")
            .Build()
            .GetResult();

        Console.WriteLine(mail.Body);
    }
