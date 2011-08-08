

using System;
using System.Collections.Generic;

namespace GoogleQRGenerator
{
    public class GoogleQR
    {
        public string Data { get; set; }
        public string Size { get; set; }
        public bool UseHttps { get; set; }
        public string Encoding { get; set; }
        public string ErrorCorrection { get; set; }

        public GoogleQR(string data = "http://www.google.com", string size = "100x100", bool useHttps = true)
        {
            Data = data;
            Size = size;
            UseHttps = useHttps;
        }

        private string BaseUrl()
        {
            return "http" + (UseHttps ? "s" : "") + "://chart.googleapis.com/chart?cht=qr&";
        }

        public string Render()
        {
            string dimensions = null;

            if(!string.IsNullOrEmpty(Size))
            {
                string[] sizes = Size.Split(new[] {'x'});
                string height, width;
                height = sizes[0];
                width = sizes[1];
                dimensions = " height='" + height + "' width='" + width + "'";
            }

            return "<img src='" + ToString() + "'" + dimensions + " />";
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Data))
            {
                var parameters = new List<string> {"chl=" + Data};
                if (!string.IsNullOrEmpty(Size))
                    parameters.Add("chs=" + Size);
                if (!string.IsNullOrEmpty(Encoding))
                    parameters.Add("choe=" + Encoding);
                if (!string.IsNullOrEmpty(ErrorCorrection))
                    parameters.Add("chld=" + ErrorCorrection);

                return BaseUrl() + string.Join("&", parameters);
            }
            throw new Exception("Data is required");
        }


    }
}
