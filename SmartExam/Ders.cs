﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SmartExam
{
    public class Ders
    {
        public int DersID { get; set; }
        public string DersAD { get; set; }

        public List<Ders> Dersler = new List<Ders>();

        sqlBaglanti connect = new sqlBaglanti();

         // Tüm Kayıtlı Dersleri Getir

        public void TumDersler() 
        {

        }
    }
}
