using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Dal;

namespace Bll
{
    public class GetGoods
    {
        
        public List<SomeGoodsInfo> getSomeGoodsInfos()
        {
            GoodsEntities goodsEntities=new GoodsEntities();
           
        //DateTime.Now.ToString("yyyy-MM-dd hh:mm")
        //      public int goosId { get; set; }
        //public string masterId { get; set; }
        //public string expressAdress { get; set; }
        //public string takeGoodsAdress { get; set; }
        //public string goodsInfo { get; set; }
        //public System.DateTime takeTime { get; set; }
           
            var a=from u in goodsEntities.GoodsInfos
                  where u.state==1&&DateTime.Compare(u.takeTime,DateTime.Now)>0
                  select new SomeGoodsInfo(){goodsId=u.goosId,masterId=u.masterId,expressAdress=u.expressAdress,takeGoodsAdress=u.takeGoodsAdress,goodsInfo=u.goodsInfo,takeTime=u.takeTime};
            return a.ToList();
        }
        //这还不行，得加查看人的验证
        //已解决一部分
        public GoodsInfos getGoodsInfo(int goodsId,string userId)
        {
            GoodsEntities goodsEntities=new GoodsEntities();
            var a=from u in goodsEntities.GoodsInfos
                  where u.goosId==goodsId&&(u.masterId==userId||u.guestId==userId)
                  select u;
            if(a.Count()<1)
                return null;
            else return a.First();
        }
    }
    //货物主人的验证
    //已解决
    public  class ChangeGoodsInfos
    {
        private int goosId;
        private string masterId;
        private GoodsEntities goodsEntities;
        public ChangeGoodsInfos(int goodsId,string masterId)
        {
            this.goosId = goodsId;
            this.masterId = masterId;
            this.goodsEntities = new GoodsEntities();
        }
        private bool IsHaveThisId()
        {
            var a = from u in
                        goodsEntities.GoodsInfos
                    where u.goosId == goosId&&u.masterId==masterId
                    select u;
            if (a.Count() < 1)
                return false;
            else return true;
        }
        private  bool ChangeState(int i)
        {
            if (!IsHaveThisId())
                return false;
            var a = from u in
                        goodsEntities.GoodsInfos
                    where u.goosId == goosId
                    select u;
            a.First().state = i;
            if (goodsEntities.SaveChanges() < 1)
                return false;
            else return true;
        }
        public bool ChangeStateOk()
        {
            return ChangeState(1);
        }
        public bool ChangeStatePass()
        {
            return ChangeState(0);
        }
        public bool ChangeGuest(string  guestId)
        {
            if (!IsHaveThisId())
                return false;
            GoSecEntities Student=new GoSecEntities();
            var i = from u in Student.LoginPsw
                    where u.StudentId == guestId
                    select u;
            if (i.Count() <1 )
                return false;
            var a = from u in
                        goodsEntities.GoodsInfos
                    where u.goosId == goosId
                    select u;
            a.First().guestId = guestId;
            a.First().state=0;
            if (goodsEntities.SaveChanges() < 1)
                return false;
            else return true;


        }
      


    }
    public class SetGoodsIn
    {
        private UserGoodsInfo userGoodsInfo;
        private GoodsEntities goodsEntities;
        private SetGoodsIn(UserGoodsInfo userGoodsInfo)
        {
            this.userGoodsInfo = userGoodsInfo;
            this.goodsEntities = new GoodsEntities();
        }
        public static SetGoodsIn getSetGoodsIn(UserGoodsInfo userGoodsInfo)
        {
            if (userGoodsInfo == null)
                return null;
            return new SetGoodsIn(userGoodsInfo);
        }
        public bool saveGoodsInfo()
        {
            GoodsInfos goodsInfos = new GoodsInfos()
            {
                //         public string masterId { get; set; }
                //public string expressAdress { get; set; }
                //public string takeGoodsAdress { get; set; }
                //public string goodsInfo { get; set; }
                //public System.DateTime takeTime { get; set; }
                masterId = userGoodsInfo.masterId,
                expressAdress = userGoodsInfo.expressAdress,
                takeGoodsAdress = userGoodsInfo.takeGoodsAdress,
                goodsInfo = userGoodsInfo.goodsInfo,
                takeTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")+" "+userGoodsInfo.takeTime)
            };
            goodsInfos.state = 1;
            goodsInfos.guestId = "0";
            goodsEntities.GoodsInfos.Add(goodsInfos);
            if (goodsEntities.SaveChanges() < 1)
                return false;
            else return true;

        }
    }
}
