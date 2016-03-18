using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BannedHistoryTest.Models
{

    public class BannedClientHistoryViewModel
    {
        public BannedClientHistoryViewModel(BannedClientHistory bc)
        {
            this.ID = bc.ID;
            this.Ip = bc.Ip;
            this.Score = bc.Score;
            this.Country = bc.Country;
            this.Geo = bc.Geo;
            this.Created = bc.Created;
            this.Score = bc.Score;
            this.ServiceName = bc.ServiceName;
            this.ServerName = bc.ServerName;
            this.Service_ID = bc.Service_ID;
            this.Server_ID = bc.Service_ID;
            this.Operation = bc.Operation;
            this.ImgUrl = "~/Content/24/" + Country.ToLower() + (".png");
        }
        public BannedClientHistoryViewModel()
        {

        }
        public int ID { get; set; }
        public string Ip { get; set; }
        public string Country { get; set; }
        public string Geo { get; set; }
        public DateTime Created { get; set; }
        public double? Score { get; set; }
        public string ServiceName { get; set; }
        public string ServerName { get; set; }
        public int Service_ID { get; set; }
        public int Server_ID { get; set; }
        public string Operation { get; set; }
        public string ImgUrl { get; set; }
    }

}