﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceWorker.Domain
{
    public class RabbitMQConfiguration
    {
        public string Hostname { get; set; }

        public string RequestQueueName { get; set; }

        public string ResponseQueueName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool Enabled { get; set; }
    }
}
