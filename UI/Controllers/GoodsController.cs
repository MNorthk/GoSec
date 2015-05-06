using Bll;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class GoodsController : Controller
    {
        //
        // GET: /Take/

        public JsonResult getSomeGoodsInfo()
        {
            GetGoods getGoods = new GetGoods();
            List<SomeGoodsInfo> list = getGoods.getSomeGoodsInfos();
            return Json(list,JsonRequestBehavior.AllowGet);
           // return View();
        }
        [HttpPost]
        public JsonResult setGoodsInfoIn(UserGoodsInfo userGoodsInfo)
        {
            if (String.IsNullOrEmpty(userGoodsInfo.masterId) || String.IsNullOrEmpty(userGoodsInfo.takeGoodsAdress) || String.IsNullOrEmpty(userGoodsInfo.takeTime) || String.IsNullOrEmpty(userGoodsInfo.expressAdress))
                return Json("k201");
            if (!Regex.IsMatch(userGoodsInfo.takeTime, @"^\d{2}:\d{2}$"))
                return Json("k204");
            if (Session["studentNorth"] == null || Session["studentNorth"].ToString() != userGoodsInfo.masterId)
                return Json("k203");
            SetGoodsIn setGoodsIn = SetGoodsIn.getSetGoodsIn(userGoodsInfo);
            if (setGoodsIn == null)
                return Json("k201");
            if (!setGoodsIn.saveGoodsInfo())
                return Json("k202");
            return Json("k200");

        }
        //public JsonResult setUnGuestIn(int goodsId,string guestId)
        //{
        //    if()
        //}

    }
}
