﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Contracts.Services
{

    public interface IResourceManager
    {
        public Task<Uri> UploadPDF(IFormFile pdf);
        public Task<Uri> UploadImage(IFormFile image);
    }

}