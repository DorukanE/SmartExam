﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SmartExam
{
    public class Istatistik
    {
        public int Adet { get; set; }
        public string Konu { get; set; }

        public List<Istatistik> IstatistiklerDogru = new List<Istatistik>();
        public List<Istatistik> IstatistiklerYanlis = new List<Istatistik>();

        sqlBaglanti connect = new sqlBaglanti();
        public void IstatistikGetir(Istatistik istatistik, int DersID, int OgrenciID,int SinavID)
        {
            // Doğru Cevapların İstatistiği

            SqlCommand istatistikGetirDogru = new SqlCommand("select (select Count(*)from Tbl_CozulmusSoru where Tbl_CozulmusSoru.KonuID = Tbl_Konu.KonuID and OgrenciID = @p2 and SınavID = @p3 and DogruYanlis=1),KonuAD from Tbl_Konu  where  DersID =  @p1 ", connect.baglanti());
            istatistikGetirDogru.Parameters.AddWithValue("@p1", DersID);
            istatistikGetirDogru.Parameters.AddWithValue("@p2", OgrenciID);
            istatistikGetirDogru.Parameters.AddWithValue("@p3", SinavID);
            SqlDataReader dtIstatistikDogru = istatistikGetirDogru.ExecuteReader();
            while (dtIstatistikDogru.Read())
            {
                Istatistik istatistiks = new Istatistik();
                istatistiks.Adet = Convert.ToInt32(dtIstatistikDogru[0]);
                istatistiks.Konu = dtIstatistikDogru[1].ToString();
                IstatistiklerDogru.Add(istatistiks);
            }

            // Yanlış Cevapların İstatistiği

            SqlCommand istatistikGetirYanlis = new SqlCommand("select (select Count(*)from Tbl_CozulmusSoru where Tbl_CozulmusSoru.KonuID = Tbl_Konu.KonuID and OgrenciID = @p2 and SınavID=@p3 and DogruYanlis=0),KonuAD from Tbl_Konu  where  DersID =  @p1 ", connect.baglanti());
            istatistikGetirYanlis.Parameters.AddWithValue("@p1", DersID);
            istatistikGetirYanlis.Parameters.AddWithValue("@p2", OgrenciID);
            istatistikGetirYanlis.Parameters.AddWithValue("@p3", SinavID);
            SqlDataReader dtIstatistikYanlis = istatistikGetirYanlis.ExecuteReader();
            while (dtIstatistikYanlis.Read())
            {
                Istatistik istatistiks = new Istatistik();
                istatistiks.Adet = Convert.ToInt32(dtIstatistikYanlis[0]);
                istatistiks.Konu = dtIstatistikYanlis[1].ToString();
                IstatistiklerYanlis.Add(istatistiks);
            }
        }
    }
}
