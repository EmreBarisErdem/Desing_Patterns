public interface IBildirim
{
	void Gönder();
}

public class EmailBildirim : IBildirim
{
	public void Gönder()
	{
        Console.WriteLine("Email Bildirimi Gönderildi");
		
	}
}

public class SmsBildirim : IBildirim
{
	public void Gönder()
	{
        Console.WriteLine("Sms Bildirimi Gönderildi");
	}
}

public class BildirimFactory
{
	public static IBildirim BildirimOlustur(string bildirimTürü)
	{
		return bildirimTürü switch
		{
			"Email" => new EmailBildirim(),
			"Sms" => new SmsBildirim(),
			_ => throw new ArgumentException("Geçersiz bildirim türü")
		};
	}
}

class Program
{
	static void Main()
	{
		IBildirim emailBildirim = BildirimFactory.BildirimOlustur("Email");
		IBildirim smsBildirim = BildirimFactory.BildirimOlustur("Sms");

		emailBildirim.Gönder();
		smsBildirim.Gönder();

	}
}