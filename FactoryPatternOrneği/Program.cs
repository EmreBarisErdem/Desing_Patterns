
using System.Threading.Channels;

public interface IOdeme
{
	void OdemeYap(); //Bütün Ödeme yöntemlerinde mantıklı olan memberlar olmalı...
}

public class KrediKartıOdeme : IOdeme
{
	public void OdemeYap() => Console.WriteLine("Kredi Kartı ile ödeme yapıldı");
}

public class PayPalOdeme : IOdeme
{
	public void OdemeYap() => Console.WriteLine("Paypal ile ödeme yapıldı");
}

public class NakitOdeme : IOdeme
{
	public void OdemeYap() => Console.WriteLine("Nakit ile ödeme yapıldı");
}


public class OdemeFactory // nesne oluşturmak istediğimde bu sınıfı kullanacağım
{
	public static IOdeme OdemeOlusturFactoryMethod(string odemeTuru)
	{
		return odemeTuru switch
		{
			"KrediKartı" => new KrediKartıOdeme(),
			"Paypal" => new PayPalOdeme(),
			"Nakit" => new NakitOdeme(),
			_ => throw new ArgumentException("Geçersiz ödeme türü.")
		};
	}


}

class Program
{
	static void Main()
	{
		IOdeme nakitOdeme = OdemeFactory.OdemeOlusturFactoryMethod("Nakit");

		IOdeme krediKartıOdeme = OdemeFactory.OdemeOlusturFactoryMethod("KrediKartı");

		IOdeme paypalOdeme = OdemeFactory.OdemeOlusturFactoryMethod("Paypal");

		

	}
}


