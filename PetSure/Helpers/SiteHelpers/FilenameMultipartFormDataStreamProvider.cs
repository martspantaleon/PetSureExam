﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace PetSure.Helpers.SiteHelpers
{
    public class FilenameMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public FilenameMultipartFormDataStreamProvider(string path) : base(path)
        {
        }

        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {
            var name = !string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName) ? headers.ContentDisposition.FileName : Guid.NewGuid().ToString();
            return name.Replace("\"", string.Empty);
        }
    }
}
