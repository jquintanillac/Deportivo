﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Deportivo.Common.Models
{
    public class AccesoriosResponse
    {
        public int id_acce { get; set; }
        public string acce_desc { get; set; }
        public string acce_obs { get; set; }
        public bool acce_act { get; set; }
        public DateTime acce_fecing { get; set; }
    }
}
