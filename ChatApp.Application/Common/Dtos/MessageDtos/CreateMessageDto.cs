﻿using ChatApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Common.Dtos.MessageDtos
{
    public class CreateMessageDto
    {
        public string Content { get; set; }
    }
}
