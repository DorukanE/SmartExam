﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartExam
{
    public class Soru:IResim,ISoruIslemleri
    {
        public int SoruID { get; set; }
        public string SoruIcerik { get; set; }
        public string ACevabi { get; set; }
        public string BCevabi { get; set; }
        public string CCevabi { get; set; }
        public string DCevabi { get; set; }
        public string ECevabi { get; set; }
        public string Cevap { get; set; }
        public string Resim { get; set; }

        public void TumSorulariGetir()
        {
            throw new NotImplementedException();
            
        }
    }
}
