using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public partial class GoodsInfos
    {
        public int goosId { get; set; }
        public string masterId { get; set; }
        public string guestId { get; set; }
        public string expressAdress { get; set; }
        public string takeGoodsAdress { get; set; }
        public string goodsInfo { get; set; }
        public System.DateTime takeTime { get; set; }
        public int state { get; set; }
    }
    public partial class unGuest
    {
        public int guestAngGoodsId { get; set; }
        public int goodsId { get; set; }
        public string unGuestId { get; set; }
        public int requestState { get; set; }
        public int state { get; set; }
    }
    public class UserGoodsInfo
    {
        public string masterId { get; set; }
        public string expressAdress { get; set; }
        public string takeGoodsAdress { get; set; }
        public string goodsInfo { get; set; }
        public string takeTime { get; set; }
    }
    public class SomeGoodsInfo
    {
        public int goodsId { get; set; }
        public string masterId { get; set; }
        public string expressAdress { get; set; }
        public string takeGoodsAdress { get; set; }
        public string goodsInfo { get; set; }
        public System.DateTime takeTime { get; set; }
    }
}
