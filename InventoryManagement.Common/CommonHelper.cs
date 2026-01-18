using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Data;
using System.Reflection;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Configuration;

namespace InventoryManagement.Common
{
    public class CommonHelper
	{
		public static string GenerateRandomPassword(byte PasswordLength)
		{
			string _allowedChars = "abcdefghijkmnopqrstuvwxyz0123456789";
			Random randNum = new Random();
			char[] chars = new char[PasswordLength];
			int allowedCharCount = _allowedChars.Length;

			for (int i = 0; i < PasswordLength; i++)
			{
				chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
			}
			return new string(chars);
		}

		#region  Encrypt and Decrypt
		public static string Encrypt(string strText)
		{
			if (strText == null || strText == "")
			{
				return strText;
			}
			else
			{
				byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
				try
				{
					string strEncrKey = "&123123123,:*";
					byte[] bykey = System.Text.Encoding.UTF8.GetBytes(strEncrKey.Substring(0, 8));
					byte[] inputByteArray = System.Text.Encoding.UTF8.GetBytes(strText);
					DESCryptoServiceProvider des = new DESCryptoServiceProvider();
					MemoryStream ms = new MemoryStream();
					CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(bykey, IV), CryptoStreamMode.Write);
					cs.Write(inputByteArray, 0, inputByteArray.Length);
					cs.FlushFinalBlock();
					return Convert.ToBase64String(ms.ToArray());
				}
				catch (Exception ex)
				{
					return "";
				}
			}
		}

		public static string Decrypt(string strText)
		{
			if (strText == null || strText == "")
			{
				return strText;
			}
			else
			{
				byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
				byte[] inputByteArray = new byte[strText.Length + 1];
				try
				{
					string strEncrKey = "&123123123,:*";
					byte[] byKey = System.Text.Encoding.UTF8.GetBytes(strEncrKey.Substring(0, 8));
					DESCryptoServiceProvider des = new DESCryptoServiceProvider();
					inputByteArray = Convert.FromBase64String(strText);
					MemoryStream ms = new MemoryStream();
					CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
					cs.Write(inputByteArray, 0, inputByteArray.Length);
					cs.FlushFinalBlock();
					System.Text.Encoding encoding = System.Text.Encoding.UTF8;
					return encoding.GetString(ms.ToArray());
				}
				catch (Exception ex)
				{
					return "";
				}
			}
		}

		public static string EncryptPass(string strText)
		{
			if (strText == null || strText == "")
			{
				return strText;
			}
			else
			{
				byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
				try
				{
					MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
					byte[] encrypt;
					UTF8Encoding encode = new UTF8Encoding();
					//encrypt the given password string into Encrypted data  
					encrypt = md5.ComputeHash(encode.GetBytes(strText));
					StringBuilder encryptdata = new StringBuilder();
					//Create a new string by using the encrypted data  
					for (int i = 0; i < encrypt.Length; i++)
					{
						encryptdata.Append(encrypt[i].ToString());
					}
					return encryptdata.ToString();
				}
				catch (Exception ex)
				{
					return "";
				}
			}
		}
		#endregion

		public static void SendEmail(string EmailTo, string Subject, string EmailMessage, bool needCC)
		{
			int PortID = 0;
			var provider = System.Globalization.CultureInfo.CurrentCulture;

			string liveOrProd = ConfigurationManager.AppSettings["server"];
			string configmail = ConfigurationManager.AppSettings["MailTo"];

			if (!liveOrProd.ToLower().Equals("live"))
				EmailTo = configmail;

			System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
			message.To.Add(EmailTo);
			message.Subject = Subject;
			message.From = new System.Net.Mail.MailAddress(ConfigurationManager.AppSettings["fromemail"]);
			message.Body = EmailMessage;
			message.IsBodyHtml = true;
			System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(ConfigurationManager.AppSettings["smtpserver"]);
			smtp.UseDefaultCredentials = false;
			string password = Decrypt(ConfigurationManager.AppSettings["smtppwd"]);
			NetworkCredential basicAuthenticationInfo = new NetworkCredential(ConfigurationManager.AppSettings["smtpuser"], password);
			smtp.Credentials = basicAuthenticationInfo;
			if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["smtpPort"]))
				PortID = Convert.ToInt32(ConfigurationManager.AppSettings["smtpPort"], provider);
			else
			{
				PortID = 0;
			}
			smtp.Port = PortID;
			smtp.EnableSsl = true;
			try
			{
				Thread thrdEmail = new Thread(new ThreadStart(() => smtp.Send(message)));
				thrdEmail.IsBackground = true;
				thrdEmail.Start();
			}
			catch (System.Exception ex)
			{
				ex.ToString();
			}
		}

		public static String APIKey()
		{
			string token = Guid.NewGuid().ToString();
			return token;
		}

		/// <summary>
		/// Used to convert List<T> to DataTable
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="items"></param>
		/// <returns></returns>
		public static DataTable ToDataTable<T>(List<T> items)
		{
			DataTable dataTable = new DataTable(typeof(T).Name);

			//Get all the properties
			PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
			foreach (PropertyInfo prop in Props)
			{
				//Setting column names as Property names
				dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
			}
			foreach (T item in items)
			{
				var values = new object[Props.Length];
				for (int i = 0; i < Props.Length; i++)
				{
					//inserting property values to datatable rows
					values[i] = Props[i].GetValue(item, null);
				}
				dataTable.Rows.Add(values);
			}
			//put a breakpoint here and check datatable
			return dataTable;
		}

        //public static LoginModel GetUserSessionDetail(string token)
        //{
        //    LoginModel model = new LoginModel();
        //    try
        //    {
        //        var tokenDetail = CommonHelper.Decrypt(token).Split('#');
        //        model.AuthToken = tokenDetail[0];
        //        model.UserType = Convert.ToInt32(tokenDetail[1]);
        //        model.RoleId = Convert.ToInt32(tokenDetail[2]);
        //        model.UserId = Convert.ToInt64(tokenDetail[3]);
        //    }
        //    catch (Exception ex)
        //    {
        //        model = null;
        //    }
        //    return model;
        //}

        //public static string CreateUserToken(LoginModel user)
        //{
        //    string token = user.AuthToken + "#" + user.UserType.ToString() + "#" + user.RoleId.ToString() + "#" + user.UserId.ToString();
        //    token = CommonHelper.Encrypt(token);
        //    return token;
        //}

        //public static string GetImage(string pathToImage, string imageName)
        //{
        //	try
        //	{
        //		string imageDirectory = InventoryManagementSettings.ImagePathUrl + "\\Documents\\" + pathToImage + "\\";
        //		string imageWithPath = imageDirectory + imageName;
        //		byte[] imageBytes = File.ReadAllBytes(imageWithPath);
        //		return Convert.ToBase64String(imageBytes);
        //		//return "";
        //	}
        //	catch (Exception Ex)
        //	{
        //		return "";
        //	}
        //}

        public static string SaveImage(string PathToSaveImage, string base64imageString, bool createThumb, string extn, int isOriginalSave = 0)
		{
			try
			{
				if (base64imageString != null)
				{
					string baseDirectory = InventoryManagementSettings.ImagePathUrl;//AppDomain.CurrentDomain.BaseDirectory;
					string imageDirectory = InventoryManagementSettings.ImagePathUrl + "\\Documents\\" + PathToSaveImage + "\\";
					if (!Directory.Exists(imageDirectory))
					{
						Directory.CreateDirectory(imageDirectory);
					}
					if (extn == "")
					{
						extn = ".jpg";
					}
					string fileName = DateTime.UtcNow.ToString("yyyyMMddHHmmssfff") + extn;
					string filePath = imageDirectory + fileName;

					var bytes = Convert.FromBase64String(base64imageString);
					//convert byte to image
					using (MemoryStream ms = new MemoryStream(bytes))
					{

						var bmp = new Bitmap(ms);
						if (isOriginalSave == 0)
						{
							ImageHandler.Save(bmp, 640, 480, 100, filePath, extn);
						}
						else
						{
							ImageHandler.Save(bmp, bmp.Width, bmp.Height, 100, filePath, extn);
						}
						if (createThumb)
						{
							imageDirectory = imageDirectory + "Thumb\\";
							if (!Directory.Exists(imageDirectory))
							{
								Directory.CreateDirectory(imageDirectory);
							}
							filePath = imageDirectory + fileName;
							ImageHandler.Save(bmp, 75, 75, 50, filePath, extn);
						}

					}
					//Resize and save thumb Image
					return fileName;
				}
			}
			catch(Exception ex)
			{
			}
			return null;
		}

		public static string SaveFile(string PathToSaveImage, string base64imageString, bool createThumb, string extn, int isOriginalSave = 0)
		{
			try
			{
				if (base64imageString != null)
				{
					string baseDirectory = InventoryManagementSettings.ImagePathUrl;//AppDomain.CurrentDomain.BaseDirectory;
					string imageDirectory = InventoryManagementSettings.ImagePathUrl + "\\Documents\\" + PathToSaveImage + "\\";
					if (!Directory.Exists(imageDirectory))
					{
						Directory.CreateDirectory(imageDirectory);
					}
					string fileName = DateTime.UtcNow.ToString("yyyyMMddHHmmssfff") + extn;
					string filePath = imageDirectory + fileName;

					using (FileStream stream = System.IO.File.Create(filePath))
					{
						byte[] byteArray = Convert.FromBase64String(base64imageString);
						stream.Write(byteArray, 0, byteArray.Length);
					}
					return fileName;
				}
			}
			catch
			{
			}
			return null;
		}

		public static string LogError(Exception ex)
		{
			StringBuilder message = new StringBuilder();
			message.Append(string.Format("Time: {0}", DateTime.UtcNow.ToString("dd/MM/yyyy hh:mm:ss tt")));
			message.Append(Environment.NewLine);
			message.Append("-----------------------------------------------------------");
			message.Append(Environment.NewLine);
			message.Append(string.Format("Message: {0}", ex.Message));
			message.Append(Environment.NewLine);
			message.Append(string.Format("Inner Exception: {0}", ex.InnerException));
			message.Append(Environment.NewLine);
			message.Append(string.Format("StackTrace: {0}", ex.StackTrace));
			message.Append(Environment.NewLine);
			message.Append(string.Format("Source: {0}", ex.Source));
			message.Append(Environment.NewLine);
			message.Append(string.Format("TargetSite: {0}", ex.TargetSite.ToString()));
			message.Append(Environment.NewLine);
			message.Append("-----------------------------------------------------------");
			message.Append(Environment.NewLine);
			string DirectoryPath = Constants.BaseURL + "Documents\\ErrorLog\\";
			if (!Directory.Exists(DirectoryPath))
			{
				Directory.CreateDirectory(DirectoryPath);
			}
			string FilePath = DirectoryPath + DateTime.UtcNow.ToString("ddMMyyyy") + ".txt";
			using (StreamWriter writer = new StreamWriter(FilePath, true))
			{
				writer.WriteLine(message.ToString());
				writer.Close();
			}
			return message.ToString();
		}

        //public static string GetClientIp(HttpRequestMessage request)
        //{
        //    if (request.Properties.ContainsKey("MS_HttpContext"))
        //    {
        //        return ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
        //    }

        //    if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
        //    {
        //        RemoteEndpointMessageProperty prop;
        //        prop = (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name];
        //        return prop.Address;
        //    }

        //    return null;
        //}

        //public static string GenerateImage(string captcha)
        //{
        //	Random random = new Random();
        //	Bitmap bitmap = new Bitmap(300, 75, PixelFormat.Format64bppArgb);
        //	Graphics g = Graphics.FromImage(bitmap);
        //	g.SmoothingMode = SmoothingMode.AntiAlias;
        //	Rectangle rect = new Rectangle(0, 0, 300, 75);
        //	HatchBrush hatchBrush = new HatchBrush(HatchStyle.SmallConfetti,
        //			Color.LightGray, Color.White);
        //	g.FillRectangle(hatchBrush, rect);
        //	SizeF size;
        //	float fontSize = rect.Height + 1;
        //	Font font;

        //	do
        //	{
        //		fontSize--;
        //		font = new Font(FontFamily.GenericSansSerif, fontSize, FontStyle.Bold);
        //		size = g.MeasureString(captcha, font);
        //	} while (size.Width > rect.Width);
        //	StringFormat format = new StringFormat();
        //	format.Alignment = StringAlignment.Center;
        //	format.LineAlignment = StringAlignment.Center;
        //	GraphicsPath path = new GraphicsPath();
        //	//path.AddString(this.text, font.FontFamily, (int) font.Style, 
        //	//    font.Size, rect, format);
        //	path.AddString(captcha, font.FontFamily, (int)font.Style, 55, rect, format);
        //	float v = 4F;
        //	PointF[] points =
        //		{
        //								new PointF(random.Next(rect.Width) / v, random.Next(
        //									 rect.Height) / v),
        //								new PointF(rect.Width - random.Next(rect.Width) / v,
        //										random.Next(rect.Height) / v),
        //								new PointF(random.Next(rect.Width) / v,
        //										rect.Height - random.Next(rect.Height) / v),
        //								new PointF(rect.Width - random.Next(rect.Width) / v,
        //										rect.Height - random.Next(rect.Height) / v)
        //					};
        //	Matrix matrix = new Matrix();
        //	matrix.Translate(0F, 0F);
        //	path.Warp(points, rect, matrix, WarpMode.Perspective, 0F);
        //	hatchBrush = new HatchBrush(HatchStyle.Percent10, Color.Black, Color.FromArgb(18, 72, 82));
        //	g.FillPath(hatchBrush, path);
        //	int m = Math.Max(rect.Width, rect.Height);
        //	for (int i = 0; i < (int)(rect.Width * rect.Height / 30F); i++)
        //	{
        //		int x = random.Next(rect.Width);
        //		int y = random.Next(rect.Height);
        //		int w = random.Next(m / 50);
        //		int h = random.Next(m / 50);
        //		g.FillEllipse(hatchBrush, x, y, w, h);
        //	}
        //	font.Dispose();
        //	hatchBrush.Dispose();
        //	g.Dispose();
        //	System.IO.MemoryStream ms = new System.IO.MemoryStream();
        //	bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        //	byte[] byteImage = ms.ToArray();
        //	var SigBase64 = Convert.ToBase64String(byteImage);
        //	return SigBase64;
        //}
       
        public static string GenerateCaptcha()
		{
			Random generator = new Random();
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, 6)
					.Select(s => s[generator.Next(s.Length)]).ToArray());
		}

		public static string CaptchaToken()
		{
			Random generator = new Random();
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			string Ctoken = new string(Enumerable.Repeat(chars, 6)
					.Select(s => s[generator.Next(s.Length)]).ToArray());
			DateTimeOffset offsetTime = new DateTimeOffset();
			Ctoken = Ctoken + offsetTime.UtcDateTime.ToString();
			return CommonHelper.Encrypt(Ctoken);
		}


		public static List<T> ConvertDataTable<T>(DataTable dt)
		{
			List<T> data = new List<T>();
			foreach (DataRow row in dt.Rows)
			{
				T item = GetItem<T>(row);
				data.Add(item);
			}
			return data;
		}

		private static T GetItem<T>(DataRow dr)
		{
			Type temp = typeof(T);
			T obj = Activator.CreateInstance<T>();

			foreach (DataColumn column in dr.Table.Columns)
			{
				foreach (PropertyInfo pro in temp.GetProperties())
				{
					if (pro.Name == column.ColumnName)
						pro.SetValue(obj, (dr[column.ColumnName] == DBNull.Value) ? null : dr[column.ColumnName], null);
					else
						continue;
				}
			}
			return obj;
		}
	}
}
