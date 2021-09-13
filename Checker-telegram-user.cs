using System;
using System.Net;
using System.IO;
using System.Linq;
using System.Text;
namespace Simple
{
	class Program
	{
		static void Main(string[] args) 
		{
			// TOKEN
			string ruks_Tok ="TOKEN BOT";	   
			// id
			string ruks_id ="ID";						
			while (true)
			{
				var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
				var stringChars = new char[5];
				var random = new Random();
				for (int i = 0; i < stringChars.Length; i++)
				{
					stringChars[i] = chars[random.Next(chars.Length)];
				}
				var ruks_user = new String(stringChars);
				HttpWebRequest k = (HttpWebRequest)WebRequest.Create("https://t.me/"+ruks_user);
				
				
				HttpWebResponse response; 
				try
				{
					response = (HttpWebResponse)k.GetResponse();
				}catch (WebException ep)
				{
					response = (HttpWebResponse)ep.Response;
				}
				using (StreamReader st = new StreamReader(response.GetResponseStream()))
				{
					string txt = st.ReadToEnd();
					
					if (txt.Contains("you have <strong>Telegram</strong>, you can contact <a"))
					
					{
						
						Console.WriteLine("User is available :@"+ruks_user);
						try
						{
							HttpWebRequest ruks_req = (HttpWebRequest)WebRequest.Create("https://api.telegram.org/bot"+ruks_Tok+"/sendMessage?chat_id="+ruks_id+"&text=username :@"+ruks_user);
						
							response = (HttpWebResponse)ruks_req.GetResponse();
						}
						catch (WebException ep)
						{
							response = (HttpWebResponse)ep.Response;
						}
						
					}
					else
					{
						Console.WriteLine("User is not available :@"+ruks_user);
					}
				}
				
			
			}
		}
	}
}