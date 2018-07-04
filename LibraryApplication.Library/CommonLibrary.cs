﻿using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryApplication.Library
{
    public class CommonLibrary
    {
        public string GetUrl(string paramType)
        {
            string returnValue = string.Empty;
            switch (paramType)
            {
                case "full":
                    returnValue = HttpContext.Current.Request.Url.AbsoluteUri;
                    break;
                case "path":
                    returnValue = HttpContext.Current.Request.Url.AbsoluteUri;
                    break;
            }

            return returnValue;
        }

        public List<UrlParameter> UrlParameters
        {
            get{ 
            var returnValue = new List<UrlParameter>();

            string url = this.GetUrl("full");

            string[] urlArr = url.Split('?');
            string[] paramArr = null;

            if (urlArr.Count() > 1)
            {
                paramArr = urlArr[1].Split('&');

                foreach (var item in paramArr)
                {
                    var urlParam = new UrlParameter()
                    {
                        Key = item.Split('=')[0],
                        Value = item.Split('=')[1]
                    };

                    returnValue.Add(urlParam);

                }
            }
                return returnValue;
            }
            
        }


        public string AddUrlParameter(string paramKey, string paramValue)
        {
            string returnValue = string.Empty;

            List<UrlParameter> urlParams = this.UrlParameters;
            UrlParameter urlParameter = urlParams.Where(x => x.Key == paramKey).SingleOrDefault();

            if (urlParameter != null)
            {
                urlParams.Remove(urlParameter);
            }
            urlParams.Add(new UrlParameter()
            {
                Key = paramKey,
                Value = paramValue
            });

            for (int i = 0; i < urlParams.Count(); i++)
            {
                returnValue += (i == 0) ? "?" : "&";
                returnValue += urlParams[i].Key + "=" + urlParams[i].Value;

                // ?aplha=alphaValue&beta=betaValue&gamma=gammaValue
            }

            return returnValue;
        }
    }
}
