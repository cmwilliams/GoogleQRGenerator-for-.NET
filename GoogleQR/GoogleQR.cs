using System;
using System.Collections.Generic;

namespace GoogleQRGenerator
{
	public class GoogleQr
	{
		public string Data { get; set; }

		public string Size { get; set; }

		public bool UseHttps { get; set; }

		public string Encoding { get; set; }

		public string ErrorCorrection { get; set; }

		public GoogleQr (string data, int Width, int Height, bool useHttp)
		{
			Data = !string.IsNullOrEmpty (data) ? data : "http://www.google.com";
			Size = !string.IsNullOrEmpty (size) ? size : Width + "x" + Height;
			UseHttps = useHttp;
		}

		private string BaseUrl ()
		{
			return "http" + (UseHttps ? "s" : "") + "://chart.googleapis.com/chart?cht=qr&";
		}

		public string Render ()
		{
			string dimensions = null;

			if (!string.IsNullOrEmpty (Size)) {
				var sizes = Size.Split (new[] { 'x' });
				var height = sizes [0];
				string width = sizes [1];
				dimensions = " height='" + height + "' width='" + width + "'";
			}

			return "<img src='" + ToString () + "'" + dimensions + " />";
		}

		public override string ToString ()
		{
			if (!string.IsNullOrEmpty (Data)) {
				var parameters = new List<string> { "chl=" + Data };
				if (!string.IsNullOrEmpty (Size))
					parameters.Add ("chs=" + Size);
				if (!string.IsNullOrEmpty (Encoding))
					parameters.Add ("choe=" + Encoding);
				if (!string.IsNullOrEmpty (ErrorCorrection))
					parameters.Add ("chld=" + ErrorCorrection);

				return BaseUrl () + string.Join ("&", parameters.ToArray ());
			}
			throw new Exception ("Data is required");
		}
	}
}
